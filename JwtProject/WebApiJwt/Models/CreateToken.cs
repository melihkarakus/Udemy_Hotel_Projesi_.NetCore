using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApiJwt.Models
{
    public class CreateToken
    {
        public string TokenCreate() 
        {
            // Veriyi UTF-8 formatında baytlara çevir
            var bytes = Encoding.UTF8.GetBytes("aspnetcoreapiapi");

            // Baytları kullanarak bir simetrik güvenlik anahtarı oluştur
            SymmetricSecurityKey key = new SymmetricSecurityKey(bytes);

            // Güvenlik anahtarını kullanarak bir imza oluşturucu oluştur
            SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // JWT (Json Web Token) oluştur
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken
                (
                    issuer: "http://localhost",            // Token'ın hangi tarafından oluşturulduğunu belirtir
                    audience: "http://localhost",          // Token'ın hangi tarafına yönlendirildiğini belirtir
                    notBefore: DateTime.Now,                // Token'ın hangi tarihten önce kullanılamayacağını belirtir
                    expires: DateTime.Now.AddMinutes(3),   // Token'ın ne zaman geçerliliğini yitireceğini belirtir
                    signingCredentials: signingCredentials  // Token'ı imzalamak için kullanılan imza bilgilerini belirtir
                );

            // JWT token'ını ele almak için bir JWT token yöneticisi oluştur
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            // JWT token'ını yazıya çevir
            return jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);
        }


        public string CreateTokenAdmin()
        {
            // Metni UTF-8 formatında baytlara çevir
            var bytes = Encoding.UTF8.GetBytes("aspnetcoreapiapi");

            // Baytları kullanarak bir simetrik güvenlik anahtarı oluştur
            SymmetricSecurityKey key = new SymmetricSecurityKey(bytes);

            // Güvenlik anahtarını ve imza algoritmasını kullanarak imza bilgileri oluştur
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // JWT içinde taşınacak iddia (claim) bilgilerini tanımla
            List<Claim> claims = new List<Claim>()
{
    new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()), // Kullanıcı kimliği
    new Claim(ClaimTypes.Role, "Admin"),                               // Kullanıcının rolü (Admin)
    new Claim(ClaimTypes.Role, "Visitor")                              // Kullanıcının rolü (Visitor)
};

            // JWT oluştur
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken
                (
                issuer: "http://localhost",                // Token'ın hangi tarafından oluşturulduğunu belirtir
                audience: "http://localhost",              // Token'ın hangi tarafına yönlendirildiğini belirtir
                notBefore: DateTime.Now,                    // Token'ın hangi tarihten önce kullanılamayacağını belirtir
                expires: DateTime.Now.AddSeconds(3),        // Token'ın ne zaman geçerliliğini yitireceğini belirtir
                signingCredentials: credentials,            // Token'ı imzalamak için kullanılan imza bilgilerini belirtir
                claims: claims                             // Token içinde taşınacak iddia (claim) bilgilerini belirtir
                );

            // JWT token'ını ele almak için bir JWT token yöneticisi oluştur
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            // JWT token'ını yazıya çevir ve döndür
            return jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);
        }
    }
}
