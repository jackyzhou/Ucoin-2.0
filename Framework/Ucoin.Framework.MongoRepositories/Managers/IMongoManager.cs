﻿using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Ucoin.Framework.MongoRepository.Manager
{
    public interface IMongoManager
    {
        CommandResult GetServerInfo();

        CommandResult GetDatabaseInfo();

        CommandResult GetDatabaseList();

        CommandResult GetReplicationInfo();

        CommandResult GetCollectionInfo();

        MongoCollection<BsonDocument> GetCollection(string collectionName);

        MongoCursor<BsonDocument> GetCollectionIndexs(string collName, string nameSpace);

        IEnumerable<string> GetCollectionNames();

        GetProfilingLevelResult GetProfilingLevel();

        MongoCursor<SystemProfileInfo> GetProfilingInfo(IMongoQuery query, int limit);

        CommandResult SetProfilingLevel(ProfilingLevel level, TimeSpan timeSpan);

        CommandResult SetProfilingLevel(ProfilingLevel level);
    }
}