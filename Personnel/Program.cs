using System;
using System.Collections.Generic;
using System.Linq;

namespace Personnel
{
    class Person
    {
        string name;
        int salary;

        public Person(string _name = "", int _salary = 0)
        {
            name = _name;
            salary = _salary;
        }

        public string getName()
        {
            return name;
        }

        public int getSalary()
        {
            return salary;
        }
        
        public bool setName(string str)
        {
            // simple error checking in input string.
            if (string.IsNullOrEmpty(str))
                return false;
           
            if (str.Any(char.IsDigit))
                return false;

            name = str;
            return true;

        }

        public bool setSalary(int number)
        {
            //no error checking so sar...
            salary = number;
            return true;  
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var personnelRegister = new List<Person>();
            int choice = 3; //input by user. some random default 
            string name = "";
            int salary = 0;

            while (choice != 0)
            {
                Console.WriteLine("Press 1 for creating new personnel entry");
                Console.WriteLine("Press 2 for viewing the personnel list");
                Console.WriteLine("Press 0 for exit...");
                Console.WriteLine("Please enter your choice...");
                choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    Console.WriteLine("Enter name");
                    name = Console.ReadLine();
                    if (string.IsNullOrEmpty(name) || name.Any(char.IsDigit))
                    {
                        Console.WriteLine("Invalid name. Try again!");
                        continue;
                    }

                    Console.WriteLine("Enter salary");
                    if (!int.TryParse(Console.ReadLine(), out salary))  //so far just skip the whole entry and ask user to reenter name also...can be improved..
                    {
                        Console.WriteLine("Invalid salary. Try again!");
                        continue;
                    }

                    personnelRegister.Add(new Person(name, salary));

                }
                else if (choice == 2)
                {
                    Console.WriteLine("Name Salary");
                    foreach (var person in personnelRegister)
                    {
                        Console.WriteLine(person.getName() + "  " + person.getSalary());
                    }
                }

                else if (choice == 0)
                {
                    break; //exit the program...
                }
                else //invalid input
                {
                    Console.WriteLine("Please enter valid choice");
                }
            }



            Console.WriteLine("Please input Personnel Name (First,Last)");
        }
    }
}
