using APP.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Infrustructure.Data.Configrations
{
    public class EmployeeConfigration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.Name).IsRequired(true);
            builder.Property(e=>e.Adress).IsRequired(true);
            builder.Property(e=>e.Age).IsRequired(true);
            builder.Property(e => e.Salary)
               .HasColumnType("decimal(18, 2)");
            builder.Property(e => e.RowVersion).IsRowVersion();
            
        }
    }
}
