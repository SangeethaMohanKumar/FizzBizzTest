// <copyright file="DivisibleBy3.cs" company="TCS">
// Copyright (c) Company. All rights reserved.
// </copyright>

namespace FizzBuzzServices.BusinessRules
{
    using System;

    /// <summary>
    /// The number must be divisible by 3
    /// </summary>
    public class DivisibleBy3 : IFizzBuzzRules
    {
        /// <summary>
        /// data picked up from config file
        /// </summary>
        private readonly string dayOfWeek;

        /// <summary>
        /// Initializes a new instance of the <see cref="DivisibleBy3"/> class
        /// </summary>
        /// <param name="dayOfWeek">day of week</param>
        public DivisibleBy3(string dayOfWeek)
        {
            this.dayOfWeek = dayOfWeek;
        }

        /// <summary>
        /// Checks if the number is divisible by 3
        /// </summary>
        /// <param name="numberSeries">Number which has to checked</param>
        /// <returns>returns true or false</returns>
        public bool CanExecute(int numberSeries)
        {
            return numberSeries % 3 == 0;
        }

        /// <summary>
        /// Executes only if the number is divisible by 3
        /// </summary>
        /// <returns>Returns a string</returns>
        public string Execute()
        {
            return (DateTime.Now.DayOfWeek.ToString() == this.dayOfWeek) ? "Wizz " : "Fizz ";
        }
    }
}
