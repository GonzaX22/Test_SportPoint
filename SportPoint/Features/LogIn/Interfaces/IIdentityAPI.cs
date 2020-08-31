using SportPoint.Features.LogIn.Models;
using System.Threading.Tasks;

namespace SportPoint.Features.LogIn
{
    public interface IIdentityAPI {

        Task<TokenResp> GetTokenAsync(TokenReq request);

        Task<TokenResp> GetTokenAsync();

    }
}
