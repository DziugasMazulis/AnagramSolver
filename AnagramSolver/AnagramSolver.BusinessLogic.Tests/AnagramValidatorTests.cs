using AnagramSolver.Contracts;
using AnagramSolver.Contracts.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Shouldly;

namespace AnagramSolver.BusinessLogic.Tests
{
    public class AnagramValidatorTests
    {
        private List<EntryModel> entries;
        private IAnagramValidator anagramValidator;

        [SetUp]
        public void Setup()
        {
            entries = new List<EntryModel>()
            {
                new EntryModel { Date = new DateTime(2019, 9, 20), Word = "savas" },
                new EntryModel { Date = new DateTime(2019, 9, 22), Word = "sigis" },
                new EntryModel { Date = new DateTime(2019, 9, 28), Word = "tikėkit" },
                new EntryModel { Date = new DateTime(2019, 9, 24), Word = "diena" },
                new EntryModel { Date = new DateTime(2019, 9, 26), Word = "miestas" }
            };

            anagramValidator = new AnagramValidator(entries);
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(0, 1)]
        [TestCase(0, 2)]

        [TestCase(1, 1)]
        [TestCase(1, 2)]

        [TestCase(2, 2)]
        public void ShouldGetAllAnagramsIndexesIfAllEntriesAreAnagrams(int fromIndex, int toIndex)
        {
            List<int> anagramIndexes = anagramValidator.Validate(fromIndex, toIndex);
            anagramIndexes.Count.ShouldBe(toIndex - fromIndex + 1);
        }

        [Test]
        [TestCase(0, 0, 1)]
        [TestCase(0, 2, 3)]
        [TestCase(0, 4, 3)]

        [TestCase(2, 3, 1)]
        [TestCase(2, 4, 1)]


        [TestCase(3, 3, 0)]
        [TestCase(3, 4, 0)]

        [TestCase(4, 4, 0)]
        public void ShouldGetOnlyAnagramsIndexes(int fromIndex, int toIndex, int anagramsInRangeCount)
        {
            List<int> anagramIndexes = anagramValidator.Validate(fromIndex, toIndex);
            anagramIndexes.Count.ShouldBe(anagramsInRangeCount);
        }
    }
}
