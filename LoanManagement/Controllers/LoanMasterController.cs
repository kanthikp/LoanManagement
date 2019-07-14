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
    [Route("api/[controller]")]
    [ApiController]
    public class LoanMasterController : ControllerBase
    {
        private readonly IAppLogger _appLogger;
        public ILoanMasterRepository _loanMasterRepository { get; }

        public LoanMasterController(IAppLogger appLogger,ILoanMasterRepository loanMasterRepository)
        {
            this._appLogger = appLogger;
            this._loanMasterRepository = loanMasterRepository;
        }

        #region Public REST Methods

        // GET api/loans
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<LoanMaster>> Get()
        {
            try
            {
                return _loanMasterRepository.GetAll().ToList();
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
        public ActionResult<LoanMaster> GetObjectById(int Id)
        {

            try
            {
                return _loanMasterRepository.Get(Id);
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
