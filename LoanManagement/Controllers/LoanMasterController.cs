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

        // GET api/loanmaster
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
                return InternalServerError(nameof(Get), Constants.Message.TitleGetObjects, ex);
            }
        }

        // GET api/loanmaster/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<LoanMaster> GetObjectById(int id)
        {
            string methodName = nameof(GetObjectById), title = Constants.Message.TitleGetObjectById;
            try
            {
                var result = _loanMasterRepository.Get(id);
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return NotFoundError(methodName, title, id);
                }
            }
            catch (System.Exception ex)
            {
                return InternalServerError(methodName, title, ex);
            }
        }

        // POST api/loanmaster
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<LoanMaster> Create([FromBody] LoanMaster value)
        {
            string methodName = nameof(Create), title = Constants.Message.TitleCreateObject;
            List<string> validationFailureMessages;

            try
            {
                var isValid = ValidateRequest(HttpMethods.Post, value, null, out validationFailureMessages);
                if (isValid)
                {
                    return _loanMasterRepository.Add(value);
                }
                else
                {
                    var errorMessage = GetFlattenedMessage(validationFailureMessages, Constants.Message.ValidationFailed);
                    return BadRequestError(methodName, title, null, errorMessage);
                }
            }
            catch (System.Exception ex)
            {
                return InternalServerError(methodName, title, ex);
            }
        }

        // PUT api/loanmaster/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<LoanMaster> Update(int id, [FromBody] LoanMaster value)
        {
            string methodName = nameof(Update), title = Constants.Message.TitleUpdateObject;
            List<string> validationFailureMessages;

            try
            {
                var isValid = ValidateRequest(HttpMethods.Put, value, id, out validationFailureMessages);
                if (isValid)
                {
                    return _loanMasterRepository.Update(value);
                }
                else
                {
                    var errorMessage = GetFlattenedMessage(validationFailureMessages, Constants.Message.ValidationFailed);
                    return BadRequestError(methodName, title, id, errorMessage);
                }
            }
            catch (System.Exception ex)
            {
                return InternalServerError(methodName, title, ex);
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
            var errorMessage = string.Format($"EXCEPTION: LoanMasterController::{methodName}() >> StatusCode: {statusCode}, Message: '{ex.Message}'");
            var problemDetail = new ProblemDetails()
            {
                Status = statusCode,
                Instance = HttpContext != null ? HttpContext.Request.Path.ToString() : "Test",
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

        private bool ValidateRequest(
            string httpMethod,
            LoanMaster value,
            object param1,
            out List<string> validationFailureMessages)
        {
            bool result = true;
            validationFailureMessages = new List<string>();

            if (HttpMethods.IsPost(httpMethod))
            {
                if (value.Id != 0)
                {
                    result = false;
                    validationFailureMessages.Add(Constants.Message.ValidationFailedIdShouldBeNull);
                }
            }

            if (HttpMethods.IsPut(httpMethod))
            {
                if (value.Id.ToString() != param1.ToString())
                {
                    result = false;
                    validationFailureMessages.Add(Constants.Message.ValidationFailedIdsShouldMatch);
                }
            }

            _appLogger.LogError($"LoanMasterController::Validate(httpMethod: {httpMethod}, <value>, param1: {param1}) >> Result = {result}.");
            return result;
        }
        private NotFoundObjectResult NotFoundError(
            string methodName,
            string title,
            int id)
        {
            var statusCode = StatusCodes.Status404NotFound;
            var problemDetail = new ProblemDetails()
            {
                Status = statusCode,
                Instance = HttpContext != null ? HttpContext.Request.Path.ToString() : "Test",
                Title = title,
                Detail = string.Format($"LoanMaster object with id '{id}' not found.")
            };

            _appLogger.LogError($"LoanMasterController::{methodName}('{id}') >> StatusCode: {statusCode}");
            return new NotFoundObjectResult(problemDetail)
            {
                ContentTypes = { Constants.Http.ContentType },
                StatusCode = StatusCodes.Status404NotFound
            };
        }

        private BadRequestObjectResult BadRequestError(
            string methodName,
            string title,
            int? id,
            string messageDetail)
        {
            var statusCode = StatusCodes.Status400BadRequest;
            var problemDetail = new ProblemDetails()
            {
                Status = statusCode,
                Instance = HttpContext != null ? HttpContext.Request.Path.ToString() : "Test",
                Title = title,
                Detail = messageDetail
            };

            _appLogger.LogError($"LoanMasterController::{methodName}('{id}') >> StatusCode: {statusCode}");
            return new BadRequestObjectResult(problemDetail)
            {
                ContentTypes = { Constants.Http.ContentType },
                StatusCode = StatusCodes.Status400BadRequest
            };
        }

        private string GetFlattenedMessage(List<string> messageList, string defaultMessage)
        {
            defaultMessage = defaultMessage ?? "(no default message set)";
            var message = (messageList == null)
                            ? defaultMessage
                            : (
                                    (messageList.Count == 0)
                                        ? defaultMessage
                                        : string.Join(", ", messageList)
                                );

            return message;
        }

        #endregion //Private Methods
       
    }
}
