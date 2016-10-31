using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SignalR_Dykes.Models;
using System.Web.Script.Serialization;

namespace SignalR_Dykes.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        public ActionResult Chat()
        {
            IEnumerable<Message> m = Message("", "alice");
            
            return View(m);
        }

        public List<Message> Message(string userId, string userName)
        {
            List<Message> result = new List<Message>();
            StreamReader reader;
            try
            {
                reader = new StreamReader(
                           "C:\\Users\\Dylan\\Documents\\visual studio 2015\\Projects\\SignalR-Dykes\\SignalR-Dykes\\messages\\" + userId + "_" + userName + ".txt"
                       );
            }
            catch
            {
                return null;
            }
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                Message message = new Message();
                message = serializer.Deserialize<Message>(line);
                result.Add(message);
            }
            reader.Close();
            return result;
        }
    }
}