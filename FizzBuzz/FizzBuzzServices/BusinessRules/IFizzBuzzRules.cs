// <copyright file="IFizzBuzzRules.cs" company="TCS">
// Copyright (c) Company. All rights reserved.
// </copyright>

namespace FizzBuzzServices.BusinessRules
{
    /// <summary>
    /// Interface for the Fizz Buzz Logic
    /// </summary>
    public interface IFizzBuzzRules
    {
        /// <summary>
        /// Checks if the condition is true
        /// </summary>
        /// <param name="numberSeries">Number to be checked</param>
        /// <returns>Returns true or false</returns>
        bool CanExecute(int numberSeries);

        /// <summary>
        /// Executes the method only if CanExecute is true
        /// </summary>
        /// <returns>returns the string</returns>
        string Execute();
    }
}
