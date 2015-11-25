using Microsoft.Owin.Security.OAuth;
using OpenTicket.Domain.Interfaces.Services;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace Consult.Api.Security
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        IUsuarioApplicationService _userService;

        public SimpleAuthorizationServerProvider(IUsuarioApplicationService userService)
        {
            this._userService = userService;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            var user = _userService.Authenticate(context.UserName, context.Password);
            if (user == null)
            {
                context.SetError("invalid_grant", "Usuário ou senha inválidos");
                return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            identity.AddClaim(new Claim(ClaimTypes.Name, user.Login));
            identity.AddClaim(new Claim(ClaimTypes.Role, user.isAdmin ? "admin" : ""));



            GenericPrincipal principal = new GenericPrincipal(identity, new string[] { user.isAdmin ? "admin" : "" });
            Thread.CurrentPrincipal = principal;

            context.Validated(identity);
        }
    }
}