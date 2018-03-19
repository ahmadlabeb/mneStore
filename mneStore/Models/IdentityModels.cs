using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace mneStore.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationEmployeeUser : IdentityUser
    {
        public string UserType { get; set; }
        public string EmployeeNumber { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationEmployeeUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class mneStoreContext : IdentityDbContext<ApplicationEmployeeUser>
    {
        public mneStoreContext()
            : base("mneStoreContext", throwIfV1Schema: false)
        {
        }

        public static mneStoreContext Create()
        {
            return new mneStoreContext();
        }
        public System.Data.Entity.DbSet<mneStore.Models.bills> bills { get; set; }

        public System.Data.Entity.DbSet<mneStore.Models.items> items { get; set; }
        public System.Data.Entity.DbSet<mneStore.Models.Curruncies> curruncies { get; set; }
        public System.Data.Entity.DbSet<mneStore.Models.Kinds> kinds { get; set; }

        public System.Data.Entity.DbSet<mneStore.Models.UnitItems> UnitItems { get; set; }

        public System.Data.Entity.DbSet<mneStore.Models.brand> brands { get; set; }

        //public System.Data.Entity.DbSet<mneStore.Models.RoleViewModel> RoleViewModels { get; set; }
    }
}