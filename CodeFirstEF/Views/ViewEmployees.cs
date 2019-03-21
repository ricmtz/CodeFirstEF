using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstEF.Controllers;

namespace CodeFirstEF.Views
{
    class ViewEmployees
    {
        private CtrlEmployee ctrlEmployee;

        public ViewEmployees()
        {
            ctrlEmployee = new CtrlEmployee();
        }

        public void MainMenu()
        {
            string op;
            Console.WriteLine("-------Employees--------");
            Console.WriteLine("1.- Create");
            Console.WriteLine("2.- Read all");
            Console.WriteLine("3.- Update");
            Console.WriteLine("4.- Delete");
            Console.WriteLine("5.- Return");
            Console.WriteLine("Select option");
            op = Console.ReadLine();
            switch (op)
            {
                case "1":
                    CreateEmployee();
                    break;
                case "2":
                    ReadAll();
                    break;
                case "3":
                case "4":
                    Console.WriteLine("Not implemented");
                    break;
                default:
                    Console.WriteLine("Not valid option");
                    break;
            }
        }

        private void CreateEmployee()
        {
            string name, lastname, mail;
            int company=1;
            Console.Clear();
            Console.WriteLine("Name:");
            name = Console.ReadLine();
            Console.WriteLine("LastName:");
            lastname = Console.ReadLine();
            Console.WriteLine("Mail:");
            mail = Console.ReadLine();
            Console.WriteLine("Company");
            int.TryParse(Console.ReadLine(), out company);
            if (ctrlEmployee.CreateEmploye(name, lastname, mail, company))
            {
                Console.WriteLine("The employee have been insertet");
            }
            else
            {
                Console.WriteLine("Upss an unexpected problem happend");
            }
        }

        private void ReadAll()
        {
            Console.Clear();
            foreach (var c in ctrlEmployee.GetEmployees())
            {
                Console.WriteLine("{0}-----{1}-----{2}", c.Id, c.FirstName, c.LastName);
            }
        }
    }
}
