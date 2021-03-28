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



    [TestFixture]
    class EvevntAppService_Tests
    {
        public EventAppService eventAppService;
        public AccountAppService accountAppService;
        public ApplicationIdentityUser host;

        [OneTimeSetUp]
        public void EventAppServiceStartup()
        {
            accountAppService = new AccountAppService();
            eventAppService = new EventAppService();
            host = accountAppService.Find("TestHost", "TestHost");
        }


        [Test]
        public void GetAllEventsById_Test()
        {
            int id = 1;
            int eventId = eventAppService.GetEventById(id).ID;
            Assert.That(eventId, Is.EqualTo(id));
        }




        [Test]
        public void SaveNewEvent_Test()
        {
            EventViewModel eventViewModel = new EventViewModel();
            eventViewModel.HostId = "1634bca1-433c-4c78-8df5-06aea8ae71fc";
            eventViewModel.Name = "TestEvent";
            eventViewModel.location = "Test";
            eventViewModel.price = 4;
            eventViewModel.TotalAvailableTickets = 5;
            eventViewModel.category = 0;
            eventViewModel.date = DateTime.Now;


            bool result = eventAppService.SaveNewEvent(eventViewModel);
            Assert.That(result, Is.EqualTo(true));
        }
    }
}
