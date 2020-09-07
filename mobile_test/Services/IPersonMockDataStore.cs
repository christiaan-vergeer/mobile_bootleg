using mobile_test.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace mobile_test.Services
{
    public class IPerson : IPerson<Person>
    {
        readonly List<Person> persons;

        public IPerson()
        {
            persons = new List<Person>()
            {
                new Person { Id = Guid.NewGuid().ToString(), Age = 18, FirstName="Belle", LastName="Bell", Bio="Ik hou van bellen.", gender=Gender.Female, prefference=Prefference.Female},
                new Person { Id = Guid.NewGuid().ToString(), Age = 19, FirstName="Dum", LastName="Dumber", Bio="Ik Ben niet zo slim.", gender=Gender.Male, prefference=Prefference.Female}, 
                new Person { Id = Guid.NewGuid().ToString(), Age = 21, FirstName="Ambie", LastName="Bambie", Bio="Boe!", gender= Gender.Female, prefference=Prefference.Male},
                new Person { Id = Guid.NewGuid().ToString(), Age = 41, FirstName="Midlife", LastName="Crisis", Bio="Ik heb een veels te dure sport auto.", gender=Gender.Male, prefference=Prefference.Female},
                new Person { Id = Guid.NewGuid().ToString(), Age = 26, FirstName="Bier", LastName="Brouwer", Bio="Ik houdt van bier.", gender=Gender.Male, prefference=Prefference.Female},
                new Person { Id = Guid.NewGuid().ToString(), Age = 31, FirstName="Bob", LastName="Bouwer", Bio="Ik bouw shit.", gender=Gender.Male, prefference=Prefference.Male},
                new Person { Id = Guid.NewGuid().ToString(), Age = 62, FirstName="Jan", LastName="Jansen", Bio="ik ben Jan.", gender=Gender.Neutral, prefference=Prefference.Neutral}
            };
        }

        public async Task<bool> AddPersonAsync(Person person)
        {
            persons.Add(person);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdatePersonAsync(Person person)
        {
            var oldPersonItem = persons.Where((Person arg) => arg.Id == person.Id).FirstOrDefault();
            persons.Remove(oldPersonItem);
            persons.Add(person);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeletePersonAsync(string id)
        {
            var oldPersonItem = persons.Where((Person arg) => arg.Id == id).FirstOrDefault();
            persons.Remove(oldPersonItem);

            return await Task.FromResult(true);
        }

        public async Task<Person> GetPersonIDAsync(string id)
        {
            return await Task.FromResult(persons.FirstOrDefault(p => p.Id == id));
        }

        public async Task<IEnumerable<Person>> GetPersonsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(persons);
        }
    }
}
