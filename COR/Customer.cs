using System;

namespace COR
{
    public class Customer
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }

        public bool IsBirthday() => DateTime.Today == BirthDate.Date;
        public bool IsCompanyEmployee { get; set; }
        public bool IsLoyalCustomer { get; set; }

        public Customer(string fullName, DateTime bDate, bool isCompanyEmployee, bool isLoyalCustomer)
        {
            FullName = fullName;
            BirthDate = bDate;
            IsCompanyEmployee = isCompanyEmployee;
            IsLoyalCustomer = isLoyalCustomer;
        }
    }
}