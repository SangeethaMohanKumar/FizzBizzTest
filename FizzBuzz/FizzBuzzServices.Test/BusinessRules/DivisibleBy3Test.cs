// <copyright file="DivisibleBy3Test.cs" company="TCS">
// Copyright (c) Company. All rights reserved.
// </copyright>
namespace FizzBuzzServices.Test.BusinessRules
{
    using System;
    using System.Configuration;
    using FizzBuzzServices.BusinessRules;
    using NUnit.Framework;

    /// <summary>
    /// DivisibleBy3 class test
    /// </summary>
    [TestFixture]
    public class DivisibleBy3Test
    {
        /// <summary>
        /// DivisibleBy3 class instance
        /// </summary>
        private readonly IFizzBuzzRules divisibleBy3;

        /// <summary>
        /// Initializes a new instance of the <see cref="DivisibleBy3Test"/> class
        /// </summary>
        public DivisibleBy3Test()
        {
            this.divisibleBy3 = new DivisibleBy3("Wednesday");
        }

        /// <summary>
        /// DivisibleBy3 class CanExecute Test        
        /// </summary>
        /// <param name="input">input data</param>
        /// <param name="expectedResult">expected result</param>
        [TestCase(3, true)]
        [TestCase(4, false)]
        public void DivisibleBy3CanExecuteTest(int input, bool expectedResult)
        {
            var actualResult = this.divisibleBy3.CanExecute(input);
            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// DivisibleBy3 class Execute Test
        /// </summary>
        /// <param name="dayOfWeek">day Of Week</param>
        [TestCase("Wednesday")]
        public void DivisibleBy3ExecuteTest(string dayOfWeek)
        {
            string result = this.divisibleBy3.Execute();
            Assert.AreNotEqual(string.Empty, result);
            Assert.AreEqual(DateTime.Now.DayOfWeek.ToString() == dayOfWeek ? "Wizz " : "Fizz ", result);
        }
    }
}
