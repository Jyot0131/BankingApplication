using System;

namespace BankingApplication
{
    public class Customer
    {

        private String customer_id = Guid.NewGuid().ToString().Replace("-","");

        public String Customer_ID
        {
            get
            {
                return customer_id;
            }
        }

    }
}













// using System;
// using System.Collections.Generic;

// namespace BankingApplication
// {
//     public class Customer
//     {
//         private List<Account> accounts = new List<Account>();
//         // private Dictionary<Customer,Account> accounts = new Dictionary<Customer,Account>();

//         public List<Account> Accounts
//         {
//             get
//             {
//                 return accounts;
//             }
//         }

//         private Guid customer_id = Guid.NewGuid();

//         public Guid Customer_ID
//         {
//             get
//             {
//                 return customer_id;
//             }
//         }

//         public void CreateNewAcoount()     
//         {
//             var account = new Account();
//             accounts.Add(account);
//             System.Console.WriteLine($"New Account is created with a/c no {account.Account_No} for Customer {Customer_ID}.");
//         }

//         public void DisplayBalance()
//         {
//             foreach(var account in accounts)
//             {                
//                 System.Console.WriteLine($"Available balance with account {account.Account_No} is {account.Balance}");
//             }
//             System.Console.Write(".");
//         }

//         public void GetAllAccountsOfACustomer()
//         {
//             System.Console.WriteLine($"Accounts Associated with Customer {customer_id} are");
//             foreach(var account in accounts)
//             {
//                 System.Console.WriteLine($"Account no. {account}");
//             }
//         }
//     }
// }
