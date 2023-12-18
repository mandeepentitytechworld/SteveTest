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

        public async Task<IActionResult> Index()
        {
            var _results = await accountServices.GetAccounts(0, 40, "FirstName", "asc");
            return View(_results);
        }

        public async Task<IActionResult> GetList(int Skip = 0, int Take = 10, string SortColumn = "FirstName", string SortOrder = "desc")
        {
            var _results = await accountServices.GetAccounts(Skip, Take, SortColumn, SortOrder);
            return PartialView("_ListView", _results.listAccountViewModel);
        }
    }
}
