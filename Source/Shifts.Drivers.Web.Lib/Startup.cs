using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Shifts.Drivers.Web.Lib;

[assembly: OwinStartup(typeof(Startup))]

namespace Shifts.Drivers.Web.Lib
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            if (context.UserName != "Admin")
            {
                context.SetError("upps!", "Wrong data");
                return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim("role", "user"));

            context.Validated(identity);
        }
    }
    public class Startup
    {
        public void ConfigureOAuth(IAppBuilder app)
        {
            var oAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleAuthorizationServerProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(oAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }

        public void Configuration(IAppBuilder appBuilder)
        {
            appBuilder.Map("/api", api =>
            {
                var config = new HttpConfiguration();
                ConfigureOAuth(appBuilder);
                config.EnableCors();

                config.MapHttpAttributeRoutes();
                //config.SetCorsPolicyProviderFactory(new AttributeBasedPolicyProviderFactory());
                // Enable the application to use bearer tokens to authenticate users
                api.UseWebApi(config);
            });
        }
    }
}
