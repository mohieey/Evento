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
        public Event Event1 { get; set; }
        public Event Event2 { get; set; }

        [OneTimeSetUp]
        public void EventAppServiceStartup()
        {
            accountAppService = new AccountAppService();
            eventAppService = new EventAppService();
            host = accountAppService.Find("TestHost", "TestHost");



            EventViewModel eventViewModel = new EventViewModel();
            eventViewModel.HostId = host.Id;
            eventViewModel.Name = "TestEvent1";
            eventViewModel.location = "Test";
            eventViewModel.price = 4;
            eventViewModel.TotalAvailableTickets = 5;
            eventViewModel.category = 0;
            eventViewModel.date = DateTime.Now;
            Event1 = eventAppService.SaveNewEvent(eventViewModel);



        }

        [OneTimeTearDown]
        public void EventAppServiceTearDown()
        {
            eventAppService.DeleteEvent(Event1);
            eventAppService.DeleteEvent(Event2);
        }


        [Test]
        public void GetAllEventsById_Test()
        {
            int id = Event1.ID;
            int eventId = eventAppService.GetEventById(id).ID;
            Assert.That(eventId, Is.EqualTo(id));
        }




        [Test]
        public void SaveNewEvent_Test()
        {
            EventViewModel eventViewModel = new EventViewModel();
            eventViewModel.HostId = host.Id;
            eventViewModel.Name = "TestEvent2";
            eventViewModel.location = "Test";
            eventViewModel.price = 4;
            eventViewModel.TotalAvailableTickets = 5;
            eventViewModel.category = 0;
            eventViewModel.date = DateTime.Now;


            Event2 = eventAppService.SaveNewEvent(eventViewModel);
            Assert.That(Event2, Is.Not.Null);
        }
    }
}
