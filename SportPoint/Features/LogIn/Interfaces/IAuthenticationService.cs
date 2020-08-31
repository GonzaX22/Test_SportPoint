using SportPoint.Features.LogIn.Models;
using System.Security;
using System.Threading.Tasks;

namespace SportPoint.Features.LogIn {
    
    public interface IAuthenticationService {
        
        string AuthorizationHeader { get; }

        bool IsAnyOneLoggedIn { get; }

        Task<ProfileResp> LogInAsync(string username, SecureString password);

        Task<ProfileResp> SignUpAsync(string name, string surname, string username, SecureString password);

    }
}
