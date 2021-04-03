// <copyright file="IFizzBuzzRepository.cs" company="TCS">
// Copyright (c) Company. All rights reserved.
// </copyright>
namespace FizzBuzzServices.Repository
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface for the fizz buzz repository
    /// </summary>
    public interface IFizzBuzzRepository
    {
        /// <summary>
        /// Build fizz buzz logic
        /// </summary>
        /// <param name="userEnteredNumber">User Entered Number</param>
        /// <returns>returns results list</returns>
        List<string> BuildFizzBuzzLogic(int userEnteredNumber);
    }
}
