// <copyright file="FizzBuzzModel.cs" company="TCS">
// Copyright (c) Company. All rights reserved.
// </copyright>
namespace FizzBuzzApplication.Models
{
    using System.ComponentModel.DataAnnotations;
    using PagedList;

    /// <summary>
    /// FizzBuzzPuzzleResponse gives the response to the userFizzBuzzPuzzleResponse gives the response to the user
    /// </summary>
    public class FizzBuzzModel
    {
        /// <summary>
        /// Page Number variable
        /// </summary>
        private int pageNumber = 1;

        /// <summary>
        /// Gets or sets User Entered Number
        /// </summary>
        /// <summary>
        /// Gets or sets User Entered Number
        /// </summary>
        [Required(ErrorMessage = "Number is mandatory Field.")]
        [Range(1, 1000, ErrorMessage = "Number should be a positive integer between 1 to 1000.")]
        [RegularExpression(@"^[1-9]\d{0,3}$", ErrorMessage = "Number should be a positive integer between 1 to 1000.")]
        public int? UserEnteredNumber { get; set; }

        /// <summary>
        /// Gets or sets Fizz Buzz Result
        /// </summary>
        public IPagedList<string> FizzBuzzResult { get; set; }

        /// <summary>
        /// Gets or sets Page Number
        /// </summary>
        public int PageNumber
        {
            get
            {
                return this.pageNumber;
            }

            set
            {
                this.pageNumber = value;
            }
        }
    }
}