using BL.AppServices;
using BL.ViewModels;
using DAL;
using Microsoft.AspNet.Identity;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.tests
{
    //[SetUp]
    //[OneTimeSetUp]
    //[TearDown]
    //[OneTimeTearDown]


    [TestFixture]
    class ShoppingCartAppService_Tests
    {
        //
        //
        public AccountAppService accountAppService;
        public ShoppingCartAppService shoppingCartAppService;
        public ApplicationIdentityUser user;

        [OneTimeSetUp]
        public void ShoppingCartSetup()
        {
            accountAppService = new AccountAppService();
            shoppingCartAppService = new ShoppingCartAppService();
            user = accountAppService.Find("TestUser", "TestUser");
        }

        [Test]
        public void GetShoppingCartByUserId_Test()
        {
            string result = shoppingCartAppService.GetShoppingCartByUserId(user.Id).ClientId;
            Assert.That(result, Is.EqualTo(user.Id));
        }
    }
}
