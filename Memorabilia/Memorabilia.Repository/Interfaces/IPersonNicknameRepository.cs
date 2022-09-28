﻿using Memorabilia.Domain.Entities;

namespace Memorabilia.Repository.Interfaces
{
    public interface IPersonNicknameRepository
    {
        Task Add(PersonNickname personNickname, CancellationToken cancellationToken = default);

        Task Delete(PersonNickname personNickname, CancellationToken cancellationToken = default);

        Task<PersonNickname> Get(int id);

        Task<IEnumerable<PersonNickname>> GetAll(int? personId = null);

        Task Update(PersonNickname personNickname, CancellationToken cancellationToken = default);
    }
}
