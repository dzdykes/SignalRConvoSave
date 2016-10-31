using System;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.IO;
using SignalR_Dykes.Models;
using System.Web.Script.Serialization;
using System.Collections.Generic;

namespace SignalRChat
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            // Call the addNewMessageToPage method to update clients.
            SaveMessage(null, name, message);
            Clients.All.addNewMessageToPage(name, message);
        }


        public void SaveMessage(string userId, string userName, string userMessage)
        {
            var m = new Message
            {
                id = userId,
                name = userName,
                message = userMessage,
                dateTime = DateTime.UtcNow
            };
            var json = new JavaScriptSerializer().Serialize(m);
            using (StreamWriter w = File.AppendText("C:\\Users\\Dylan\\Documents\\visual studio 2015\\Projects\\SignalR-Dykes\\SignalR-Dykes\\messages\\" + userId + "_" + userName + ".txt"))
            {
                w.WriteLine(json.ToString().Replace("\n", ""));
                w.Close();
            }
        }

    }
}