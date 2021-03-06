﻿using Microsoft.AspNet.Identity;
using Thinktecture.IdentityServer.AspNetIdentity;
using Ucoin.Authority.Entities;
using Ucoin.Authority.IRepositories;
using Ucoin.Authority.IServices;

namespace Ucoin.Authority.Services
{
    public class UserService : AspNetIdentityUserService<User, int>, IUserService
    {
        private IUserRepositroy userRepositroy;

        public UserService(IUserRepositroy userRepositroy)
            : base(new UserManager(userRepositroy))
        {
            this.userRepositroy = userRepositroy;
        }
    }
}
