using System;
using System.Collections.Generic;
using System.Linq;

namespace BankingApplication
{
    public class Bank
    {
        private Dictionary<Account,Customer> accounts = new Dictionary<Account,Customer>();
        public Dictionary<Account,Customer> Accounts
        {
            get
            {
                return accounts;
            }
        }
        public string Name
        {
            get
            {
                return "Bank of Gujarat";
            }
        }

        public Customer CreateNewCustomer(char typeofaccount)
        {
            var customer = new Customer();
            var account = new Account(typeofaccount);
            accounts.Add(account, customer);
            System.Console.WriteLine($"Customer added with id {customer.Customer_ID} and A/C id is {account.Account_No}.");
            return customer;
        }

        public void CreateNewAcoount(Customer customer, char typeofaccount)
        {
            var account = new Account(typeofaccount);
            accounts.Add(account, customer);
            System.Console.WriteLine($"Account is created with id {account.Account_No} for customer {customer.Customer_ID}.");
        }

        public void DisplayAllAccountsInABank()
        {
            foreach(var account in accounts.Keys)
            {
                System.Console.WriteLine(account.Account_No);
            }
        }

        public Account FindAccount(string acno)
        {
            foreach(var account in accounts.Keys)
            {
                if(account.Account_No.Equals(acno))
                    return account;
            }
            throw new Exception("Account not found!");
        }

        public Customer FindCustomer(string custid)
        {
            foreach(var customer in accounts.Values)
            {
                if(customer.Customer_ID.Equals(custid))
                    return customer;
            }
            throw new Exception("Customer not found!");
        }

        public void DisplayBalanceForAllAccounts(String custid)
        {
            var result = from record in accounts
                         where record.Value.Customer_ID == custid
                         select (record.Key);

            if(result.Count() == 0)
                throw new Exception("Customer is not found !");

            foreach(var account in result)
            {
                System.Console.WriteLine($"Balance for account {account.Account_No} is {account.Balance}.");
            }
        }
    }
}













// using System;
// using System.Collections.Generic;

// namespace BankingApplication
// {
//     public class Bank
//     {
//         private List<Customer> customers = new List<Customer>();
//         private Dictionary<Customer,Account> accounts = new Dictionary<Customer,Account>();
//         public List<Customer> Customers
//         {
//             get
//             {
//                 return customers;
//             }
//         }
//         public string Name
//         {
//             get
//             {
//                 return "Bank of Gujarat";
//             }
//         }

//         public Customer CreateNewCustomer()
//         {
//             var customer = new Customer();
//             customers.Add(customer);
//             System.Console.WriteLine($"Customer added with id {customer.Customer_ID}");
//             return customer;
//         }

//         public void DisplayAllAccountsInABank()
//         {
//             foreach(var customer in Customers)
//             {
//                 customer.GetAllAccountsOfACustomer();
//             }
//         }

//         public Account FindAccount(string acno)
//         {
//             foreach(var customer in Customers)
//             {
//                 foreach(var account in customer.Accounts)
//                 {
//                     if(acno.Equals(account.Account_No.ToString()))
//                         return account;                        
//                 }
//             }
//             return new Account();
//         }

//         public Customer FindCustomer(string custid)
//         {
//             foreach(var customer in Customers)
//             {
//                 if(custid.Equals(customer.Customer_ID.ToString()))
//                     return customer;
//             }
//             return new Customer();
//         }
//     }
// }
