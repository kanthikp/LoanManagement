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

namespace LoanManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly ILoanRepository loanRepository;

        public LoansController(ILoanRepository loanRepository)
        {
            this.loanRepository = loanRepository;
        }

        #region Public REST Methods

        // GET api/loans
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<Loan>> Get()
        {
            try
            {
                return loanRepository.GetAllLoans().ToList();
            }
            catch (System.Exception ex)
            {
                return InternalServerError(nameof(Get), "GetAllObjects", ex);
            }
        }

        // GET api/loans/5
        [HttpGet("{id}", Name = nameof(GetObjectById))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Loan> GetObjectById(int Id)
        {

            try
            {
                return loanRepository.GetLoan(Id);
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


            return new ObjectResult(problemDetail)
            {
                ContentTypes = { "application/problem+json" },
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }
        #endregion
    }
}
