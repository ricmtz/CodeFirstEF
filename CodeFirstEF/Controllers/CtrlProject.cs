using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstEF.Classes;

namespace CodeFirstEF.Controllers
{
    class CtrlProject
    {
        private HitssTMContext entities;

        public CtrlProject()
        {
            entities = new HitssTMContext();
        }

        public bool CreateProject(string name, int clientId, string descript = "", int status = 1)
        {
            var project = new Project()
            {
                Name = name,
                Description = descript,
                Status = status,
                ClientId = clientId,
            };
            entities.Projects.Add(project);
            return entities.SaveChanges() > 0;
        }

        public List<Project> GetProjects()
        {
            return entities.Projects.Where(p => p.Status != 0).ToList();
        }

        public Project GetProjectById(int id)
        {
            return entities.Projects.FirstOrDefault(p => p.Id == id && p.Status != 0);
        }

        public bool UpdateProject(Project project)
        {
            var origProject = GetProjectById(project.Id);
            if(origProject != null)
            {
                origProject.ClientId = project.ClientId;
                origProject.Description = project.Description;
                origProject.Name = project.Name;
                origProject.Status = project.Status;
                return entities.SaveChanges() > 0;
            }
            return false;
        }

        public bool DeleteProject(int id)
        {
            var project = GetProjectById(id);
            if(project != null)
            {
                project.Status = 0;
                return entities.SaveChanges() > 0;
            }
            return false;
        }
    }
}
