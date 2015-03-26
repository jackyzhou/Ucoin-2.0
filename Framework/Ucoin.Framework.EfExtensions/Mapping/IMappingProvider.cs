﻿using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;

namespace Ucoin.Framework.EfExtensions.Mapping
{
    public interface IMappingProvider
    {
        EntityMap GetEntityMap(Type type, DbContext dbContext);

        EntityMap GetEntityMap(Type type, ObjectContext objectContext);
    }
}
