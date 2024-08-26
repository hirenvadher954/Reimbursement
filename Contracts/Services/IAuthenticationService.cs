using System;
using Microsoft.AspNetCore.Identity;
using Shared.DataTransferObjects;

namespace Service
{
	public interface IAuthenticationService
	{
        Task<IdentityResult> RegisterUser(UserForRegistrationDTO userForRegistration);
        Task<bool> ValidateUser(UserForAuthenticationDTO userForAuthentication);
        Task<TokenDTO> CreateToken(bool populateExp);
        Task<TokenDTO> RefreshToken(TokenDTO tokenDto);
    }
}

