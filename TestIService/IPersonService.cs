using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDTO;

namespace TestIService
{
    public  interface IPersonService
    {

        Task<long> AddAsync(string name,int age);
        Task DeleteByIdAsync(int  i);
        Task<long> Edit(string name, int age);
        Task<Person> GetByIdAsync(long id);
        Task< IEnumerable< Person>> GetaLL();

    }
}
