using System;
using System.Collections.Generic;
using Xunit;

namespace Algorithm.Test
{    
    public class FinderTests
    {
        [Fact]
        public void Returns_Empty_Results_When_Given_Empty_List()
        {
            var list = new List<Person>();
            var finder = new BirthdayComparer(list);

            var result = finder.FindBirthdayRange(Range.ClosestTogether);

            Assert.Null(result.YoungestPerson);
            Assert.Null(result.OldestPerson);
        }

        [Fact]
        public void Returns_Empty_Results_When_Given_One_Person()
        {
            var list = new List<Person>() { sue };
            var finder = new BirthdayComparer(list);

            var result = finder.FindBirthdayRange(Range.ClosestTogether);

            Assert.Null(result.YoungestPerson);
            Assert.Null(result.OldestPerson);
        }

        [Fact]
        public void Returns_Closest_Two_For_Two_People()
        {
            var list = new List<Person>() { sue, greg };
            var finder = new BirthdayComparer(list);

            var result = finder.FindBirthdayRange(Range.ClosestTogether);

            Assert.Same(sue, result.YoungestPerson);
            Assert.Same(greg, result.OldestPerson);
        }

        [Fact]
        public void Returns_Furthest_Two_For_Two_People()
        {
            var list = new List<Person>() { greg, mike };
            var finder = new BirthdayComparer(list);

            var result = finder.FindBirthdayRange(Range.FurthestApart);

            Assert.Same(greg, result.YoungestPerson);
            Assert.Same(mike, result.OldestPerson);
        }

        [Fact]
        public void Returns_Furthest_Two_For_Four_People()
        {
            var list = new List<Person>() { greg, mike, sarah, sue };
            var finder = new BirthdayComparer(list);

            var result = finder.FindBirthdayRange(Range.FurthestApart);

            Assert.Same(sue, result.YoungestPerson);
            Assert.Same(sarah, result.OldestPerson);
        }

        [Fact]
        public void Returns_Closest_Two_For_Four_People()
        {
            var list = new List<Person>() { greg, mike, sarah, sue };
            var finder = new BirthdayComparer(list);

            var result = finder.FindBirthdayRange(Range.ClosestTogether);

            Assert.Same(sue, result.YoungestPerson);
            Assert.Same(greg, result.OldestPerson);
        }

        Person sue = new Person() {Name = "Sue", BirthDate = new DateTime(1950, 1, 1)};
        Person greg = new Person() {Name = "Greg", BirthDate = new DateTime(1952, 6, 1)};
        Person sarah = new Person() { Name = "Sarah", BirthDate = new DateTime(1982, 1, 1) };
        Person mike = new Person() { Name = "Mike", BirthDate = new DateTime(1979, 1, 1) };
    }
}