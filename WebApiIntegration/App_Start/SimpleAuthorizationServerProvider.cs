using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;

namespace WebApiIntegration.App_Start {
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider {

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context) {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context) {
            if(context.UserName == "edeger" && context.Password == "Password1") {

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                identity.AddClaim(new Claim("sub", context.UserName));
                identity.AddClaim(new Claim("role", "user"));

                context.Validated(identity);

            } else {
                context.SetError("invalid_grant", "Hatalı kullanıcı adı veya şifre");
            }
        }

    }
}