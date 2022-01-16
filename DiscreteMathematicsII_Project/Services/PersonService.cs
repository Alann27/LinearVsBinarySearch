using DiscreteMathematicsII_Project.Models;
using DiscreteMathematicsII_Project.Utils;
using System;
using System.Collections.Generic;

namespace DiscreteMathematicsII_Project.Services
{
    public class PersonService
    {
        public IEnumerable<Person> GetRandomPersons(int quantity)
        {
            int idLimit = Constants.idLimit + 1;

            int[] auxPersons = new int[idLimit];

            Random random = new Random();

            Person[] persons = new Person[quantity];

            for (int i = 0; i < quantity; i++)
            {
                int id = random.Next(1, idLimit);
                bool isIdUnique = auxPersons[id] == 0;

                while (!isIdUnique)
                {
                    id = random.Next(1, idLimit);
                    isIdUnique = auxPersons[id] == 0;
                }

                auxPersons[id] = id;

                persons[i] = new Person
                {
                    Id = id,
                    FirstName = Storage.FirstNames[random.Next(0, Storage.FirstNames.Count)],
                    LastName = Storage.LastNames[random.Next(0, Storage.LastNames.Count)],
                    Cellphone = $"{random.Next(100,999)}-{random.Next(100, 999)}-{random.Next(1000, 9999)}"
                };
            }

            return persons;
        }

        public (Person person, int comparisons) GetPersonWithBinary(int id)
        {
            return BinarySearchService.BinarySearchIterative(Storage.Persons, id);
        }

        public (Person person, int comparisons) GetPersonWithLinear(int id)
        {
            IntComparer intComparer = new IntComparer();
            for (int i = 0; i < Storage.PersonsWS.Count; i++)
            {
                if (intComparer.Compare(id, Storage.PersonsWS[i].Id))
                {
                    return (Storage.PersonsWS[i], intComparer.Count);
                }
            }

            return (null, intComparer.Count);
        }
    }
}
