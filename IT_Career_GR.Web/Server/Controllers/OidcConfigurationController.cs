using IT_Career_GR.Common.Models.Settings;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Mvc;

namespace IT_Career_GR.Web.Server.Controllers
{
    public class OidcConfigurationController : Controller
    {
        private readonly ILogger<OidcConfigurationController> _logger;
        private readonly string? _clientId;

        public OidcConfigurationController(IClientRequestParametersProvider clientRequestParametersProvider, ILogger<OidcConfigurationController> logger, IConfiguration Configuration)
        {
            ClientRequestParametersProvider = clientRequestParametersProvider;
            _logger = logger;
            if (Configuration is null) 
            {
                throw new Exception("Configuration null.");
            }
            _clientId = Configuration.GetSection(nameof(ClientSettings)).GetValue<string>(nameof(ClientSettings.ClientId));
        }
        
        public IClientRequestParametersProvider ClientRequestParametersProvider { get; }

        [HttpGet("_configuration/{clientId}")]
        public IActionResult GetClientRequestParameters([FromRoute] string clientId)
        {
            if (_clientId is null) 
            {
                var parameters = ClientRequestParametersProvider.GetClientParameters(HttpContext, clientId);
                return Ok(parameters);
            }
            else
            {
                var parameters = ClientRequestParametersProvider.GetClientParameters(HttpContext, _clientId);
                return Ok(parameters);
            }
        }
    }
}