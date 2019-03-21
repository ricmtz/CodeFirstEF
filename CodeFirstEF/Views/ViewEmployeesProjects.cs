using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstEF.Controllers;

namespace CodeFirstEF.Views
{
    class ViewEmployeesProjects
    {
        private CtrlEmployeeProject ctrlEmpProj;

        public ViewEmployeesProjects()
        {
            ctrlEmpProj = new CtrlEmployeeProject();
        }

        public void MainMenu()
        {
            string op;
            Console.WriteLine("-------EmployeesProject--------");
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
                    CreateEmpProj();
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

        private void CreateEmpProj()
        {
            int project, employee, catrole;
            Console.Clear();
            Console.WriteLine("Project:");
            int.TryParse(Console.ReadLine(), out project);
            Console.WriteLine("Employee:");
            int.TryParse(Console.ReadLine(), out employee);
            Console.WriteLine("Role:");
            int.TryParse(Console.ReadLine(), out catrole);
            if (ctrlEmpProj.CreateEmployeeProject(catrole, employee, project))
            {
                Console.WriteLine("The EmployeeProject have been insertet");
            }
            else
            {
                Console.WriteLine("Upss an unexpected problem happend");
            }
        }

        private void ReadAll()
        {
            Console.Clear();
            foreach (var c in ctrlEmpProj.GetEmployeeProjects())
            {
                Console.WriteLine("{0}-----{1}-----{2}-----{3}", c.Id, c.CatRoleId, c.EmployeeId, c.ProjectId);
            }
        }
    }
}
