using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace taka3.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } //Fór eftir leiðbeiningum á netinu . Ingvi

        public string LastName { get; set; } //Fór eftir leiðbeiningum á netinu . Ingvi

        public string Country { get; set; } //Fór eftir leiðbeiningum á netinu . Ingvi

        public DateTime BirthDate { get; set; }

        public string Gender { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {

            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

     public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //Fanney, hópastatus. Eftir fyrirlestri Dabs
		public DbSet<UserPost> UserPosts { get; set; }
        public DbSet<GroupModel> Group { get; set; }
        public DbSet<GroupUser> GroupUser { get; set; }
        public DbSet<FriendModel> FriendModel { get; set; }
		public DbSet<Comment> Comments { get; set; }
        
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
