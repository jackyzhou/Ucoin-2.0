﻿
using Ucoin.Authority.Entities;
using Ucoin.Framework.EFRepository;

namespace Ucoin.Authority.IRepositories
{
    public interface IUserRepositroy : IEFRepository<User, int>
    {
    }
}
