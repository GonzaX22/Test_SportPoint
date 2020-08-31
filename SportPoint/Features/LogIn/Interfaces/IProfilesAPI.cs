using System.Threading.Tasks;
using SportPoint.Features.LogIn.Models;

namespace SportPoint.Features.LogIn
{
    public interface IProfilesAPI {

        Task<ProfileResp> GetUserAsync();

        Task<ProfilesResp> GetUsersAsync();

        Task<ProfileResp> CreateUserAsync(ProfileReq profile);

    }

}
