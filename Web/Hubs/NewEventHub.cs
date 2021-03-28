using BL.ViewModels;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
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
    }
}