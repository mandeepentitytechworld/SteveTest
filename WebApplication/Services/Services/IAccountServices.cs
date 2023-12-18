using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Services.Services
{
    public interface IAccountServices
    {
        Task<Accounts> GetAccounts(int Skip, int Take, string SortColumn, string SortOrder);
    }
}
