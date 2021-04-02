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
        public void NewEvent(EventViewModel e)
        {
            Clients.All.NotifyNewEvent(e);
        }

        [HubMethodName("AddTicket")]
        public void AddTicket(string eventName, int eventPrice, string userId)
        {
            Clients.All.AddOrder(eventName, eventPrice, userId);
        }
    }
}