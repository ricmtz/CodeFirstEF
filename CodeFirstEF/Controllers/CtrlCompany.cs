using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstEF.Classes;

namespace CodeFirstEF.Controllers
{
    public class CtrlCompany
    {
        private HitssTMContext entities;

        public CtrlCompany()
        {
            entities = new HitssTMContext();
        }

        public bool CreateCompany(string name, string descript = "", DateTime startDate = new DateTime(), int status = 1)
        {
            var company = new Company()
            {
                Name = name,
                Description = descript,
                StartDate = startDate.Date,
                Status = status,
            };
            entities.Companies.Add(company);
            return entities.SaveChanges() > 0;
        }

        public List<Company> GetCompanies()
        {
            return entities.Companies
                .Where(c => c.Status != 0)
                .ToList();
        }

        public Company GetCompanyById(int id)
        {
            return entities.Companies.FirstOrDefault(c => c.Id == id && c.Status != 0);
        }

        public bool UpdateCompany(Company company)
        {
            var origCompany = GetCompanyById(company.Id);
            if(origCompany != null)
            {
                origCompany.Name = company.Name;
                origCompany.StartDate = company.StartDate;
                origCompany.Status = company.Status;
                origCompany.Description = company.Description;
                return entities.SaveChanges() > 0;
            }
            return false;
        }

        public bool DeleteCompany(int id)
        {
            var company = GetCompanyById(id);
            if(company != null)
            {
                company.Status = 0;
                return entities.SaveChanges() > 0;
            }
            return false;
        }
    }
}
