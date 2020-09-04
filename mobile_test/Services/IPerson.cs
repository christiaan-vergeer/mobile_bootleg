using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mobile_test.Services
{
    public interface IPerson<Person>
    {
        Task<bool> AddPersonAsync(Person person);
        Task<bool> UpdatePersonAsync(Person person);
        Task<bool> DeletePersonAsync(string Id);
        Task<Person> GetPersonIDAsync(string Id);
        Task<IEnumerable<Person>> GetPersonsAsync(bool forceRefresh = false);

    }
}
