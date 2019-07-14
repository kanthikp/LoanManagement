using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoanManagement.Domain;
using LoanManagement.Repository;
using Microsoft.AspNetCore.WebSockets.Internal;
using LoanManagement.Helper;

namespace LoanManagement.Controllers
{
    [Route("api/UserLoan")]
    [ApiController]
    public class UserLoanController : ControllerBase
    {
        private readonly IAppLogger _appLogger;
        public IUserLoanRepository _userLoanRepository { get; }

        public UserLoanController(IAppLogger appLogger, IUserLoanRepository userLoanRepository)
        {
            this._appLogger = appLogger;
            this._userLoanRepository = userLoanRepository;
        }

        #region Public REST Methods

        // GET api/loans
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<UserLoan>> Get()
        {
            try
            {
                return _userLoanRepository.GetAll().ToList();
            }
            catch (System.Exception ex)
            {
                return InternalServerError(nameof(Get), "GetAllObjects", ex);
            }
        }

        // GET api/loans/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<UserLoan> GetObjectById(int Id)
        {

            try
            {
                return _userLoanRepository.Get(Id);
            }
            catch (System.Exception ex)
            {
                return InternalServerError(nameof(Get), "GetObjectById", ex);
            }
        }
        #endregion

        #region Private Methods
        private ObjectResult InternalServerError(
           string methodName,
           string title,
           Exception ex)
        {
            var statusCode = StatusCodes.Status500InternalServerError;
            var errorMessage = string.Format($"EXCEPTION: LoansController::{methodName}() >> StatusCode: {statusCode}, Message: '{ex.Message}'");
            var problemDetail = new ProblemDetails()
            {
                Status = statusCode,
                Instance = HttpContext.Request.Path,
                Title = title,
                Detail = errorMessage
            };

            _appLogger.LogError(errorMessage);
            return new ObjectResult(problemDetail)
            {
                ContentTypes = { "application/problem+json" },
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }
        #endregion
    }
}
