using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using ViewModel;


namespace Services.Services
{
    public class AccountServices : IAccountServices
    {
        private string endPoint = "https://ifoneapiqa.azurewebsites.net/api/accounts/GetAllAccountsByLocationId/3";
        public Accounts GetAccounts(int _Skip, int _Take, string SortColumn, string SortOrder)
        {
            Accounts account = new Accounts();
            account.listAccountViewModel = new List<AccountViewModel>();

            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(endPoint);
                var response = client.GetAsync("").Result;
                var _result = response.Content.ReadAsAsync<IEnumerable<AccountViewModel>>().Result;

                account.TotalRecords = _result.Count().ToString();

                if (SortOrder == "asc")
                    account.listAccountViewModel = (_result.Where(c => c.statusKey == "Active").OrderBy(c => c.GetType().GetProperty(SortColumn).GetValue(c, null)).Skip(_Skip).Take(_Take).ToList().ToList());
                else
                    account.listAccountViewModel = (_result.Where(c => c.statusKey == "Active").OrderByDescending(c => c.GetType().GetProperty(SortColumn).GetValue(c, null)).Skip(_Skip).Take(_Take).ToList().ToList());
            }
            catch (Exception ex)
            {

                throw;
            }

            return account;
        }
    }
}
