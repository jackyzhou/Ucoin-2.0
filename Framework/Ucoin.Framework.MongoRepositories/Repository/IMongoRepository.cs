﻿
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Ucoin.Framework.Entities;
using Ucoin.Framework.Repositories;
using Ucoin.Framework.Specifications;

namespace Ucoin.Framework.MongoRepository
{
    public interface IMongoRepository<T, TKey> : IRepository<T, TKey>
        where T : IAggregateRoot<TKey>
    {
        IQueryable<T> CollectionQueryable { get; }

        void Update(Expression<Func<T, bool>> query, Dictionary<string, object> columnValues);

        void Update(Expression<Func<T, bool>> query, T entity);

        void RemoveAll();
    }
}