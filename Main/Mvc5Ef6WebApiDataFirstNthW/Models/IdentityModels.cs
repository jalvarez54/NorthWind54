using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace Mvc5Ef6WebApiDataFirstNthW.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        // New properties added to extend Application User class:

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public string PhotoUrl { get; set; }
        [NotMapped]
        public HttpPostedFileWrapper Photo { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
    }

    // New Class in which we consolidate our user and role management functions:

    public class IdentityManager
    {
        /// <summary>
        /// http://stackoverflow.com/questions/20632626/correct-syntax-to-determine-user-identity-on-site-master-using-asp-net-identity
        /// </summary>
        /// <param name="role">String separeted by ","</param>
        /// <returns>isUserInRole true if user is in one role at least</returns>
        public static bool IsUserInRole(string role)
        {
            string[] roles = role.Split(',');
            bool isUserInRole = false;
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(new ApplicationDbContext()));
            foreach(string ro in roles)
            {
                if (System.Threading.Thread.CurrentPrincipal.Identity.IsAuthenticated)
                {
                    try
                    {
                        if((isUserInRole = um.IsInRole(System.Threading.Thread.CurrentPrincipal.Identity.GetUserId(), ro))) break;
                    }
                    catch (System.Exception ex)
                    {
                        // Handled exception catch code
                        Helpers.Utils.SignalExceptionToElmahAndTrace(ex, null);
                    }
                }
            }
            return isUserInRole;
        }
        public bool RoleExists(string name)
        {
            var rm = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(new ApplicationDbContext()));
            return rm.RoleExists(name);
        }
        public bool CreateRole(string name)
        {
            var rm = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(new ApplicationDbContext()));
            var idResult = rm.Create(new IdentityRole(name));
            return idResult.Succeeded;
        }
        public bool CreateUser(ApplicationUser user, string password)
        {
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var idResult = um.Create(user, password);
            return idResult.Succeeded;
        }
        public bool AddUserToRole(string userId, string roleName)
        {
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var idResult = um.AddToRole(userId, roleName);
            return idResult.Succeeded;
        }
        public void ClearUserRoles(string userId)
        {
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var user = um.FindById(userId);
            var currentRoles = new List<IdentityUserRole>();
            currentRoles.AddRange(user.Roles);
            foreach (var role in currentRoles)
            {
                um.RemoveFromRole(userId, role.Role.Name);
            }
        }
    }

}