using EGM.AracKiralama.BL.Abstracts;
using EGM.AracKiralama.DAL.Abstracts;
using EGM.AracKiralama.Model.Dtos;
using EGM.AracKiralama.Model.Entities;
using Infrastructure.Model.Dtos;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EGM.AracKiralama.BL.Concretes
{
    public class AuthService : IAuthService
    {
        IConfiguration _configuration;
        private readonly IAracKiralamaRepository _repository;
        public AuthService(IConfiguration configuration, IAracKiralamaRepository repository)
        {
            _configuration = configuration;
            _repository = repository;
        }
        public async Task<ResultDto<JwtDto>> LoginAsync(LoginDto item)
        {
            JwtDto jwtDto = new JwtDto();

            //LDAP kontrolü yapılacak
            /*
            public static bool ValidateCredentials(string userName, string password)
            //{
            //    string AdPath = _configuration.GetSection("AppSettings")["ADPath"];
            //    string AdNode = _configuration.GetSection("AppSettings")["ADNode"];


            //    using (var principalContext = new PrincipalContext(ContextType.Domain, AdPath, AdNode))
            //    {
            //        var isLDAPKullancisi = principalContext.ValidateCredentials(userName, password);

            //        if (!isLDAPKullancisi)
            //            return new ResultDto(StatusCodeEnum.Unauthorized, "Kullanıcı adı veya parola yanlış.");
            //    }
            //}
            */

            //Veritabanından da kontrol yapılabilir.
            if (!(item.EPosta == "arackiralama@gmail.com" && item.Password == "123456Aa"))
            {
                return ResultDto<JwtDto>.Error("Eposta veya Parola yanlış");
            }
            var userDto = await _repository.GetProjectAsync<User, UserDto>(d => d.EPosta == item.EPosta);
            userDto.Roles = new List<string>();
            userDto.Roles.Add("admin");
            var token = CreateToken(userDto);

            jwtDto.Token = token;

            return ResultDto<JwtDto>.Success(jwtDto);
        }

        private string CreateToken(UserDto userDto)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings").Get<JwtSettings>();

            //var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes
            //   (_configuration["JwtSettings:SecretKey"]));

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddMinutes(jwtSettings.ExpMinute);

            var claims = new List<Claim>();
            claims.Add(new Claim("id", userDto.Id.ToString()));
            claims.Add(new Claim("name", userDto.Name));
            claims.Add(new Claim("surname", userDto.Surname));
            foreach (var item in userDto.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, item));
            }


            var token = new JwtSecurityToken(
                issuer: jwtSettings.Issuer,
                audience: jwtSettings.Audience,
                signingCredentials: credentials,
                expires: expires,
                claims: claims
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

