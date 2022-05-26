

using TestProject.Entities;
using TestProject.IServices;

namespace TestProject.Services;

public class UserAuthorizeService : IUserAuthorizeService
{
    private readonly IUserTokenService _userTokenService;
    

    public UserAuthorizeService(IUserTokenService userTokenService)
    {
        _userTokenService = userTokenService;
       
    }

    public async Task<UserToken> AuthenticateUser(string username, string password)
    {
        var query = await Task.Run(() => _userTokenService.Validate(username, password));

        return query == null ? null : query;
                 
    }
}