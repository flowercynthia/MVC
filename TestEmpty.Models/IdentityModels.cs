using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace TestEmpty.Models
{
    public class UserModel : IdentityUser<int, UserLoginModel, UserRoleModel, UserClaimModel>, IUser<int>
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<UserModel, int> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
        public enum UserPreferenceLevel { Gold, Platinium, Normal }
        public UserPreferenceLevel PreferenceLevel { get; set; }

    }
    public class RoleModel : IdentityRole<int, UserRoleModel>
    {

    }
    public class UserRoleModel : IdentityUserRole<int>
    {

    }
    public class UserLoginModel : IdentityUserLogin<int>
    {

    }
    public class UserClaimModel : IdentityUserClaim<int>
    {

    }
}
