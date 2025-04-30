using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Supabase.Postgrest.Attributes;

namespace scoreoracle_backend.Models
{
    public class GroupMember
    {
        [PrimaryKey("id", false)]
        public Guid Id { get; set; }

        [Column("user_id")]
        public Guid UserId { get; set; }

        [Column("role")]
        public GroupRole Role { get; set; }

        [Column("group_id")]
        public Guid GroupId { get; set; }
    }
}

public enum GroupRole
{
    Member,
    Admin
}