using SportPoint.Features.LogIn;

namespace SportPoint.Features.Common
{
    public interface IRestPoolService {

        void UpdateApiUrl(string newApiUrl);


        // List here the rest of the interfaces you'll consider for the app
        IIdentityAPI IdentityAPI { get; }
        IProfilesAPI ProfilesAPI { get; }

        //IHomeAPI HomeAPI { get; }
        //IProductsAPI ProductsAPI { get; }
        //ISimilarProductsAPI SimilarProductsAPI { get; }
        //IProductCartAPI ProductCartAPI { get; }
    }
}
