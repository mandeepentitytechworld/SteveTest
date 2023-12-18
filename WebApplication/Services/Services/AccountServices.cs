using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ViewModel;


namespace Services.Services
{
    public class AccountServices : IAccountServices
    {
        private string endPoint = "https://ifoneapiqa.azurewebsites.net/api/accounts/GetAllAccountsByLocationId/3";
        public async Task<Accounts> GetAccounts(int _Skip, int _Take, string SortColumn, string SortOrder)
        {
            Accounts account = new Accounts();
            account.listAccountViewModel = new List<AccountViewModel>();

            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Accept", "*/*");

                    var request = new HttpRequestMessage(HttpMethod.Get, this.endPoint);

                    var response = await client.SendAsync(request);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var resultString = await response.Content.ReadAsStringAsync();
                        var _result = JsonConvert.DeserializeObject<List<AccountViewModel>>(resultString);
                        if (SortOrder == "asc")
                            account.listAccountViewModel = (_result.Where(c => c.statusKey == "Active").OrderBy(c => c.GetType().GetProperty(SortColumn).GetValue(c, null)).Skip(_Skip).Take(_Take).ToList().ToList());
                        else
                            account.listAccountViewModel = (_result.Where(c => c.statusKey == "Active").OrderByDescending(c => c.GetType().GetProperty(SortColumn).GetValue(c, null)).Skip(_Skip).Take(_Take).ToList().ToList());

                    }
                    else
                    {
                        throw new Exception("custom message");
                    }
                }



                //HttpClient client = new HttpClient();
                //client.BaseAddress = new Uri(endPoint);
                //var response = client.GetAsync("").Result;
                //var _result = response.Content.ReadAsAsync<List<AccountViewModel>>().Result;

                //account.TotalRecords = _result.Count().ToString();

                }
            catch (Exception ex)
            {

                throw;
            }

            return account;
        }
    }
}
