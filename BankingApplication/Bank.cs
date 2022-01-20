using System;
using System.Collections.Generic;
using System.Linq;

namespace BankingApplication
{
    public class Bank
    {
        private Dictionary<String,List<Account>> repository = new Dictionary<String,List<Account>>();
        public Dictionary<String,List<Account>> Repository
        {
            get
            {
                return repository;
            }
        }
        public string Name
        {
            get
            {
                return "Bank of Gujarat";
            }
        }

        public Customer CreateNewCustomer()
        {
            var customer = new Customer();
            repository.Add(customer.Customer_ID,new List<Account>());

            System.Console.WriteLine($"Customer added with id {customer.Customer_ID}.");
            return customer;
        }

        public void CreateNewAcoount(String customerid, char typeofaccount)
        {
            var account = new Account(typeofaccount);
            repository[customerid].Add(account);
            System.Console.WriteLine($"Account is created with id {account.Account_No} for customer {customerid}.");
        }

        public Account FindAccount(string acno)
        {
            var result = from accountlist in repository.Values
                         from account in accountlist
                         where account.Account_No == acno
                         select account;
            
            if(result.Count() == 0)
            {
                throw new Exception("Account not found!");
            }
            
            return result.First();
        }

        public void DisplayBalanceForAllAccounts(String custid)
        {
            if(!repository.Keys.Contains(custid))
            {
                throw new Exception("Customer not found!");
            }
            foreach(var account in repository[custid])
            {
                System.Console.WriteLine($"Balance for account {account.Account_No} is {account.Balance}.");
            }
        }
    }
}
