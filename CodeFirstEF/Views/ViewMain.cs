using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstEF.Views
{
    class ViewMain
    {
        private ViewCatRole viewCatRole;
        private ViewClient viewClient;
        private ViewCompanies viewCompanies;
        private ViewEmployees ViewEmployees;
        private ViewEmployeesProjects viewEmpProj;
        private ViewProject viewProject;

        public ViewMain()
        {
            viewCatRole = new ViewCatRole();
            viewClient = new ViewClient();
            viewCompanies = new ViewCompanies();
            ViewEmployees = new ViewEmployees();
            viewEmpProj = new ViewEmployeesProjects();
            viewProject = new ViewProject();
        }

        public void MainMenu()
        {
            string op;
            Console.WriteLine("-------Hitss------");
            Console.WriteLine("1.- Roles");
            Console.WriteLine("2.- Clients");
            Console.WriteLine("3.- Companies");
            Console.WriteLine("4.- Employee");
            Console.WriteLine("5.- Employee Project");
            Console.WriteLine("6.- Project");
            Console.WriteLine("Option:");
            op = Console.ReadLine();
            switch (op)
            {
                case "1":
                    viewCatRole.MainMenu();
                    break;
                case "2":
                    viewClient.MainMenu();
                    break;
                case "3":
                    viewCompanies.MainMenu();
                    break;
                case "4":
                    ViewEmployees.MainMenu();
                    break;
                case "5":
                    viewEmpProj.MainMenu();
                    break;
                case "6":
                    viewProject.MainMenu();
                    break;
                default:
                    Console.WriteLine("Not valid option");
                    break;
            }

        }
    }
}
