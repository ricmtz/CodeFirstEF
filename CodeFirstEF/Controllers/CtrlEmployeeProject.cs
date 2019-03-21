using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstEF.Classes;

namespace CodeFirstEF.Controllers
{
    class CtrlEmployeeProject
    {
        private HitssTMContext entities;

        public CtrlEmployeeProject()
        {
            entities = new HitssTMContext();
        }

        public bool CreateEmployeeProject(int catRoleId, int employeeId, int projectId, int status = 1)
        {
            var employeeProject = new EmployeeProject()
            {   
                CatRoleId = catRoleId,
                EmployeeId = employeeId,
                ProjectId = projectId,
                Status = status,
            };
            entities.EmployeeProjects.Add(employeeProject);
            return entities.SaveChanges() > 0;
        }

        public List<EmployeeProject> GetEmployeeProjects()
        {
            return entities.EmployeeProjects.Where(e => e.Status != 0).ToList();
        }

        public EmployeeProject GetEmployeeProjectById(int id)
        {
            return entities.EmployeeProjects.FirstOrDefault(e => e.Id == id && e.Status != 0);
        }

        public bool UpdateEmployeeProject(EmployeeProject employeeProject)
        {
            var origEmployeP = GetEmployeeProjectById(employeeProject.Id);
            if(origEmployeP != null)
            {
                origEmployeP.CatRoleId = employeeProject.CatRoleId;
                origEmployeP.EmployeeId = employeeProject.EmployeeId;
                origEmployeP.ProjectId = employeeProject.ProjectId;
                origEmployeP.Status = employeeProject.Status;
                return entities.SaveChanges() > 0;
            }
            return false;
        }

        public bool DeleteEmployeeProject(int id)
        {
            var employeeProj = GetEmployeeProjectById(id);
            if(employeeProj != null)
            {
                employeeProj.Status = 0;
                return entities.SaveChanges() > 0;
            }
            return false;
        }
    }
}
