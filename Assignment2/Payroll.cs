﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    //TODO: 
        //Add a menu: populate, select, save, load, exit
        //create Employee array
        //populate employee objects
        //
    class Payroll
    {
        bool empscreated = false;
        static Employee[] employeeArray = new Employee[3];

        static void Main(string[] args)
        {
            Payroll pyrll = new Payroll();
            pyrll.topMenu();
        }

        void topMenu()
        {
            int input = 0;

            while (input != 5)
            {
                Console.WriteLine("Please choose one of the following:");
                Console.WriteLine("1) Populate Employees");
                Console.WriteLine("2) Select Employee");
                Console.WriteLine("3) Load Employee Info");
                Console.WriteLine("4) Save Employee Info");
                Console.WriteLine("5) Exit");

                input = Convert.ToInt32(Console.ReadLine());

                if (input == 1)
                {
                    populateEmployee();
                }

                else if (input == 2 && empscreated == true)
                {
                    selectEmployee();
                }

                else if (input == 2 && empscreated == false)
                {
                    Console.WriteLine("Error: Employees have not yet been created.");
                }

                else if (input == 3 && empscreated == false)
                {
                    loadEmployee();
                    
                }

                else if (input == 4 && empscreated == true)
                {

                    saveEmployee();

                }

                else if (input == 5)
                {
                    int exitCode = 0;
                    Environment.Exit(exitCode);
                }

                else if (input != 1 && input != 2 && input != 3 && input != 4)
                {
                    Console.WriteLine("Invalid input, please try again.");
                }
                else Console.WriteLine("Invalid input, please try again.");
            }

            
        }

        void populateEmployee()
        {
            employeeArray[0] = new Hourly();
            employeeArray[1] = new Salary();
            employeeArray[2] = new Commission();

            empscreated = true;
        }

        void selectEmployee()
        {
            Console.WriteLine("Please enter employee 0, 1, or 2");
            //Scanner sc = new Scanner(System.in);
            int selectedIndex;
            selectedIndex = Convert.ToInt32(Console.ReadLine());
            employeeArray[selectedIndex].menu();
        }

        void saveEmployee()
        {
            System.IO.Stream FileStream = File.Create("test.xml");
            //XmlSerializer serializer = new XmlSerializer(typeof(Account[]));
            BinaryFormatter serializer = new BinaryFormatter();
            //XmlSerializer serializer = new XmlSerializer(typeof(Account[]));
            serializer.Serialize(FileStream, employeeArray);
            FileStream.Close();
        }

        void loadEmployee()
        {
            Stream FileStream = File.OpenRead("test.xml");
            //XmlSerializer deserializer = new XmlSerializer(typeof(Account[]));
            BinaryFormatter deserializer = new BinaryFormatter();
            employeeArray = (Employee[])deserializer.Deserialize(FileStream);
            FileStream.Close();
            empscreated = true;
        }
    }

    
}
