using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestEmpty.Filters;
using TestEmpty.Models;

namespace TestEmpty.Controllers
{
    public class HomeController : Controller
    {
        private IApplicationDbContext _dbContext;
        public HomeController()
        {
            _dbContext = EmptyDbContext.Create();
        }
        public HomeController(IApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        [RouteLoggerFilter]
        [ErrorLoggerFilter]
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [RouteLoggerFilter]
        [ErrorLoggerFilter]
        public ActionResult Error()
        {
            return View("Error", new HandleErrorInfo(new Exception("Error"), "Home", "Index"));
        }
        [RouteLoggerFilter]
        [ErrorLoggerFilter]
        [PreferenceLevelAuthFilter(UserModel.UserPreferenceLevel.Gold)]
        public ActionResult Clientes()
        {
            return View(_dbContext.Clientes.ToList());
        }
    }
}