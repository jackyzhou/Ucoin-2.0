﻿using MongoDB.Driver;
using System;
using Ucoin.Framework.MongoDb.Entities;

namespace Ucoin.Framework.MongoDb
{
    public class BaseMongoDB<T> : DisposableObject where T : class
    {
        private IMongoCollection<T> collection;
        private IMongoDatabase db;

        public BaseMongoDB(string connectionString)
            : this(connectionString, null)
        {
        }

        public BaseMongoDB(string connectionString, string collectionName)
        {
            var mongoUrl = new MongoUrl(connectionString);
            db = GetDatabaseFromUrl(mongoUrl);
            if (!string.IsNullOrEmpty(collectionName))
            {
                this.collection = db.GetCollection<T>(collectionName);
            }
            else
            {
                if (typeof(T).IsSubclassOf(typeof(BaseMongoEntity)))
                {
                    this.collection = db.GetCollection<T>(GetCollectionName());
                }
            }
        }

        private static string GetCollectionName()
        {
            string collectionName;
            var att = Attribute.GetCustomAttribute(typeof(T), typeof(CollectionNameAttribute));
            if (att != null)
            {
                collectionName = ((CollectionNameAttribute)att).Name;
            }
            else
            {
                collectionName = typeof(T).Name;
            }

            if (string.IsNullOrEmpty(collectionName))
            {
                throw new ArgumentException("Collection name cannot be empty for this entity");
            }
            return collectionName;
        }

        private IMongoDatabase GetDatabaseFromUrl(MongoUrl url)
        {
            var client = new MongoClient(url);
            //var server = client.GetServer();
            return client.GetDatabase(url.DatabaseName);
        }

        internal IMongoCollection<T> Collection
        {
            get { return this.collection; }
        }

        internal IMongoDatabase DB
        {
            get { return this.db; }
        }

        /// <summary>
        /// 2.0以後的驅動，不論是IMongoDatabase，還是IMongoServer均無Close方法，不要顯示釋放資源
        /// </summary>
        /// <param name="disposing"></param>
        protected override void OnDispose(bool disposing)
        {           
        }
    }
}
