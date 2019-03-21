using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstEF.Classes;

namespace CodeFirstEF.Controllers
{
    class CtrlCatRole
    {
        private HitssTMContext entities;

        public CtrlCatRole()
        {
            entities = new HitssTMContext();
        }

        public bool CreateCatRole(string name, string descript = "", int status = 1)
        {
            var catRole = new CatRole() {
                Name = name,
                Description = descript,
                Status = status,
            };
            entities.CatRoles.Add(catRole);
            return entities.SaveChanges() > 0;
        }

        public List<CatRole> GetCatRoles()
        {
            return entities.CatRoles.Where(c => c.Status != 0).ToList();
        }

        public CatRole GetCatRoleById(int id)
        {
            return entities.CatRoles.FirstOrDefault(c => c.Id == id && c.Status != 0);
        }

        public bool UpdateCatRole(CatRole catRole)
        {
            var origCatRole = GetCatRoleById(catRole.Id);
            if(origCatRole != null)
            {
                origCatRole.Name = catRole.Name;
                origCatRole.Status = catRole.Status;
                origCatRole.Description = catRole.Description;
                return entities.SaveChanges() > 0;
            }
            return false;
        }

        public bool DeleteCatRole(int id)
        {
            var catRole = GetCatRoleById(id);
            if(catRole != null)
            {
                catRole.Status = 0;
                return entities.SaveChanges() > 0;
            }
            return false;
        }
    }
}
