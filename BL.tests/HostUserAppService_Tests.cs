﻿using BL.AppServices;
using BL.ViewModels;
using DAL;
using DAL.User;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.tests
{
    class HostUserAppService_Tests
    {
        HostUserAppService hostUserAppService;
        AccountAppService accountAppService;
        HostUserViewModel hostUserViewModel;
        private ApplicationIdentityUser hostUser { get; set; }
        private HostUser hostUserUpdated { get; set; }

        [OneTimeSetUp]
        public void HostUserSetUp()
        {
            hostUserAppService = new HostUserAppService();
            accountAppService = new AccountAppService();
            hostUser = accountAppService.Find("TestHost", "TestHost");
        }

        [OneTimeTearDown]
        public void HostUserTearDown()
        {
            hostUserViewModel = new HostUserViewModel
            {
                ID = hostUser.Id,
                UserName = "TestHost",
            };
            hostUserAppService.UpdateHostUser(hostUserViewModel);
        }

        [Test, Category("GetAllHostUser")]
        public void Check_On_UserName_Of_Item_In_List_Of_HostUsers()
        {
            List<HostUserViewModel> hostUsers = hostUserAppService.GetAllHostUser();
            Assert.That(hostUsers,
                Has.Exactly(1).
                Matches<HostUserViewModel>(h => h.UserName.Contains("TestHost")));
        }

        [Test, Category("GetHostUserById")]
        public void Check_On_Get_Host_User_By_Sending_Id()
        {
            string actualHostUserId = hostUserAppService.GetHostById(hostUser.Id).ID;
            Assert.AreEqual(hostUser.Id, actualHostUserId);
        }

       [Test, Category("UpdateHostUser")]
       public void Test_Update_Host_UserName()
        {
            hostUserViewModel = new HostUserViewModel
            {
                ID = hostUser.Id,
                UserName = "TestHostUpdated",
            };

            hostUserUpdated = hostUserAppService.UpdateHostUser(hostUserViewModel);
            Assert.That(hostUserUpdated.user.UserName, Is.EqualTo(hostUserViewModel.UserName));
        }
    }
}
