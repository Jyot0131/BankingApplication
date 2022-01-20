
using System;

namespace BankingApplication
{
    class Program
    {
        public static Bank bank = new Bank();
        static void Main(string[] args)
        {
            CreateCustomersAndAccounts();

            System.Console.WriteLine("1. Credit using account number");
            System.Console.WriteLine("2. Debit using account number");
            System.Console.WriteLine("3. Display balance using Account Number");
            System.Console.WriteLine("4. Display balance for all the accounts using Customer ID");
            System.Console.WriteLine("5. Display account statement using Account Number");
            System.Console.WriteLine("9. Exit");
            int ch = 0;

            while(ch != 9)
            {
                System.Console.WriteLine();
                System.Console.Write("Please make your choice : ");
                ch = int.Parse(System.Console.ReadLine());
                switch(ch)
                {
                    case 1:
                        case1();
                        break;
                    
                    case 2:
                        case2();
                        break;
                    
                    case 3:
                        case3();
                        break;
                    
                    case 4:
                        case4();
                        break;

                    case 5:
                        case5();
                        break;

                    case 9:
                        continue;
                    
                    default:
                        System.Console.WriteLine("Invalid choice !");
                        break;
                }
            }
            
        }

        private static void CreateCustomersAndAccounts()
        {
            var newcustomer = bank.CreateNewCustomer();
            bank.CreateNewAcoount(newcustomer.Customer_ID,'C');
            bank.CreateNewAcoount(newcustomer.Customer_ID,'S');
            bank.CreateNewAcoount(newcustomer.Customer_ID,'S');
        
            newcustomer = bank.CreateNewCustomer();
            bank.CreateNewAcoount(newcustomer.Customer_ID,'C');
            bank.CreateNewAcoount(newcustomer.Customer_ID,'S');

            newcustomer = bank.CreateNewCustomer();
            bank.CreateNewAcoount(newcustomer.Customer_ID,'S');
            bank.CreateNewAcoount(newcustomer.Customer_ID,'C');
            bank.CreateNewAcoount(newcustomer.Customer_ID,'S');
        }

        private static void case1()
        {
            System.Console.WriteLine("Enter Account Id");
            var acno = System.Console.ReadLine();
            System.Console.WriteLine("Enter amount");
            int val;
            bool success = int.TryParse(System.Console.ReadLine(), out val);
            if(!success)
            {
                System.Console.WriteLine("Invalid amount !");
                return;
            }
            try
            {
                bank.FindAccount(acno).Credit(val);
            }
            catch(Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
            
        }

        private static void case2()
        {
            System.Console.WriteLine("Enter Account Id");
            string acno = System.Console.ReadLine();
            System.Console.WriteLine("Enter amount");
            int val;
            bool success = int.TryParse(System.Console.ReadLine(), out val);
            if(!success)
            {
                System.Console.WriteLine("Invalid amount !");
                return;
            }
            try
            {
                bank.FindAccount(acno).Dedit(val);
            }
            catch(Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }

        private static void case3()
        {
            System.Console.WriteLine("Enter Account Id");
            var acno = System.Console.ReadLine();
            try
            {
                bank.FindAccount(acno).DisplayBalance();
            }
            catch(Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }

        private static void case4()
        {
            System.Console.WriteLine("Enter Customer Id");
            var custid = System.Console.ReadLine();
            try
            {
                bank.DisplayBalanceForAllAccounts(custid);
            }
            catch(Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }

        private static void case5()
        {
            System.Console.WriteLine("Enter Account Id");
            var acno = System.Console.ReadLine();
            try
            {
                bank.FindAccount(acno).DisplayAccountStatement();
            }
            catch(Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }

    }
}
