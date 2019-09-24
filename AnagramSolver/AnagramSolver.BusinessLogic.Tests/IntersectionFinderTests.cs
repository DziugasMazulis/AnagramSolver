using AnagramSolver.Contracts;
using AnagramSolver.Contracts.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Shouldly;

namespace AnagramSolver.BusinessLogic.Tests
{
    public class IntersectionFinderTests
    {
        private List<EntryModel> entries;
        private IIntersectionFinder intersectionFinder;

        [SetUp]
        public void Setup()
        {
            entries = new List<EntryModel>()
            {
                new EntryModel { Date = new DateTime(2019, 9, 20), Word = "savas" },
                new EntryModel { Date = new DateTime(2019, 9, 22), Word = "sigis" },
                new EntryModel { Date = new DateTime(2019, 9, 24), Word = "diena" },
                new EntryModel { Date = new DateTime(2019, 9, 26), Word = "miestas" },
                new EntryModel { Date = new DateTime(2019, 9, 28), Word = "tikėkit" }
            };

            intersectionFinder = new IntersectionFinder(entries);
        }

        [Test]
        [TestCase("2019-09-18", "2019-09-19")]
        [TestCase("2019-09-29", "2019-09-30")]
        [TestCase("2019-09-21", "2019-09-21")]
        public void IndexesShouldBeNullIfDontIntersect(DateTime fromDate, DateTime toDate)
        {
            int[] indexes = intersectionFinder.FindEntries(fromDate, toDate);
            indexes.ShouldBe(null);
        }

        [Test]
        [TestCase("2019-09-20", "2019-09-20")]
        [TestCase("2019-09-20", "2019-09-21")]

        [TestCase("2019-09-22", "2019-09-22")]
        [TestCase("2019-09-21", "2019-09-22")]
        [TestCase("2019-09-22", "2019-09-23")]

        [TestCase("2019-09-27", "2019-09-28")]
        [TestCase("2019-09-28", "2019-09-28")]
        public void IndexesShouldBeEqualIfDatesInRangeAndOneEntryIntersect(DateTime fromDate, DateTime toDate)
        {
            int[] indexes = intersectionFinder.FindEntries(fromDate, toDate);
            indexes.ShouldNotBe(null);
            indexes[0].ShouldBe(indexes[1]);
        }

        [Test]
        [TestCase("2019-09-20", "2019-09-22", 2)]
        [TestCase("2019-09-20", "2019-09-23", 2)]
        [TestCase("2019-09-20", "2019-09-24", 3)]

        [TestCase("2019-09-22", "2019-09-24", 2)]
        [TestCase("2019-09-22", "2019-09-25", 2)]
        [TestCase("2019-09-22", "2019-09-26", 3)]

        [TestCase("2019-09-24", "2019-09-28", 3)]
        [TestCase("2019-09-25", "2019-09-28", 2)]
        [TestCase("2019-09-26", "2019-09-28", 2)]
        public void IndexesDifferenceShouldBeEqualToIntersectingEntryCountIfDatesInRange(DateTime fromDate, DateTime toDate, int intersectingEntryCount)
        {
            int[] indexes = intersectionFinder.FindEntries(fromDate, toDate);
            indexes.ShouldNotBe(null);
            (indexes[1] - indexes[0] + 1).ShouldBe(intersectingEntryCount);
        }

        [Test]
        [TestCase("2019-09-19", "2019-09-20")]
        [TestCase("2019-09-19", "2019-09-28")]
        [TestCase("2019-09-19", "2019-09-30")]
        public void FirstIndexShouldBeEqualToZeroIfFirstDateNotInRange(DateTime fromDate, DateTime toDate)
        {
            int[] indexes = intersectionFinder.FindEntries(fromDate, toDate);
            indexes.ShouldNotBe(null);
            indexes[0].ShouldBe(0);
        }

        [Test]
        [TestCase("2019-09-19", "2019-09-30")]
        [TestCase("2019-09-20", "2019-09-30")]
        [TestCase("2019-09-28", "2019-09-30")]
        public void SecondIndexPlusOneShouldBeEqualToEntriesCountIfSecondDateNotInRange(DateTime fromDate, DateTime toDate)
        {
            int[] indexes = intersectionFinder.FindEntries(fromDate, toDate);
            indexes.ShouldNotBe(null);
            (indexes[1] + 1).ShouldBe(entries.Count);
        }
    }
}
