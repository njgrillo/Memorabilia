using Demo.Framework.Domain;
using Demo.Framework.Domain.Event;
using Demo.Framework.Extension;
using Framework.Domain.Entity;
using Framework.Handler;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.Framework.Data
{
    public abstract class UnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        private readonly DbContext _context;
        private readonly ILogger _log;
        private readonly IMediator _mediator;

        public UnitOfWork(TContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
            _log = Log.ForContext(GetType());
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var domainEvents = _context.ChangeTracker
                                       .Entries<DomainEntity>()
                                       .SelectMany(domainEvent => domainEvent.Entity.GetRecordedEvents())
                                       .ToArray();

            await PublishAsync(domainEvents.OfType<IBeforeSaveDomainEvent>(), cancellationToken).ConfigureAwait(false);

            //await RemoveDeletedEntries().ConfigureAwait(false);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            var additionalDomainEvents = _context.ChangeTracker
                                                 .Entries<DomainEntity>()
                                                 .SelectMany(domainEvent => domainEvent.Entity.GetRecordedEvents())
                                                 .ToArray();

            await PublishAsync(domainEvents.Concat(additionalDomainEvents).OfType<IAfterSaveDomainEvent>(), cancellationToken).ConfigureAwait(false);
        }

        private async Task PublishAsync(IEnumerable<IDomainEvent> domainEvents, CancellationToken cancellationToken = default)
        {
            foreach (var domainEvent in domainEvents)
            {
                var domainEventName = domainEvent.GetType().Name;

                try
                {
                    _log.Information("Event Fired: {@Event}", domainEvent);

                    await _mediator.Publish(domainEvent, cancellationToken).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    _log.Error(ex, $"Event Error ({domainEventName}): {ex.Message}");

                    throw;
                }
            }
        }

        private async Task RemoveDeletedEntries()
        {
            var deletedObjects = _context.ChangeTracker.Entries()
                                         .Where(entity => entity.State != EntityState.Deleted)
                                         .Select(entity => entity.Entity)
                                         .OfType<DomainObject>()
                                         .Where(domainObject => domainObject.ObjectState == ObjectState.Deleted);

            //deletedObjects.GroupBy(o => o.GetType()).ForEach(types => _context.Set(types.Key).RemoveRange(types));
        }
    }
}
