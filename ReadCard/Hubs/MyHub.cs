using Microsoft.AspNet.SignalR;
using ReadCard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReadCard.Hubs
{
    public class MyHub : Hub
    {

        public static void GetCard(IEnumerable<CCCDCardView> ListC)
        {

            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
            context.Clients.All.getCard(ListC);
        }

        //public void Hello()
        //{
        //    Clients.All.hello();
        //}


        ////[HubMethodName("getCard")]
        //public static void GetCard()
        //{
        //    IHubContext context = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
        //    context.Clients.All.getCard();
        //}
    }
}