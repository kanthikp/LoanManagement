using System;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;

using LoanManagement.Controllers;
using LoanManagement.Domain;
using LoanManagement.Repository;
using LoanManagement.Helper;

namespace LoanManagement.Test
{
    public class UserLoanControllerTest
    {
        [Fact]
        public void Get_Successful()
        {
            //Arrange
            var id = 1;
            var userId = 1;

            var userLoan = new UserLoan
            {
                Id = 1,
                UserLoanNum = "67853423187",
                InterestAmount = 375,
                EarlyPaymentFee = 76,
                Balance = 1990,
                AppliedForTopup = true,
                LoanMasterId = 1,
                CreatedOn = new DateTime(2019, 1, 1),
                UpdatedOn = new DateTime(2019, 1, 1),

            };

            var mockUserLoanRepository = new Mock<IUserLoanRepository>();
            var mockAppLogger = new Mock<IAppLogger>();
            mockUserLoanRepository.Setup(x => x.GetByLoanIdUserId(id,userId)).Returns(userLoan);

            var controller = new UserLoanController(mockAppLogger.Object, mockUserLoanRepository.Object);

            //Act
            var actual = controller.GetObjectById(userId,id);
           
            //Assert
            Assert.Same(userLoan, actual.Value);

        }

        [Fact]
        public void Get_Returns404NotFound()
        {
            //Arrange
            var id = 999;
            var userId = 999;

            var mockUserLoanRepository = new Mock<IUserLoanRepository>();
            var mockAppLogger = new Mock<IAppLogger>();
            mockUserLoanRepository.Setup(x => x.GetByLoanIdUserId(id,userId)).Returns<UserLoan>(null);

            var controller = new UserLoanController(mockAppLogger.Object, mockUserLoanRepository.Object);
            //Act
            var actual = controller.GetObjectById(id, userId);
            //Assert
            Assert.Null( actual.Value);
            var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(actual.Result);
            Assert.Equal(404, notFoundObjectResult.StatusCode);

        }

        [Fact]
        public void Get_Returns500InternalServerError()
        {
            //Arrange
            var id = 1;
            var userId = 1;

            var mockUserLoanRepository = new Mock<IUserLoanRepository>();
            var mockAppLogger = new Mock<IAppLogger>();
            mockUserLoanRepository.Setup(x => x.GetByLoanIdUserId(id,userId)).Throws(new InvalidOperationException());

            var controller = new UserLoanController(mockAppLogger.Object, mockUserLoanRepository.Object);
            //Act
            var actual = controller.GetObjectById(id,userId);
            //Assert
            Assert.Null(actual.Value);
            Assert.Equal(500, ((ObjectResult)actual.Result).StatusCode);

        }

        [Fact]
        public void Create_Successful()
        {
            //Arrange

            var userLoanInput = new UserLoan
            {
                UserLoanNum = "67853423187",
                InterestAmount = 375,
                EarlyPaymentFee = 76,
                Balance = 1990,
                AppliedForTopup = true,
                LoanMasterId = 1,
                CreatedOn = new DateTime(2019, 1, 1),
                UpdatedOn = new DateTime(2019, 1, 1)

            };

            var userLoanOutput = new UserLoan
            {
                Id=10,
                UserLoanNum = "67853423187",
                InterestAmount = 375,
                EarlyPaymentFee = 76,
                Balance = 1990,
                AppliedForTopup = true,
                LoanMasterId = 1,
                CreatedOn = new DateTime(2019, 1, 1),
                UpdatedOn = new DateTime(2019, 1, 1)

            };

            var mockUserLoanRepository = new Mock<IUserLoanRepository>();
            var mockAppLogger = new Mock<IAppLogger>();
            mockUserLoanRepository.Setup(x => x.Add(userLoanInput)).Returns(userLoanOutput);

            var controller = new UserLoanController(mockAppLogger.Object, mockUserLoanRepository.Object);

            //Act
            var actual = controller.Create(userLoanInput);

            //Assert
            Assert.Same(userLoanOutput, actual.Value);

        }

        [Fact]
        public void Create_Returns400BadRequest()
        {
            //Arrange

            var userLoanInput = new UserLoan
            {
                Id = 10,
                UserLoanNum = "67853423187",
                InterestAmount = 375,
                EarlyPaymentFee = 76,
                Balance = 1990,
                AppliedForTopup = true,
                LoanMasterId = 1,
                CreatedOn = new DateTime(2019, 1, 1),
                UpdatedOn = new DateTime(2019, 1, 1)

            };

            var mockUserLoanRepository = new Mock<IUserLoanRepository>();
            var mockAppLogger = new Mock<IAppLogger>();
            //mockUserLoanRepository.Setup(x => x.Add(userLoanInput)).Returns(userLoanInput);

            var controller = new UserLoanController(mockAppLogger.Object, mockUserLoanRepository.Object);

            //Act
            var actual = controller.Create(userLoanInput);

            //Assert
            Assert.Null(actual.Value);
            var badRequestObjectResult = Assert.IsType<BadRequestObjectResult>(actual.Result);
            Assert.Equal(400, badRequestObjectResult.StatusCode);

        }


    }
}
