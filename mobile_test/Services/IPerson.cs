using mobile_test.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mobile_test.Services
{
    public interface IPerson<p>
    {
        Task<bool> AddPersonAsync(p person);
        Task<bool> UpdatePersonAsync(p person);
        Task<bool> DeletePersonAsync(string Id);
        Task<p> GetPersonIDAsync(string Id);
        Task<IEnumerable<p>> GetPersonsAsync(bool forceRefresh = false);

    }
}
