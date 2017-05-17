using System;
using System.Collections.Generic;

namespace BigBank
{
    public  class CustomerInfo {
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string SSNumber {get; set;}
        public string Other {get; set;}                     //Will not implement Address
    }

    public  class IndividualAccount{
        public int AccountNumber {get; set;}
        public Decimal AccountBallance {get; set;}
    }

    public  class Account  : CustomerInfo {
        public List<IndividualAccount> SavingsList {get;set;}
        public List<IndividualAccount> CheckingList {get;set;}
        public List<IndividualAccount> MutualFundList {get;set;}
        
        //Until this program connects to a database or saves to file
        //the class will handle the key values
        private int SavingsIndex {get;set;}
        private int CheckingIndex {get;set;}
        private int MutualFundIndex {get;set;}

        public Account()
        {
            this.SavingsList = new List<IndividualAccount>();
            this.CheckingList = new List<IndividualAccount>();
            this.MutualFundList = new List<IndividualAccount>();
            //Until this program connects to a database or saves to file
            //the class will handle the key values
            this.SavingsIndex = 7777000;                     
            this.CheckingIndex = 8888000;
            this.MutualFundIndex = 9999000;
        }

        public void AddSavingsAccount() {
            this.SavingsIndex++;
            IndividualAccount Acct1 = new IndividualAccount();
            Acct1.AccountBallance = 0;
            Acct1.AccountNumber = this.SavingsIndex;
            this.SavingsList.Add(Acct1);
        }
        public void DeleteSavingsAccount(int index) {
            int count = -1;
            int indexcount = -1;
            if (this.SavingsList.Count != 0) {
                foreach (IndividualAccount myAccount in this.SavingsList) {
                    count++;
                    if (myAccount.AccountNumber == index)
                        indexcount = count;
                }
                if (indexcount >=0 ) {
                    this.SavingsList.RemoveAt(indexcount);
                }
            }
        }
        public decimal SavingsBallance() {
            decimal total = 0;
            foreach (IndividualAccount myAccount in this.SavingsList) {
                total += myAccount.AccountBallance;
            }
            return total;
        }

         public void AddCheckingAccount() {
            this.CheckingIndex++;
            IndividualAccount Acct1 = new IndividualAccount();
            Acct1.AccountBallance = 0;
            Acct1.AccountNumber = this.CheckingIndex;
            this.CheckingList.Add(Acct1);
        }
        public void DeleteCheckingAccount(int index) {
            int count = -1;
            int indexcount = -1;
            if (this.CheckingList.Count != 0) {
                foreach (IndividualAccount myAccount in this.CheckingList) {
                    count++;
                    if (myAccount.AccountNumber == index)
                        indexcount = count;
                }
                if (indexcount >=0 ) {
                    this.CheckingList.RemoveAt(indexcount);
                }
            }
        }  
        public decimal ChackingBallance() {
            decimal total = 0;
            foreach (IndividualAccount myAccount in this.CheckingList) {
                total += myAccount.AccountBallance;
            }
            return total;
        }

        public void AddMutualFundAccount() {
            this.MutualFundIndex++;
            IndividualAccount Acct1 = new IndividualAccount();
            Acct1.AccountBallance = 0;
            Acct1.AccountNumber = this.MutualFundIndex;
            this.MutualFundList.Add(Acct1);
        }
        public void DeleteMutualFundAccount(int index) {
            int count = -1;
            int indexcount = -1;
            if (this.MutualFundList.Count != 0) {
                foreach (IndividualAccount myAccount in this.MutualFundList) {
                    count++;
                    if (myAccount.AccountNumber == index)
                        indexcount = count;
                }
                if (indexcount >=0 ) {
                    this.MutualFundList.RemoveAt(indexcount);
                }
            }
        }  
        public decimal MutualFundBallance() {
            decimal total = 0;
            foreach (IndividualAccount myAccount in this.MutualFundList) {
                total += myAccount.AccountBallance;
            }
            return total;
        }

        public void UpdateSavingsAccount(int index, decimal ammount)
        {
            foreach (IndividualAccount myAccount in this.SavingsList) {
                if (myAccount.AccountNumber == index)
                    myAccount.AccountBallance += ammount;
            }
        }

        public void UpdateCheckingAccount(int index, decimal ammount)
        {
            foreach (IndividualAccount myAccount in this.CheckingList) {
                if (myAccount.AccountNumber == index)
                    myAccount.AccountBallance += ammount;
            }
        }

        public void UpdateMutualFundAccount(int index, decimal ammount)
        {
            foreach (IndividualAccount myAccount in this.MutualFundList) {
                if (myAccount.AccountNumber == index)
                    myAccount.AccountBallance += ammount;
            }
        }
    }

    public  class Transactions {
        public DateTime Date {get;set;}
        public String SSNumber {get;set;}                   //Use a the Key to the Account Holder
        public String TransType {get;set;}                  //Deposit or WithDraw
        public String AcctType {get;set;}                   //Savings or Checking
        public decimal Ammount {get;set;}
    }
    class Program
    {
        static int Main(string[] args)
        {
            int option;
            int index;
            int AccountType;
            decimal Ammount;
            
            Account MyCustomer = new Account();
            int UserID = Login(MyCustomer);                         //Select the customer and set there ID
            if (UserID == 0)                                        //User selected to Quit the program
                return 0;

            do {
                option = MenuMain(MyCustomer);
                switch(option) 
                {
                    case 1: //Create an Account
                            AccountType = AccountMenu(option);
                            if (AccountType != 0)
                            {
                                if (AccountType == 1) {
                                    MyCustomer.AddSavingsAccount(); 
                                }
                                else if (AccountType == 2) {
                                    MyCustomer.AddCheckingAccount(); 
                                } 
                                else if (AccountType == 3) {
                                    MyCustomer.AddMutualFundAccount();
                                }
                            }                    
                            break;
                    case 2: //Delete an Account
                            AccountType = AccountMenu(option);
                            if (AccountType != 0){
                                if (AccountType == 1) {
                                    index = ChooseAnAccount(MyCustomer.SavingsList, "Savings","Delete"); 
                                    if (index != 0) {
                                        MyCustomer.DeleteSavingsAccount(index);
                                    }
                                }
                                else if (AccountType == 2) {
                                    index = ChooseAnAccount(MyCustomer.CheckingList, "Checking", "Delete"); 
                                    if (index != 0) {
                                        MyCustomer.DeleteCheckingAccount(index);
                                    }
                                } 
                                else if (AccountType == 3) {
                                    index = ChooseAnAccount(MyCustomer.MutualFundList, "Mutual Fund", "Delete");
                                    if (index != 0) {
                                        MyCustomer.DeleteMutualFundAccount(index);
                                    }
                                }
                            }
                            break;                           
                    case 3: //Make a deposit
                            AccountType = AccountMenu(option);
                            if (AccountType != 0){
                                if (AccountType == 1) {
                                    index = ChooseAnAccount(MyCustomer.SavingsList, "Savings","Deposit"); 
                                    if (index != 0) {
                                        Ammount = GetAnAmmount(MyCustomer.SavingsList, "Deposit", index);
                                        MyCustomer.UpdateSavingsAccount(index, Ammount);
                                    }
                                }
                                else if (AccountType == 2) {
                                    index = ChooseAnAccount(MyCustomer.CheckingList, "Checking", "Deposit"); 
                                    if (index != 0) {
                                        Ammount = GetAnAmmount(MyCustomer.CheckingList, "Deposit", index);
                                        MyCustomer.UpdateCheckingAccount(index, Ammount);
                                    }
                                } 
                                else if (AccountType == 3) {
                                    index = ChooseAnAccount(MyCustomer.MutualFundList, "Mutual Fund", "Deposit");
                                    if (index != 0) {
                                        Ammount = GetAnAmmount(MyCustomer.MutualFundList, "Deposit", index);
                                        MyCustomer.UpdateMutualFundAccount(index, Ammount);
                                    }
                                }
                            }
                            break;
                    case 4: //Withdraw Funds
                            AccountType = AccountMenu(option);
                            if (AccountType != 0){
                                if (AccountType == 1) {
                                    index = ChooseAnAccount(MyCustomer.SavingsList, "Savings", "WithDraw"); 
                                    if (index != 0) {
                                        Ammount = GetAnAmmount(MyCustomer.SavingsList, "WithDraw", index);
                                        MyCustomer.UpdateSavingsAccount(index, (Ammount*-1));
                                    }
                                }
                                else if (AccountType == 2) {
                                    index = ChooseAnAccount(MyCustomer.CheckingList, "Checking", "WithDraw"); 
                                    if (index != 0) {
                                        Ammount = GetAnAmmount(MyCustomer.CheckingList, "WithDraw", index);
                                        MyCustomer.UpdateCheckingAccount(index, (Ammount*-1));
                                    }
                                } 
                                else if (AccountType == 3) {
                                    index = ChooseAnAccount(MyCustomer.MutualFundList, "Mutual Fund", "WithDraw");
                                    if (index != 0) {
                                        Ammount = GetAnAmmount(MyCustomer.MutualFundList, "WithDraw", index);
                                        MyCustomer.UpdateMutualFundAccount(index, (Ammount*-1));
                                    }
                                }    
                            }
                            break;
                }
            } while (option != 0);

            return 0;
        }

        private static decimal GetAnAmmount(List<IndividualAccount> myList, String selection, int index)
        {
            String UserInput;
            decimal decUserInput = 0;
            bool check = true;
            decimal maxValue = 1000000;

            if ( selection == "WithDraw") {
                foreach (IndividualAccount myAccount in myList) {
                    if (myAccount.AccountNumber == index)
                        maxValue = myAccount.AccountBallance;
                }
            }

            Console.WriteLine("\t\tPlease Enter and Ammout to " + selection);

            while (check) {
                UserInput = Console.ReadLine();
                if(decimal.TryParse(UserInput, out decUserInput)) {
                    if (decUserInput >= 0 && decUserInput <= maxValue){
                        decUserInput = Math.Round(decUserInput, 2);
                        check = false;
                    }
                    else
                        Console.WriteLine("Please enter a Valid Ammount from $0 - $" + maxValue + "\t0 - will Quit");
                } 
                else
                    Console.WriteLine("Please enter a Valid Ammount from $0-$" + maxValue + "\t0 - will Quit");
            }
            return decUserInput;
        }

        private static int ChooseAnAccount(List<IndividualAccount> myList, string typeofaccount, string whattodo)
        {
            
            int count = 0;
            String UserInput;
            int intUserInput = 0;
            bool check = true;



            Console.Clear();
            Console.WriteLine("\n\n");
            Console.WriteLine("\tWelcome to Big Bank Inc.");

            
            if (myList.Count == 0) {
                Console.WriteLine("\n\tThere are no " + typeofaccount + " Accounts, Please enter 0 to Return");    
            }
            else {
                Console.WriteLine("\n\tWhich Account do you want to make a " + whattodo + "?");
                foreach (IndividualAccount myAccount in myList) {
                    count++;
                    Console.WriteLine("\t\t" + count + " - " + typeofaccount + " Account Number :" + myAccount.AccountNumber + "\tAccount Ballance :" + myAccount.AccountBallance);                                
                }
            }
            Console.WriteLine("\t\t0 - Quit");

            while (check) {
                UserInput = Console.ReadLine();
                if(int.TryParse(UserInput, out intUserInput)) {
                    if (intUserInput >= 0 && intUserInput <=count)
                        check = false;
                    else
                        Console.WriteLine("Please enter a Valid input 0-" + count);
                } 
                else
                    Console.WriteLine("Please enter a Valid input 0-" + count);
            }
            if (intUserInput == 0)
                return 0;
            else
                return myList[(intUserInput- 1)].AccountNumber;
        }

        private static int AccountMenu(int option)
        {
            string UserInput = "";
            int intUserInput = 0;
            bool check = true;
            string myOption;
            int MenuItems = 0;

            if (option == 1)
                myOption = "Adding an Account";
            else if (option == 2)
                myOption = "Deleting an Account";
            else if (option == 3)
                myOption = "Making a Deposit";
            else 
                myOption = "Withdrawing Funds";

            //Console.Clear();
            //Console.WriteLine("\n");
            //Console.WriteLine("\tWelcome to Big Bank Inc.");
            Console.WriteLine("\n\tPlease Select What account type you wish to use for :" + myOption);
            Console.WriteLine("\n\t\t1 - Savings");
            Console.WriteLine("\t\t2 - Checking");
            Console.WriteLine("\t\t3 - Mutual Fund");
            Console.WriteLine("\t\t0 - Quit");
            MenuItems = 3;

            while (check) {
                UserInput = Console.ReadLine();
                if(int.TryParse(UserInput, out intUserInput)) {
                    if (intUserInput >= 0 && intUserInput <= MenuItems)
                        check = false;
                    else
                        Console.WriteLine("Please enter a Valid input 0-" + MenuItems);
                } 
                else
                    Console.WriteLine("Please enter a Valid input 0-" + MenuItems);
            }
            return intUserInput;
        }

        static int MenuMain( Account MyCustomer) {
            string UserInput = "";
            int intUserInput = 0;
            bool check = true;
            int MenuItems = 0;

            Console.Clear();
            Console.WriteLine("\n\n");
            Console.WriteLine("\tWelcome to Big Bank Inc.");

            DisplayCustomerInfo(MyCustomer);

            Console.WriteLine("\n\tWhat would you like to do today?");
            Console.WriteLine("\n\t\t1 - Create an account");
            Console.WriteLine("\t\t2 - Delete an account");
            Console.WriteLine("\t\t3 - Make a deposit");
            Console.WriteLine("\t\t4 - Withdraw Funds");
            Console.WriteLine("\t\t0 - Quit");
            MenuItems = 4;



            while (check) {
                UserInput = Console.ReadLine();
                if(int.TryParse(UserInput, out intUserInput)) {
                    if (intUserInput >= 0 && intUserInput <= MenuItems)
                        check = false;
                    else
                        Console.WriteLine("Please enter a Valid input 0-" + MenuItems);
                } 
                else
                    Console.WriteLine("Please enter a Valid input 0-" + MenuItems);
            }
            return intUserInput;
        }

        //Login Function is not implemeted and this program does not read from a file of database
        //so we will hard code some Users
        //in the system and build the CustomerInfo Object.
        static int Login(Account MyCustomer) {
            string UserInput = "";
            int intUserInput = 0;
            bool check = true;

            Console.Clear();
            Console.WriteLine("\n\n\n\n");
            Console.WriteLine("\tLogin Not Implimented yet:");
            Console.WriteLine("\n\tPlease Choose a User?");
            Console.WriteLine("\n\t\t1 - Mike Harmond");
            Console.WriteLine("\t\t2 - Jackie Chang");
            Console.WriteLine("\t\t3 - Billy Bob");
            Console.WriteLine("\t\t0 - Quit");

            while (check) {
                UserInput = Console.ReadLine();

                if (int.TryParse(UserInput, out intUserInput)) {
                    if (intUserInput >= 0 && intUserInput <4) {
                        switch(intUserInput) 
                        {
                            case 1:
                                    MyCustomer.FirstName = "Mike";
                                    MyCustomer.LastName = "Harmond";
                                    MyCustomer.SSNumber = "111 11 1111";
                                    break;
                            case 2:
                                    MyCustomer.FirstName = "Jackie";
                                    MyCustomer.LastName = "Chang";
                                    MyCustomer.SSNumber = "222 22 2222";
                                    break;
                            case 3:
                                    MyCustomer.FirstName = "Billy";
                                    MyCustomer.LastName = "Bob";
                                    MyCustomer.SSNumber = "333 33 3333";
                                    break;
                        }
                        check = false;
                    }
                    else
                        Console.WriteLine("Please enter a Valid input 0-3");
                } 
                else 
                    Console.WriteLine("Please enter a Valid input 0-3");
            }
            return intUserInput;
        }

        static void DisplayCustomerInfo(Account MyCustomer) {

            decimal GrandTotal = 0;
            decimal Ballance = 0;

            Console.WriteLine("\n\n\tLogged in as User: " + MyCustomer.FirstName + " " + MyCustomer.LastName);

            if (MyCustomer.SavingsList.Count != 0) {
                Console.WriteLine("\n\t\tSavings Accounts:");
                foreach (IndividualAccount myAccount in MyCustomer.SavingsList) {
                    Console.WriteLine("\t\t\tAccount#: " + myAccount.AccountNumber + "\tBallance: " + myAccount.AccountBallance);
                }
                Ballance = MyCustomer.SavingsBallance();
                Console.WriteLine("\t\tTotal of all Savings Accounts: " + Ballance);
                GrandTotal += Ballance;
            }
            
            if (MyCustomer.CheckingList.Count != 0) {
                Console.WriteLine("\n\t\tChecking Accounts:");
                foreach (IndividualAccount myAccount in MyCustomer.CheckingList) {
                    Console.WriteLine("\t\t\tAccount#: " + myAccount.AccountNumber + "\tBallance: " + myAccount.AccountBallance);
                }
                Ballance = MyCustomer.ChackingBallance();
                Console.WriteLine("\t\tTotal of all Checking Accounts: " + Ballance);
                GrandTotal += Ballance;
            }

            if (MyCustomer.MutualFundList.Count != 0) {
                Console.WriteLine("\n\t\tMutual Fund Accounts:");
                foreach (IndividualAccount myAccount in MyCustomer.MutualFundList) {
                    Console.WriteLine("\t\t\tAccount#: " + myAccount.AccountNumber + "\tBallance: " + myAccount.AccountBallance);
                }
                Ballance = MyCustomer.MutualFundBallance();
                Console.WriteLine("\t\tTotal of all Mutual Fund Accounts: " + Ballance);
                GrandTotal += Ballance;
            }
            Console.WriteLine("\n\t\tGrand Total of all Accounts: $" + GrandTotal);
        }
    }
}
