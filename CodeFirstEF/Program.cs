using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstEF.Classes;
using CodeFirstEF.Views;

namespace CodeFirstEF
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var db = new HitssTMContext())
            {
                //db.Database.Initialize(true);
                /*
                */
                ViewMain view = new ViewMain();
                view.MainMenu();
                Console.ReadKey();
            }
        }
    }
}
