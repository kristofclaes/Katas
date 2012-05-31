using System;

namespace Algorithm
{
    public class AgeComparison : IEquatable<AgeComparison>
    {
        public Person YoungestPerson { get; private set; }
        public Person OldestPerson { get; private set; }
        public TimeSpan AgeDifference { get; private set; }

        public AgeComparison()
        {
            
        }

        public AgeComparison(Person firstPerson, Person secondPerson)
        {
            if (firstPerson.BirthDate < secondPerson.BirthDate)
            {
                YoungestPerson = firstPerson;
                OldestPerson = secondPerson;
            }
            else
            {
                YoungestPerson = secondPerson;
                OldestPerson = firstPerson;
            }

            AgeDifference = OldestPerson.BirthDate - YoungestPerson.BirthDate;
        }

        public bool Equals(AgeComparison other)
        {
            if (other == null) return false;

            return OldestPerson.Equals(other.OldestPerson) && YoungestPerson.Equals(other.YoungestPerson);
        }
    }
}