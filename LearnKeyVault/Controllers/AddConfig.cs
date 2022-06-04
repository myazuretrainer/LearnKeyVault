using Microsoft.Extensions.Configuration;

namespace LearnKeyVault.Controllers
{
    public class AddConfig
    {
        private readonly IConfiguration configuration;
            public AddConfig(IConfiguration configuration)
        {
            this.configuration = configuration;
                
        }
        public string StorrageAccontName { get { return this.configuration["StorrageAccontName"]; } }
        public string Key { get { return this.configuration["Key"]; } }

        public string Containername { get { return this.configuration["Containername"]; } }
    }
}
