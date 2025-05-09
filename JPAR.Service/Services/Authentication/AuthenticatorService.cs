﻿using JPAR.Service.IServices.IAuthentication;
using JPAR.Service.Models;
using System.Security.Claims;

namespace JPAR.Service.Services.Authentication
{
    public class AuthenticatorService : IAuthenticatorService
    {
        private readonly IAccessTokenGeneratorService _accessTokenGeneratorService;
        private readonly IRefreshTokenGeneratorService _refreshTokenGenerator;

        public AuthenticatorService(IAccessTokenGeneratorService accessTokenGeneratorService, IRefreshTokenGeneratorService refreshTokenGenerator)
        {
            _accessTokenGeneratorService = accessTokenGeneratorService;
            _refreshTokenGenerator = refreshTokenGenerator;
        }

        public async Task<AuthenticatedUserModel> Authenticate(User user, List<Claim> claims)
        {

            var accessToken = _accessTokenGeneratorService.GenerateToken(user, claims);

            return new AuthenticatedUserModel()
            {
                AccessToken = accessToken.Value,
                AccessTokenExpirationTime = accessToken.ExpirationDate,
                SessionId = user.Id,
                FullName = $"{user.FirstName} {user.LastName}",
                UserId = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                UserType = user.UserType,
            };
        }
    }
}
