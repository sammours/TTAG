namespace TTAG.App.HelperClasses
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using Microsoft.IdentityModel.Tokens;

    public static class JwtMaker
    {
        public static string GetToken(string userId)
        {
            string securitykey = "this_TTAG_securitykey!@#$%^";
            var symmetricsecuritykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securitykey));
            var signincredentials = new SigningCredentials(symmetricsecuritykey, SecurityAlgorithms.HmacSha256Signature);
            var claims = new List<Claim>();
            claims.Add(new Claim("Id", userId));
            var token = new JwtSecurityToken(issuer: "TTAG_App",
                                             audience: "TTAG_Users",
                                             expires: DateTime.Now.AddYears(2),
                                             claims: claims,
                                             signingCredentials: signincredentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
