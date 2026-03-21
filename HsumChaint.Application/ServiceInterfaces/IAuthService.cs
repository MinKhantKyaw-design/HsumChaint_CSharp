using HsumChaint.Application.DTOs.Auth;

namespace HsumChaint.Application.ServiceInterfaces
{
    public interface IAuthService
    {
        Task<ApplicationCommonResponseModel<LoginResponseDto>> Login(LoginRequestDto reqModel);
        Task<ApplicationCommonResponseModel<RegisterResponseDto>> Register(RegisterRequestDto reqModel);

        Task<ApplicationCommonResponseModel<LoginResponseDto>> RefreshTokens(RefreshTokenRequestDto request);
    }
}