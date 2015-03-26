﻿using System;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using Ucoin.Framework.Entities;
using Ucoin.Framework.Reflection;

namespace Ucoin.Framework.EfExtensions.Audit
{
    internal class AuditEntryState
    {
        public AuditEntryState(ObjectStateEntry objectStateEntry)
        {
            if (objectStateEntry == null)
                throw new ArgumentNullException("objectStateEntry");

            if (objectStateEntry.Entity == null)
                throw new ArgumentException("The Entity property is null for the specified ObjectStateEntry.", "objectStateEntry");

            ObjectStateEntry = objectStateEntry;
            Entity = objectStateEntry.Entity;

            EntityType = objectStateEntry.EntitySet.ElementType as EntityType;

            Type entityType = objectStateEntry.Entity.GetType();
            entityType = ObjectContext.GetObjectType(entityType);

            ObjectType = entityType;
            EntityAccessor = TypeAccessor.GetAccessor(entityType);

            AuditEntity = new AuditEntity(objectStateEntry.Entity)
            {
                Action = GetAction(objectStateEntry),
            };
        }

        public ObjectContext ObjectContext { get; set; }
        public AuditLog AuditLog { get; set; }

        public object Entity { get; private set; }
        public Type ObjectType { get; private set; }
        public EntityType EntityType { get; private set; }
        public ObjectStateEntry ObjectStateEntry { get; private set; }
        public TypeAccessor EntityAccessor { get; private set; }

        public AuditEntity AuditEntity { get; private set; }

        public bool IsAdded
        {
            get { return AuditEntity.Action == ObjectStateType.Added; }
        }
        public bool IsDeleted
        {
            get { return AuditEntity.Action == ObjectStateType.Deleted; }
        }
        public bool IsModified
        {
            get { return AuditEntity.Action == ObjectStateType.Modified; }
        }

        private static ObjectStateType GetAction(ObjectStateEntry entity)
        {
            switch (entity.State)
            {
                case EntityState.Added:
                    return ObjectStateType.Added;
                case EntityState.Deleted:
                    return ObjectStateType.Deleted;
                default:
                    return ObjectStateType.Modified;
            }
        }
    }
}
