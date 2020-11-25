using System;
using System.Collections.Generic;

namespace ViewModel
{
    public class Accounts
    {
        public string TotalRecords { get; set; }
        public List<AccountViewModel> listAccountViewModel { get; set; }
    }
    public class AccountViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string StartDate { get; set; }
        public string statusKey { get; set; }
    }
}
