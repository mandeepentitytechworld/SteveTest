using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Services;

namespace WebApplication.Controllers
{
    public class AccountController : Controller
    {
        private IAccountServices accountServices;
        public AccountController(IAccountServices accountServices)
        {
            this.accountServices = accountServices;
        }

        public IActionResult Index()
        {
            var _results = accountServices.GetAccounts(0, 40, "FirstName", "asc");
            return View(_results);
        }

        public IActionResult GetList(int Skip, int Take, string SortColumn, string SortOrder)
        {
            var _results = accountServices.GetAccounts(Skip, Take, SortColumn, SortOrder);
            return PartialView("_ListView", _results.listAccountViewModel);
        }
    }
}
