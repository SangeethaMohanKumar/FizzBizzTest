// <copyright file="FizzBuzzController.cs" company="TCS">
// Copyright (c) Company. All rights reserved.
// </copyright>
namespace FizzBuzzApplication.Controllers
{
    using System.Web.Mvc;
    using FizzBuzzServices.Repository;
    using Models;
    using PagedList;

    /// <summary>
    /// Fizz Buzz Logic Controller
    /// </summary>
    public class FizzBuzzController : Controller
    {
        /// <summary>
        /// Interface of the repository to get the data for this controller
        /// </summary>
        private readonly IFizzBuzzRepository fizzBuzzRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="FizzBuzzController"/> class
        /// </summary>
        /// <param name="fizzBuzzRepository">Repository Interface</param>
        public FizzBuzzController(IFizzBuzzRepository fizzBuzzRepository)
        {
            this.fizzBuzzRepository = fizzBuzzRepository;
        }

        /// <summary>
        /// Launches the screen
        /// </summary>
        /// <returns>returns a launch View</returns>
        [HttpGet]
        public ActionResult LaunchScreen()
        {
            return this.View("LaunchScreen", new FizzBuzzModel());
        }

        /// <summary>
        /// Sends the result to the view
        /// </summary>
        /// <param name="fizzBuzzModel">request got from the user</param>        
        /// <returns>returns a view</returns>        
        public ActionResult DisplayResult(FizzBuzzModel fizzBuzzModel)
        {
            if (ModelState.IsValid)
            {
                var fizzBuzzResult = this.fizzBuzzRepository.BuildFizzBuzzLogic(fizzBuzzModel.UserEnteredNumber.Value);
                fizzBuzzModel.FizzBuzzResult = fizzBuzzResult.ToPagedList(fizzBuzzModel.PageNumber, 20);
                return this.View("DisplayResult", fizzBuzzModel);
            }

            return this.View("LaunchScreen", fizzBuzzModel);
        }

        /// <summary>
        /// Gets pagination details to controller
        /// </summary>
        /// <param name="userEnteredNumber">user entered value</param>
        /// <param name="page">page number</param>
        /// <returns>returns to the display result action</returns>
        [HttpGet]
        public ActionResult GetPageDetails(int userEnteredNumber, int page = 1)
        {
            var fizzBuzzModel = new FizzBuzzModel()
            {
                PageNumber = page,
                UserEnteredNumber = userEnteredNumber
            };
            return this.RedirectToAction("DisplayResult", fizzBuzzModel);
        }
    }
}