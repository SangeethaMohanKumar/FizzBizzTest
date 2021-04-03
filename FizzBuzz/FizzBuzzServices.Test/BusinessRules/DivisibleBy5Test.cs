// <copyright file="DivisibleBy5Test.cs" company="TCS">
// Copyright (c) Company. All rights reserved.
// </copyright>
namespace FizzBuzzServices.Test.BusinessRules
{
    using System;
    using System.Configuration;
    using FizzBuzzServices.BusinessRules;
    using NUnit.Framework;

    /// <summary>
    /// DivisibleBy5 class Test
    /// </summary>
    [TestFixture]
    public class DivisibleBy5Test
    {
        /// <summary>
        /// DivisibleBy5 class instance
        /// </summary>
        private readonly IFizzBuzzRules divisibleBy5;

        /// <summary>
        /// Initializes a new instance of the <see cref="DivisibleBy5Test"/> class
        /// </summary>
        public DivisibleBy5Test()
        {
            this.divisibleBy5 = new DivisibleBy5("Wednesday");
        }

        /// <summary>
        /// DivisibleBy5 class CanExecute Tests
        /// </summary>
        /// <param name="input">input data</param>
        /// <param name="expectedResult">expected result</param>
        [TestCase(5, true)]
        [TestCase(4, false)]
        public void DivisibleBy5CanExecuteTest(int input, bool expectedResult)
        {
            var actualResult = this.divisibleBy5.CanExecute(input);
            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// DivisibleBy5 class Execute Test
        /// </summary>
        /// <param name="dayOfWeek">day Of Week</param>
        [TestCase("Wednesday")]
        public void DivisibleBy5ExecuteTest(string dayOfWeek)
        {
            string result = this.divisibleBy5.Execute();
            Assert.AreNotEqual(string.Empty, result);
            Assert.AreEqual(DateTime.Now.DayOfWeek.ToString() == dayOfWeek ? "Wuzz" : "Buzz", result);
        }
    }
}
