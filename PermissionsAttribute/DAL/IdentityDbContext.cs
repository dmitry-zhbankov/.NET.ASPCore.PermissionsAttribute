using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PermissionsAttribute.Models;

namespace PermissionsAttribute.DAL
{
    public class IdentityDbContext : IdentityDbContext<User>
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}