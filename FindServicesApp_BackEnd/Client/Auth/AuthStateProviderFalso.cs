using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace FindServicesApp_BackEnd.Client.Auth
{
    public class AuthStateProviderFalso : AuthenticationStateProvider
    {
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            //var identity = new ClaimsIdentity();
            var identity = new ClaimsIdentity(new List<Claim> {
                new Claim(ClaimTypes.Name, "Felipe")
            }, "prueba");
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity)));
        }
    }
}
