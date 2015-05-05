﻿using System;
using System.Collections.Generic;
using System.Text;
using Ucoin.Framework.EfExtensions.Audit;

namespace Ucoin.EfExtensions.Test
{
    [Audit]
    public partial class User
    {
        public User()
        {
            CreatedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
            PasswordHash = "";
            PasswordSalt = "";
            IsApproved = true;
            LastLoginDate = DateTime.Now;
            LastActivityDate = DateTime.Now;
            Audits = new List<AuditData>();
            AssignedTasks = new List<Task>();
            CreatedTasks = new List<Task>();
            Roles = new List<Role>();
        }

        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public System.Byte[] Avatar { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public System.Byte[] RowVersion { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string Comment { get; set; }
        public bool IsApproved { get; set; }
        public System.DateTime? LastLoginDate { get; set; }
        public System.DateTime LastActivityDate { get; set; }
        public System.DateTime? LastPasswordChangeDate { get; set; }
        public string AvatarType { get; set; }

        public virtual ICollection<AuditData> Audits { get; set; }
        public virtual ICollection<Task> AssignedTasks { get; set; }
        public virtual ICollection<Task> CreatedTasks { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}