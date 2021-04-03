// <copyright file="FizzBuzzControllerTest.cs" company="TCS">
// Copyright (c) Company. All rights reserved.
// </copyright>

namespace FizzBuzzApplication.Test.Controller
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web.Mvc;
    using Controllers;
    using FizzBuzzServices.Repository;
    using Models;
    using Moq;
    using NUnit.Framework;    

    /// <summary>
    /// FizzBuzzController class Test
    /// </summary>
    [TestFixture]
    public class FizzBuzzControllerTest
    {
        /// <summary>
        /// FizzBuzzRepository class instance
        /// </summary>
        private readonly Mock<IFizzBuzzRepository> mockFizzBuzzRepository;

        /// <summary>
        /// FizzBuzzController class instance to be used for all the tests in this class
        /// </summary>
        private readonly FizzBuzzController fizzBuzzController;

        /// <summary>
        /// Initializes a new instance of the <see cref="FizzBuzzControllerTest"/> class
        /// </summary>
        public FizzBuzzControllerTest()
        {
            this.mockFizzBuzzRepository = new Mock<IFizzBuzzRepository>();
            this.fizzBuzzController = new FizzBuzzController(this.mockFizzBuzzRepository.Object);
        }

        /// <summary>
        /// Launch screen test for fizz buzz application
        /// </summary>
        [Test]
        public void LaunchScreenTest()
        {
            var result = this.fizzBuzzController.LaunchScreen() as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.AreEqual("LaunchScreen", result.ViewName);
        }

        /// <summary>
        /// DisplayResult Test
        /// </summary>
        [Test]
        public void DisplayResultTest()
        {
            var modelList = new List<string>();
            for (int number = 1; number <= 20; number++)
            {
                modelList.Add(number.ToString());
            }

            this.mockFizzBuzzRepository.Setup(x => x.BuildFizzBuzzLogic(It.IsAny<int>()))
                .Returns(modelList);
            var result = this.fizzBuzzController.DisplayResult(new FizzBuzzModel() { UserEnteredNumber = 20 }) as ViewResult;
            var fizzBuzzModel = result.Model as FizzBuzzModel;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.AreEqual("DisplayResult", result.ViewName);
            Assert.AreEqual(modelList, fizzBuzzModel.FizzBuzzResult);
        }

        /// <summary>
        /// Test for validating the model state in controller
        /// </summary>
        /// <param name="userEnteredNumber">User Entered Number</param>
        /// <param name="errorMessage">Error Message</param>
        [TestCase(null, "Number is mandatory Field.")]
        [TestCase(-2, "Number should be a positive integer between 1 to 1000.")]
        [TestCase(111111, "Number should be a positive integer between 1 to 1000.")]
        public void ModelStateValidationTests(int? userEnteredNumber, string errorMessage)
        {
            var validationContext = new ValidationContext(new FizzBuzzModel() { UserEnteredNumber = userEnteredNumber }, null, null);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(validationContext.ObjectInstance, validationContext, validationResults, true);
            foreach (var validationResult in validationResults)
            {
                this.fizzBuzzController.ModelState.AddModelError(validationResult.MemberNames.FirstOrDefault() ?? string.Empty, validationResult.ErrorMessage);
            }

            Assert.IsTrue(!this.fizzBuzzController.ModelState.IsValid);
            Assert.AreEqual(errorMessage, validationResults[0].ToString());
        }

        /// <summary>
        /// Pagination test
        /// </summary>
        [Test]
        public void GetPageDetailsTest()
        {
            var result = (RedirectToRouteResult)this.fizzBuzzController.GetPageDetails(20);
            Assert.That(result, Is.InstanceOf<RedirectToRouteResult>());
            Assert.AreEqual(result.RouteValues["action"], "DisplayResult");
        }
    }
}
