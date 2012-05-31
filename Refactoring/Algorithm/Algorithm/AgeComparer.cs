using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm
{
    public class AgeComparer
    {
        private readonly List<Person> people;

        public AgeComparer(List<Person> people)
        {
            this.people = people;
        }

        public AgeComparison GetAgeComparison(AgeComparisonType ageComparisonType)
        {
            var ageComparisons = GetAgeComparisons(ageComparisonType);

            return ageComparisons.FirstOrDefault() ?? new AgeComparison();
        }

        private IEnumerable<AgeComparison> GetAgeComparisons(AgeComparisonType ageComparisonType)
        {
            var ageComparisons = (from firstPerson in people
                                  from secondPerson in people
                                  where firstPerson != secondPerson
                                  select new AgeComparison(firstPerson, secondPerson)).Distinct();

            return ageComparisonType == AgeComparisonType.ClosestBirthdays
                       ? ageComparisons.OrderBy(x => x.AgeDifference)
                       : ageComparisons.OrderByDescending(x => x.AgeDifference);
        }
    }
}