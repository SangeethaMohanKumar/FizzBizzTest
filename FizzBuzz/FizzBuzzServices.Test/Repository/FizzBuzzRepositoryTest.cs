// <copyright file="FizzBuzzRepositoryTest.cs" company="TCS">
// Copyright (c) Company. All rights reserved.
// </copyright>

namespace FizzBuzzServices.Test.Repository
{
    using System.Collections.Generic;
    using FizzBuzzServices.BusinessRules;
    using FizzBuzzServices.Repository;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// Fizz Buzz Repository Test
    /// </summary>
    [TestFixture]
    public class FizzBuzzRepositoryTest
    {
        /// <summary>
        /// FizzBuzzRepository class instance
        /// </summary>
        private readonly IFizzBuzzRepository fizzBuzzRepository;

        /// <summary>
        /// Interface for fizz buzz rules
        /// </summary>
        private readonly IEnumerable<IFizzBuzzRules> fizzBuzzRulesList;

        /// <summary>
        /// Initializes a new instance of the <see cref="FizzBuzzRepositoryTest"/> class
        /// </summary>
        public FizzBuzzRepositoryTest()
        {
            var mockDivisibleBy3Rule = new Mock<IFizzBuzzRules>();
            mockDivisibleBy3Rule.Setup(x => x.CanExecute(It.Is<int>(number => number % 3 == 0))).Returns(true);
            mockDivisibleBy3Rule.Setup(x => x.Execute()).Returns("Fizz ");
            var mockDivisibleBy5Rule = new Mock<IFizzBuzzRules>();
            mockDivisibleBy5Rule.Setup(x => x.CanExecute(It.Is<int>(number => number % 5 == 0))).Returns(true);
            mockDivisibleBy5Rule.Setup(x => x.Execute()).Returns("Buzz");
            this.fizzBuzzRulesList = new List<IFizzBuzzRules>()
            {
                mockDivisibleBy3Rule.Object,
                mockDivisibleBy5Rule.Object
            };

            this.fizzBuzzRepository = new FizzBuzzRepository(this.fizzBuzzRulesList);
        }

        /// <summary>
        /// FizzBuzzRepository Test
        /// </summary>
        [Test]
        public void BuildFizzBuzzTest()
        {
            List<string> resultList = this.fizzBuzzRepository.BuildFizzBuzzLogic(20);
            Assert.AreEqual(20, resultList.Count);
            Assert.AreEqual("1", resultList[0]);
            Assert.AreEqual("2", resultList[1]);
            Assert.AreEqual("Fizz", resultList[2]);
            Assert.AreEqual("Buzz", resultList[4]);
            Assert.AreEqual("Fizz Buzz", resultList[14]);
        }
    }
}
