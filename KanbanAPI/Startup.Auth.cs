using System;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace KanbanAPI
{
    public partial class Startup
    {
		public void ConfigureAuth(IApplicationBuilder app)
		{
			var singingkey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("TokenAuthentication:SecretKey").Value));

			var tokenProviderOptions = new TokenProviderOptions
			{
				Path = Configuration.GetSection("TokenAuthentication:TokenPath").Value,
				Audience = Configuration.GetSection("TokenAuthentication:Audience").Value,
				Issuer = Configuration.GetSection("TokenAuthentication:Issuer").Value,
				SigningCredentials = new SigningCredentials(singingkey, SecurityAlgorithms.HmacSha256),
				IdentityResolver = GetIdentity
			};
			var tokenValidationParams = new TokenValidationParameters
			{
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = singingkey,
				ValidateIssuer = true,
				ValidateAudience = true,
				ValidIssuer = Configuration.GetSection("TokenAuthentication:Issuer").Value,
				ValidAudience = Configuration.GetSection("TokenAuthentication:Audience").Value,
				ValidateLifetime = true,
				ClockSkew = TimeSpan.Zero
			};

            app.AddAuthorization()
			app.UseJwtBearerAuthentication(new JwtBearerOptions
            {
                
				TokenValidationParameters = tokenValidationParams
			});

			app.UseCookieAuthentication(new CookieAuthenticationOptions
			{
				AutomaticAuthenticate = true,
				AutomaticChallenge = true,
				AuthenticationScheme = "Cookie",
				CookieName = Configuration.GetSection("TokenAuthentication:CookieName").Value,
				TicketDataFormat = new CustomJwtDataFormat(
				SecurityAlgorithms.HmacSha256,
				tokenValidationParams)
			});

			app.UseMiddleware<TokenProviderMiddleware>(Options.Create(tokenProviderOptions));
		}


		private Task<ClaimsIdentity> GetIdentity(string username, string password)
		{
			Console.WriteLine("username : " + username);
			Console.WriteLine("password : " + password);
			// DEMO CODE, DON NOT USE IN PRODUCTION!!!
			if (username == "TEST" && password == "TEST123")
			{
				return Task.FromResult(new ClaimsIdentity(new GenericIdentity(username, "Token"), new Claim[] { }));
			}

			// Account doesn't exists
			return Task.FromResult<ClaimsIdentity>(null);
		}

	}
}
