using System;
using System.Collections.Generic;

namespace BankingApplication
{
    public class Account
    {
        private String account_no = Guid.NewGuid().ToString().Replace("-","");

        private int transaction_id = 1;
        private List<string> transations = new();

        private int balance = (new Random()).Next(1000,2000)*100;

        private DateTime fourtransperhour;   //Max 4 transaction in an hour
        private int totaltrans = 0;

        private DateTime debit200kperhour;     //Withdrawal limit 200k per hour
        private int totaldebitedamount = 0;

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
                throw new Exception("Transaction amount should be multiple(s) of 100 !");

            if(totaltrans == 0)
                fourtransperhour = DateTime.Now;

            if(totaltrans == Constants.TRANS_PER_HOUR)
            {
                if((DateTime.Now.Subtract(fourtransperhour).TotalSeconds) < 60.0)
                {
                    throw new Exception("Transaction limit is exceeded, please try again after some time !");
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
                throw new Exception("Transaction amount should be multiple(s) of 100 !");

            if(val > 50000)
                throw new Exception("Transaction amount should be less or equal than 50k !");

            if(val > 30000)
                val += 30;

            if(val > Balance)
                throw new Exception("Not sufficient balance !");

            if(totaltrans == 0)
                fourtransperhour = DateTime.Now;

            if(totaldebitedamount == 0)
                debit200kperhour = DateTime.Now;

            if(totaltrans == Constants.TRANS_PER_HOUR)
            {
                if((DateTime.Now.Subtract(fourtransperhour).TotalSeconds) < 60.0)
                {
                    //System.Console.WriteLine("Transaction limit is exceeded, please try again after some time !");
                    //one = false;
                    //return;
                    throw new Exception("Transaction limit is exceeded, please try again after some time !");
                }
                else
                {
                    totaltrans = 0;
                    fourtransperhour = DateTime.Now;
                    //one = true;
                }
            }

            if(totaldebitedamount+val > Constants.DEBITED_AMOUNT_PERHOUR)
            {
                if((DateTime.Now.Subtract(debit200kperhour).TotalSeconds) < 60.0)
                {
                    //System.Console.WriteLine("Debit amount limit 200k per hour is exceeded, please try again after sometime !");
                    //two = false;
                    //return;
                    throw new Exception("Debit amount limit 200k per hour is exceeded, please try again after sometime !");
                }
                else
                {
                    totaldebitedamount = 0;
                    debit200kperhour = DateTime.Now;
                    //two = true;
                }
            }
            
            balance -= val;
            totaldebitedamount += val;
            totaltrans += 1;
            transations.Add($"{transaction_id++}.\t-{val}\tD\t{DateTime.Now}");
            System.Console.WriteLine($"Account is Debited with {val}, updated balance is {balance}.");
            System.Console.WriteLine($"Total Transaction {totaltrans}");

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
