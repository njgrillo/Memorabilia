﻿using Framework.Domain.Command;
using Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.User.Dashboard
{
    public class SaveUserDashboard
    {
        public class Handler : CommandHandler<Command>
        {
            private readonly IUserRepository _userRepository;

            public Handler(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            protected override async Task Handle(Command command)
            {
                var user = await _userRepository.Get(command.UserId).ConfigureAwait(false);

                user.SetDashboardItems(command.DashboardItemIds);

                await _userRepository.Update(user).ConfigureAwait(false);
            }
        }

        public class Command : DomainCommand, ICommand
        {
            private readonly SaveUserDashboardViewModel _viewModel;

            public Command(SaveUserDashboardViewModel viewModel)
            {
                _viewModel = viewModel;
            }

            public int[] DashboardItemIds => _viewModel.UserDashboardItems
                                                       .Where(userDashboardItem => userDashboardItem.IsSelected)
                                                       .Select(userDashboardItem => userDashboardItem.DashboardItemId)
                                                       .ToArray();

            public int UserId => _viewModel.UserId;
        }
    }
}
