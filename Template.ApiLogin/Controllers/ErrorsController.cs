using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace TemplateX.ApiLogin.Controllers
{

    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("/errors")]
    public class ErrorsController : ControllerBase
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<ErrorsController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorsController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public ErrorsController(ILogger<ErrorsController> logger)
        {
            this._logger = logger;
        }

        /// <summary>
        /// Handles the errors.
        /// </summary>
        /// <returns></returns>
        [HttpGet, HttpPost, HttpPut, HttpDelete]
        public IActionResult HandleErrors()
        {
            var contextException = this.HttpContext.Features.Get<IExceptionHandlerFeature>(); // Capture the exception.
            this._logger.LogError("Error found {@Error} with message {@Message}", contextException.Error, contextException.Error.Message);

            HttpStatusCode responseStatusCode;
            var exception = contextException.Error;

            if (exception is ValidationException || exception is Exception)
            {
                responseStatusCode = HttpStatusCode.BadRequest;
            }
            else
            {
                responseStatusCode = HttpStatusCode.InternalServerError;
            }

            return this.Problem(contextException.Error.Message, statusCode: (int)responseStatusCode);
        }
    }
}
