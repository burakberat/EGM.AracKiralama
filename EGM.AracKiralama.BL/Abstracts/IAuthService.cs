using EGM.AracKiralama.Model.Dtos;
using Infrastructure.Model.Dtos;

namespace EGM.AracKiralama.BL.Abstracts
{
    public interface IAuthService
    {
        Task<ResultDto<JwtDto>> LoginAsync(LoginDto item);
    }
}
