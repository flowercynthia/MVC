using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using TestEmpty.Models;

namespace TestEmpty.Filters
{
    public class PreferenceLevelAuthFilter : ActionFilterAttribute, IAuthenticationFilter
    {
        private UserModel.UserPreferenceLevel _level;
        private EmptyDbContext _dbContext;

        private EmptyDbContext DbContext
        {
            get
            {
                if (_dbContext == null)
                    _dbContext = EmptyDbContext.Create();
                return _dbContext;
            }
        }
        public PreferenceLevelAuthFilter(UserModel.UserPreferenceLevel level)
        {
            this._level = level;
        }

        public void OnAuthentication(AuthenticationContext filterContext)
        {
            var user = filterContext.Principal.Identity;
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            var user = filterContext.HttpContext.User.Identity.Name;

            var currentUser = DbContext.Users.FirstOrDefault(x => x.Email.Equals(user));

            if(currentUser != null && currentUser.PreferenceLevel != this._level)
            {
                filterContext.Result = new RedirectResult("/Home/Error");
            }
        }
    }
}