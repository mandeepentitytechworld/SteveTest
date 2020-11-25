using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace Services.Services
{
    public interface IAccountServices
    {
        Accounts GetAccounts(int Skip, int Take, string SortColumn, string SortOrder);
    }
}
