using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace OrigamiEdu.Services
{
    public class httpServices
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ILogger<httpServices> logger;

        public httpServices(IHttpContextAccessor httpContextAccessor, ILogger<httpServices> logger)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.logger = logger;
        }

        public string getSignedInUsername()
        {
            return httpContextAccessor.HttpContext.User.Identity.Name.ToString();
        }
    }
}