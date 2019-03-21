using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstEF.Classes;

namespace CodeFirstEF.Controllers
{
    public class CtrlEmployee
    {
        private HitssTMContext entities;

        public CtrlEmployee()
        {
            entities = new HitssTMContext();
        }

        public bool CreateEmploye(string firstName, string lastName, string mail,
                                int company, int status = 1, DateTime birthdate = new DateTime(),
                                DateTime startDate= new DateTime())
        {
            var employee = new Employee()
            {
                FirstName = firstName,
                LastName = lastName,
                Mail = mail,
                Status = status,
                Birthdate = birthdate,
                StartDate = startDate,
                CompanyId = company,
            };
            entities.Employees.Add(employee);
            return entities.SaveChanges() > 0;
        }

        public List<Employee> GetEmployees()
        {
            return entities.Employees.Where(e => e.Status != 0).ToList();
        }

        public Employee GetEmployeeById(int id)
        {
            return entities.Employees.FirstOrDefault(e => e.Id == id && e.Status != 0);
        }

        public bool UpdateEmployee(Employee employee)
        {
            var origEmployee = GetEmployeeById(employee.Id);
            if(origEmployee != null)
            {
                origEmployee.FirstName = employee.FirstName;
                origEmployee.LastName = employee.LastName;
                origEmployee.Mail = employee.Mail;
                origEmployee.StartDate = employee.StartDate;
                origEmployee.Status = employee.Status;
                origEmployee.Birthdate = employee.Birthdate;
                origEmployee.CompanyId = employee.CompanyId;
                return entities.SaveChanges() > 0;
            }
            return false;
        }

        public bool DeleteEmployee(int id)
        {
            var employee = GetEmployeeById(id);
            if(employee != null)
            {
                employee.Status = 0;
                return entities.SaveChanges() > 0;
            }
            return false;
        }
    }
}
