using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDTO;
using TestIService;

namespace TestService
{
    public class PersonService : IPersonService
    {
        public async Task<long> AddAsync(string name, int age)
        {
            using (MyDbContext ctx=new MyDbContext ())
            {
                Person p = new TestDTO.Person();
                p.Age = age;
                p.Name = name;
                ctx.Person.Add(p);
              await   ctx.SaveChangesAsync();
             
                return p.Id;
            }
          


            
        }

        public Task DeleteByIdAsync(int i)
        {
            throw new NotImplementedException();
        }

        public Task<long> Edit(string name, int age)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Person>> GetaLL()
        {
            using (MyDbContext ctx = new MyDbContext())
            {
                List<Person> Persons = new List<Person>();
                
                foreach (var item in ctx.Person)
                {
                    Person d = new Person();
                    d.Id = item.Id;
                    d.Name = item.Name;
                    d.Age = item.Age;
                    Persons.Add(d);

                }
                
                   
                
                return Persons ;

            }
        }

        public async Task<Person> GetByIdAsync(long id)
        {
            using (MyDbContext ctx = new MyDbContext())
            {
                Person p1 = ctx.Person.Where(p => p.Id == id).FirstOrDefault();
                return p1;
              
            }
        }
    }
}
