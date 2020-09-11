using System;
using Volo.Abp.Domain.Entities;

namespace VueAdmin.Domain.Role
{
    public class RoleMenuEntity : Entity<Guid>
    {
        public int RoleId { get; set; }
        public int MenuId { get; set; }
    }
}
