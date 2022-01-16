using DiscreteMathematicsII_Project.Models;
using DiscreteMathematicsII_Project.Utils;
using System.Collections.Generic;

namespace DiscreteMathematicsII_Project.Services
{
    public static class BinarySearchService
    {
        public static (Person person, int comparisons) BinarySearchIterative(List<Person> inputArray, int id)
        {
            IntComparer intComparer = new IntComparer();
            int min = 0;
            int max = inputArray.Count - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (intComparer.Compare(id, inputArray[mid].Id))
                {
                    return (inputArray[mid], intComparer.Count);
                }
                else if (id < inputArray[mid].Id)
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return (null, intComparer.Count);
        }
    }
}
