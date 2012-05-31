using System.Collections.Generic;
using System.Linq;

namespace Algorithm
{
    public class BirthdayComparer
    {
        private readonly List<Person> people;

        public BirthdayComparer(List<Person> people)
        {
            this.people = people;
        }

        public BirthdayComparisonPair FindBirthdayRange(Range range)
        {
            var birthdayComparisonPairs = GetBirthdayComparisonPairs();

            return GetBirthdayComparisonPairByRange(birthdayComparisonPairs, range);
        }

        private IEnumerable<BirthdayComparisonPair> GetBirthdayComparisonPairs()
        {
            return (from firstPerson in people
                    from secondPerson in people
                    where firstPerson != secondPerson
                    select new BirthdayComparisonPair(firstPerson, secondPerson)).Distinct().OrderBy(ac => ac.AgeDifference);
        }

        private BirthdayComparisonPair GetBirthdayComparisonPairByRange(IEnumerable<BirthdayComparisonPair> birthdayComparisonPairs, Range range)
        {
            var ageComparison = (range == Range.ClosestTogether
                ? birthdayComparisonPairs.FirstOrDefault()
                : birthdayComparisonPairs.LastOrDefault())
                ?? new BirthdayComparisonPair();

            return ageComparison;
        }
    }
}