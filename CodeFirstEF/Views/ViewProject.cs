using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstEF.Controllers;

namespace CodeFirstEF.Views
{
    class ViewProject
    {
        private CtrlProject ctrlProject;

        public ViewProject() {
            ctrlProject = new CtrlProject();
        }

        public void MainMenu()
        {
            string op;
            Console.WriteLine("-------Project--------");
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
                    CreateProject();
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

        private void CreateProject()
        {
            string name, descript;
            int client;
            Console.Clear();
            Console.WriteLine("Name:");
            name = Console.ReadLine();
            Console.WriteLine("Description:");
            descript = Console.ReadLine();
            Console.WriteLine("Client id:");
            int.TryParse(Console.ReadLine(), out client);
            if (ctrlProject.CreateProject(name, client, descript))
            {
                Console.WriteLine("The project have been insertet");
            }
            else
            {
                Console.WriteLine("Upss an unexpected problem happend");
            }
        }

        private void ReadAll()
        {
            Console.Clear();
            foreach (var c in ctrlProject.GetProjects())
            {
                Console.WriteLine("{0}-----{1}-----{2}", c.Id, c.Name, c.Description);
            }
        }
    }
}
