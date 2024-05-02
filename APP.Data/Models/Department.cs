using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace APP.Data.Models
{
    public class Department: ModelBase
    {
        public string Code { get; set; }

        public string Name { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<Employee> Employess { get; set; }=new HashSet<Employee>();
    }
}
