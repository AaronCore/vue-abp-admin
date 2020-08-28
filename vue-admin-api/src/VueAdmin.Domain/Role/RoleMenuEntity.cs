using System;
using Volo.Abp.Domain.Entities;

namespace VueAdmin.Role
{
    public class RoleMenuEntity : Entity<Guid>
    {
        public int RoleId { get; set; }
        public int MenuId { get; set; }
    }
}
