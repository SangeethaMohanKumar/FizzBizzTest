// <copyright file="FizzBuzzRepository.cs" company="TCS">
// Copyright (c) Company. All rights reserved.
// </copyright>
namespace FizzBuzzServices.Repository
{    
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using BusinessRules;

    /// <summary>
    /// Repository class for fizz buzz
    /// </summary>
    public class FizzBuzzRepository : IFizzBuzzRepository
    {
        /// <summary>
        /// Interface list for fizz buzz logic
        /// </summary>
        private readonly IEnumerable<IFizzBuzzRules> fizzBuzzRules;

        /// <summary>
        /// Initializes a new instance of the <see cref="FizzBuzzRepository"/> class
        /// </summary>
        /// <param name="fizzBuzzRules">interface for the fizz buzz logic</param>
        public FizzBuzzRepository(IEnumerable<IFizzBuzzRules> fizzBuzzRules)
        {
            this.fizzBuzzRules = fizzBuzzRules;
        }

        /// <summary>
        /// Build fizz buzz logic
        /// </summary>
        /// <param name="userEnteredNumber">User Entered Number</param>
        /// <returns>returns results list</returns>
        public List<string> BuildFizzBuzzLogic(int userEnteredNumber)
        {
            var resultList = new List<string>();
            for (int number = 1; number <= userEnteredNumber; number++)
            {
                StringBuilder result = new StringBuilder();
                foreach (var fizzBuzzRule in this.fizzBuzzRules.Where(i => i.CanExecute(number)))
                {
                    result.Append(fizzBuzzRule.Execute());
                }

                var ruleOutput = string.IsNullOrEmpty(result.ToString().Trim()) ? number.ToString() : result.ToString().Trim();
                resultList.Add(ruleOutput);
            }

            return resultList;
        }
    }
}
