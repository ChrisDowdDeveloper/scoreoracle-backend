using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scoreoracle_backend.Models;

namespace scoreoracle_backend.DTOs.GroupMember
{
    public class GroupMemberResponseDto
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public string Username { get; set; }

        public string Role { get; set; }

        public Guid GroupId { get; set; }
        public string GroupName { get; set; }
    }
}