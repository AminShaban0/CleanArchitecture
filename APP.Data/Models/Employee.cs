using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Data.Models
{
    public class Employee:ModelBase
    {
        public string Name { get; set; }

        public int Age { get; set; }
        public string Adress { get; set; }

        public decimal Salary { get; set; }

        public string Phone { get; set; }
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }
        //[Timestamp]
        public byte[] RowVersion { get; set; }


    }
}
