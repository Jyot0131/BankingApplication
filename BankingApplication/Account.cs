using System;
using System.Collections.Generic;

namespace BankingApplication
{
    public class Account
    {
        private String account_no = Guid.NewGuid().ToString().Replace("-","");

        private int transaction_id = 1;
        private List<string> transations = new();

        private int balance = (int.MaxValue)/2;

        private DateTime fourtransperhour;   //Max 4 transaction in an hour4
        private int totaltrans = 0;

        private DateTime debit200kperhour;     //Withdrawal limit 200k per hour
        private int totaldebitedamount = 0;

        private bool one = true;
        private bool two = true;

        private char typeofaccount;

        public Account(char typeofaccount)
        {
            this.typeofaccount = typeofaccount;
        }

        public char TypeOfAccount
        {
            get
            {
                return typeofaccount;
            }
        }
        public String Account_No
        {
            get
            {
                return account_no;
            }
        }

        public int Balance
        {
            get
            {
                return balance;
            }
        }

        public void Credit(int val)
        {
            if(val%100 != 0)
            {
                System.Console.WriteLine("Transaction amount should be multiple(s) of 100 !");
                return;
            }

            if(totaltrans == 0)
            {
                fourtransperhour = DateTime.Now;
            }

            if(totaltrans == 4)
            {
                if((DateTime.Now.Subtract(fourtransperhour).TotalSeconds) < 240.0/4)
                {
                    System.Console.WriteLine("Transaction limit is exceeded, please try again after some time !");
                    return;
                }
                else
                {
                    totaltrans = 0;
                    fourtransperhour = DateTime.Now;
                }
            }
            balance += val;
            totaltrans += 1;
            transations.Add($"{transaction_id++}.\t+{val}\tC\t{DateTime.Now}");
            System.Console.WriteLine($"Account is Credited with {val}, updated balance is {balance}.");
            System.Console.WriteLine($"Total Transaction {totaltrans}");
        }

        public void Dedit(int val)
        {
            if(val%100 != 0)
            {
                System.Console.WriteLine("Transaction amount should be multiple(s) of 100 !");
                return;
            }
            if(val > 50000)
            {
                System.Console.WriteLine("Transaction amount should be less or equal than 50k !");
                return;
            }

            if(totaltrans == 0)
            {
                fourtransperhour = DateTime.Now;
            }
            if(totaldebitedamount == 0)
            {
                debit200kperhour = DateTime.Now;
            }

            if(totaltrans == 4)
            {
                if((DateTime.Now.Subtract(fourtransperhour).TotalSeconds) < 240.0/4)
                {
                    System.Console.WriteLine("Transaction limit is exceeded, please try again after some time !");
                    one = false;
                    return;
                }
                else
                {
                    totaltrans = 0;
                    fourtransperhour = DateTime.Now;
                    one = true;
                }
            }

            if(totaldebitedamount+val > 200000)
            {
                if((DateTime.Now.Subtract(debit200kperhour).TotalSeconds) < 240.0/4)
                {
                    System.Console.WriteLine("Debit amount limit 200k per hour is exceeded, please try again after sometime !");
                    two = false;
                    return;
                }
                else
                {
                    totaldebitedamount = 0;
                    debit200kperhour = DateTime.Now;
                    two = true;
                }
            }
            
            if(one && two)
            {
                balance -= val;
                totaldebitedamount += val;
                totaltrans += 1;
                transations.Add($"{transaction_id++}.\t-{val}\tD\t{DateTime.Now}");
                System.Console.WriteLine($"Account is Debited with {val}, updated balance is {balance}.");
                System.Console.WriteLine($"Total Transaction {totaltrans}");
            }
        }

        public void DisplayBalance()
        {
            System.Console.WriteLine($"Available balance with account {Account_No} is {Balance}.");
        }

        public void DisplayAccountStatement()
        {
            if(transations.Count == 0)
            {
                System.Console.WriteLine("Transaction records not found !");
                return;
            }
            System.Console.WriteLine($"Id\tAmount\tC/D\tTime");
            foreach(var transaction in transations)
            {
                System.Console.WriteLine(transaction);
            }
        }
    }
}
