using BL.AppServices;
using BL.ViewModels;
using DAL;
using NUnit.Framework;
using System;

namespace BL.tests
{
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
            eventViewModel.HostId = accountAppService.Find("TestHost","TestHost").Id;
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
