using System;
using System.Collections.Generic;

namespace HW1
{

    class Employee{
        public string Name {get;set;}
        public double Salary {get;set;}
    }
    class Program
    {

    
        static void Main(string[] args)
        {
            string enter = "";

            // (1) of the homework: Test the Area function
            Console.WriteLine("(1) Area");
            Console.WriteLine("The area of a rectangle 6 by 5 is : " + MyMultiply(6,5));
            Console.WriteLine("Enter to continue");
            enter = Console.ReadLine();

            // (2) of homework: display a Multiplication Table given an integer
            // we will ask the user for a Positive integer or 0 to quit
            Console.WriteLine("\r\n(2) Multiplication Table");

            int userIntInput = 0;
            bool success = false;
            string line = "";

            do {
                Console.WriteLine("Please enter a Positive Integer (0 to continue): ");
                line = Console.ReadLine();
                if (int.TryParse(line, out userIntInput))
                {
                    if (userIntInput >= 0)
                        success = true;
                }
             } while (!success);

             if (userIntInput > 0) {
                MultiplicationTable(userIntInput);
             }
            Console.WriteLine("Enter to continue");
            enter = Console.ReadLine();

            // (3) of the homework: Find the Max value of a Parmlist
            Console.WriteLine("\r\n(3) Maxvalue Test");
            Console.WriteLine("The Max Value of the Param list (6,2,9,34,0,24) is : " + GetMaxValue(6,2,9,34,0,24));
            Console.WriteLine("The Max Value of the Param list of nothing is : " + GetMaxValue());
            Console.WriteLine("The Max Value of the Param list with negative ints(-64, -32, -23, -73, -3, -125) is : " + GetMaxValue(-64, -32, -23, -73, -3, -125));
            Console.WriteLine("Enter to continue");
            enter = Console.ReadLine();

            // (4) Salary increase by a set persentage
            Console.WriteLine("\r\n(4) List update");
            Employee Employee1 = new Employee();
            Employee Employee2 = new Employee();
            Employee Employee3 = new Employee();
            Employee Employee4 = new Employee();
            List<Employee> MyEmployees = new List<Employee>();
            List<Employee> MyEmployeesUpdate = new List<Employee>();

            Employee1.Name = "Worker1";
            Employee1.Salary = 75000.00;
            MyEmployees.Add(Employee1);

            Employee2.Name = "Worker2";
            Employee2.Salary = 83000.00;
            MyEmployees.Add(Employee2);

            Employee3.Name = "Worker3";
            Employee3.Salary = 92500.00;
            MyEmployees.Add(Employee3);

            Employee4.Name = "Worker4";
            Employee4.Salary = 100000.00;
            MyEmployees.Add(Employee4);

            Console.WriteLine("Salary Before:");
            PrintEmployee(MyEmployees);

            int persentIncrease = 10;
            Console.WriteLine("\r\nSalary After: + " + persentIncrease + "% increase.");
            PayIncrease(MyEmployees, ref MyEmployeesUpdate, persentIncrease);
            PrintEmployee(MyEmployeesUpdate);
            
        }

        // Area function, which is just a multiplication function
        static int MyMultiply(int x, int y) {
            return x * y;
        }

        // Given an Integer n this function will diplay the n x n multiplication table. 
        static void MultiplicationTable(int x) {
            for (int i = 1; i <= x; i++) {
                for ( int j = 1; j <= x; j++) {
                    Console.Write((i*j) + "\t");
                }   
                Console.WriteLine("");
            }
        }

        // return the largest number in a list of integer parameters
        static int GetMaxValue(params int[] list){

            if (list == null  || list.Length == 0) 
                return 0;
            else  {        
                int max = list[0];
                for (int i = 1; i < list.Length; i++)
                {
                    if (list[i] > max)
                        max = list[i];
                }
                return max;
             }
        }

        // Function will take a list and create the second list with a salary increase based on the third parameter
         static void PayIncrease(List<Employee> MyEmployees, ref List<Employee> MyEmployeesUpdate, int persentRaise) {

             foreach (Employee Emp in MyEmployees){
                Employee TempEmp = new Employee();
                TempEmp.Name = Emp.Name;
                TempEmp.Salary = Emp.Salary / 100 * (100 + persentRaise);
                MyEmployeesUpdate.Add(TempEmp);
            }

        }
        
        static void PrintEmployee(List<Employee> MyEmployees) {

             foreach (Employee Emp in MyEmployees){
                Console.WriteLine("Name: " + Emp.Name + "\tSalary: " + Emp.Salary);
            }

        }

    }
}
