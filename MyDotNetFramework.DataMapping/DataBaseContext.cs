using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyDotNetFramework.DataMapping
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            //请注意，authenticationType必须与CookieAuthenticationOptions.AuthenticationType中定义的一致//
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            //在此添加自定义用户声明
            return userIdentity;
        }
    }
    public class DataBaseContext : IdentityDbContext<ApplicationUser>
    {
        public DataBaseContext()
            : base("Name=MyDotNetFramework", throwIfV1Schema: false)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<DataBaseContext>());
        }


        public static DataBaseContext Create()
        {
            return new DataBaseContext();
        }

    }
}
