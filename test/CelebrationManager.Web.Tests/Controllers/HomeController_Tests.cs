using System.Threading.Tasks;
using CelebrationManager.Models.TokenAuth;
using CelebrationManager.Web.Controllers;
using Shouldly;
using Xunit;

namespace CelebrationManager.Web.Tests.Controllers
{
    public class HomeController_Tests: CelebrationManagerWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}