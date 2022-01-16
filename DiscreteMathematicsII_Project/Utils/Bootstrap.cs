using DiscreteMathematicsII_Project.Models;
using DiscreteMathematicsII_Project.Services;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DiscreteMathematicsII_Project.Utils
{
    public class Bootstrap
    {
        public static async Task Init(int personQuantity)
        {
            await GetFirstNames();
            await GetLastNames();
            GetPersons(personQuantity);
        }

        private static async Task GetFirstNames()
        {
            Storage.FirstNames = new List<string>(await File.ReadAllLinesAsync(Constants.FirstNamesFiles));
        }

        private static async Task GetLastNames()
        {
            Storage.LastNames = new List<string>(await File.ReadAllLinesAsync(Constants.LastNamesFiles));
        }

        private static void GetPersons(int personQuantity)
        {
            PersonService personService = new PersonService();
            List<Person> persons = new List<Person>(personService.GetRandomPersons(personQuantity));
            Storage.PersonsWS = persons;
            Storage.Persons = new List<Person>(persons.OrderBy(person => person.Id));
        }
    }
}
