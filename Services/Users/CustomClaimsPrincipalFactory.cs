using CarRentalApplication.Models.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace CarRentalApplication.Services.Users
{
    public class CustomClaimsPrincipalFactory : UserClaimsPrincipalFactory<User>
    {
        public CustomClaimsPrincipalFactory(UserManager<User> userManager, IOptions<IdentityOptions> optionsAccessor) : base(userManager, optionsAccessor)
        { }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(User user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("FirstName", user.FirstName ?? ""));
            identity.AddClaim(new Claim("LastName", user.LastName ?? ""));
            identity.AddClaim(new Claim("MobilePhone", user.PhoneNumber ?? ""));
            identity.AddClaim(new Claim("Email", user.Email ?? ""));
            return identity;
        }
    }
}
