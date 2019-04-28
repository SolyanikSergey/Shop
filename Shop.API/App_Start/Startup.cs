using Autofac;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Shop.API.Auth;
using Shop.API.Configuration;
using System;
using System.Web.Http;

[assembly: OwinStartup(typeof(Shop.API.App_Start.Startup))]
namespace Shop.API.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = GlobalConfiguration.Configuration;
            AutofacWebapiConfig.Initialize(config);

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            ConfigureOAuth(app);

            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            app.UseWebApi(config);
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            AuthorizationServerProvider authorizationServerProvider = AutofacWebapiConfig.Container.Resolve<AuthorizationServerProvider>();

            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = authorizationServerProvider
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}