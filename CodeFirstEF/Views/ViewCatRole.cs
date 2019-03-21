using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstEF.Controllers;


namespace CodeFirstEF.Views
{
    class ViewCatRole
    {
        private CtrlCatRole ctrlCatRole;

        public ViewCatRole()
        {
            ctrlCatRole = new CtrlCatRole();
        }

        public void MainMenu()
        {
            string op;
            Console.WriteLine("-------CatRoles--------");
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
                    CreateCatRole();
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

        private void CreateCatRole()
        {
            string name, descript;
            Console.Clear();
            Console.WriteLine("Name:");
            name = Console.ReadLine();
            Console.WriteLine("Description:");
            descript = Console.ReadLine();
            if(ctrlCatRole.CreateCatRole(name, descript)){
                Console.WriteLine("The role have been insertet");
            } else {
                Console.WriteLine("Upss an unexpected problem happend");
            }
        }

        private void ReadAll()
        {
            Console.Clear();
            foreach (var c in ctrlCatRole.GetCatRoles())
            {
                Console.WriteLine("{0}-----{1}-----{2}", c.Id, c.Name, c.Status);
            }
        }
    }
}
