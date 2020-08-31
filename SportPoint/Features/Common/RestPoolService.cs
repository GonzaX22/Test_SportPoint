using Refit;
using SportPoint.Features.LogIn;
using SportPoint.Features.Settings;
using SportPoint.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportPoint.Features.Common
{
    public class RestPoolService : IRestPoolService
    {

        public IIdentityAPI IdentityAPI { get; } = new IdentityAPI();
        public IProfilesAPI ProfilesAPI { get; } = new ProfileAPI();

        //public IHomeAPI HomeAPI { get; private set; }
        //public IProductsAPI ProductsAPI { get; private set; }
        //public ISimilarProductsAPI SimilarProductsAPI { get; private set; }
        //public IProductCartAPI ProductCartAPI => new FakeProductCartAPI();

        public void UpdateApiUrl(string newApiUrl) {
            //* All temporary disabled *//

            //LoginAPI = RestService.For<ILoginAPI>(
            //    HttpClientFactory.Create(newApiUrl))
            ////ProfilesAPI = RestService.For<IProfilesAPI>(
            ////    HttpClientFactory.Create(DefaultSettings.RootWebApiUrl));
            //ProfilesAPI = RestService.For<IProfilesAPI>(
            //    HttpClientFactory.Create(newApiUrl));
            //HomeAPI = RestService.For<IHomeAPI>(
            //    HttpClientFactory.Create(newApiUrl));
            //ProductsAPI = RestService.For<IProductsAPI>(
            //    HttpClientFactory.Create(newApiUrl));
            //SimilarProductsAPI = RestService.For<ISimilarProductsAPI>(
            //    HttpClientFactory.Create(newApiUrl));
        } 

        public RestPoolService() { 
            UpdateApiUrl(GlobalSettings.RootApiUrl);
        }
    }
}
