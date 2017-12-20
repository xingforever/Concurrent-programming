using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDTO;

namespace TestService
{
   public  class MyDbContext:DbContext
    {
        public MyDbContext() : base("connStr")
        {
          
        }
        public  DbSet<Person>Person { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>().ToTable("Person");
        }
    }
}
