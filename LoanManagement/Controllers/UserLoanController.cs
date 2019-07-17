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
    [Route("api/users/{userId}/loans")]
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
        public ActionResult<IEnumerable<UserLoan>> Get(int userId)
        {
            try
            {
               //return InternalServerError(nameof(Get), Constants.Message.TitleGetObjects, new Exception("Test exception"));
               return _userLoanRepository.GetByUserId(userId).ToList();
            }
            catch (System.Exception ex)
            {
                return InternalServerError(nameof(Get), Constants.Message.TitleGetObjects, ex);
            }
        }

        // GET api/loans/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<UserLoan> GetObjectById(int id, int userId)
        {
            string methodName = nameof(GetObjectById), title = Constants.Message.TitleGetObjectById;

            try
            {
                var result = _userLoanRepository.GetByLoanIdUserId(id, userId);
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
        public ActionResult<UserLoan> Create([FromBody] UserLoan value)
        {
            string methodName = nameof(Create), title = Constants.Message.TitleCreateObject;
            List<string> validationFailureMessages;

            try
            {
                var isValid = ValidateRequest(HttpMethods.Post, value, null, out validationFailureMessages);
                if (isValid)
                {
                    return _userLoanRepository.Add(value);
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
        public ActionResult<UserLoan> Update(int id, [FromBody] UserLoan value)
        {
            string methodName = nameof(Update), title = Constants.Message.TitleUpdateObject;
            List<string> validationFailureMessages;

            try
            {
                var isValid = ValidateRequest(HttpMethods.Put, value, id, out validationFailureMessages);
                if (isValid)
                {
                    return _userLoanRepository.Update(value);
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
            var errorMessage = string.Format($"EXCEPTION: UserLoanController::{methodName}() >> StatusCode: {statusCode}, Message: '{ex.Message}'");
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
                ContentTypes = { Constants.Http.ContentType },
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }

        private bool ValidateRequest(
            string httpMethod,
            UserLoan value,
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

            else if (HttpMethods.IsPut(httpMethod))
            {
                if (value.Id.ToString() != param1.ToString())
                {
                    result = false;
                    validationFailureMessages.Add(Constants.Message.ValidationFailedIdsShouldMatch);
                }
            }

            _appLogger.LogError($"UserLoanController::Validate(httpMethod: {httpMethod}, <value>, param1: {param1}) >> Result = {result}.");
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
                Detail = string.Format($"UserLoan object with id '{id}' not found.")
            };

            _appLogger.LogError($"UserLoanController::{methodName}('{id}') >> StatusCode: {statusCode}");
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

            _appLogger.LogError($"UserLoanController::{methodName}('{id}') >> StatusCode: {statusCode}");
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
