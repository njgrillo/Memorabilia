﻿namespace Memorabilia.Repository.Interfaces;

public interface IPersonTeamRepository
{
    Task<IEnumerable<PersonTeam>> GetAll(int franchiseId);
}
