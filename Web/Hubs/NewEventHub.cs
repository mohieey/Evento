using AutoMapper;
using BL.AppServices;
using BL.ViewModels;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Hubs
{
    public class NewEventHub : Hub
    {
        EventAppService eventAppService = new EventAppService();

        public void NewEvent(EventViewModel e)
        {
            Clients.All.NotifyNewEvent(e);
        }

        [HubMethodName("AddTicket")]
        public void AddTicket(string eventName, int eventPrice, string userId)
        {
            Clients.All.AddOrder(eventName, eventPrice, userId);
        }

        [HubMethodName("UpdateEvent")]
        public void UpdateEvent(string eventNameUpdated)
        {
            Clients.All.NotifyEventUpdated(eventNameUpdated);
        }

        [HubMethodName("NotifyAddTicket")]
        public void NotifyAddTicket(string eventName, string userName)
        {
            Clients.All.NotifyBookTicket(eventName, userName);
        }
    }
}