using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstEF.Classes
{
    public class EmployeeProject
    {
        [Key]
        public int Id { get; set; }
        public int Status { get; set; }

        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        [ForeignKey("CatRole")]
        public int CatRoleId { get; set; }
        public virtual CatRole CatRole { get; set; }
    }
}
