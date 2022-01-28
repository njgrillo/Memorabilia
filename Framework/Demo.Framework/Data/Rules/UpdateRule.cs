﻿using FluentValidation.Results;
using Framework.Domain.Entity;
using System;

namespace Demo.Framework.Data.Rules
{
    public class UpdateRule<T> : ISaveRule<T> where T : DomainEntity
    {
        public bool Applies(T entity)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Execute()
        {
            throw new NotImplementedException();
        }
    }
}
