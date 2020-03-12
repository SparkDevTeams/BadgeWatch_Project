//Chat Messaging
using Newtonsoft.Json;  
using PushNotification1.Models;  
//Model Directory
namespace PushNotification1.Models  
{  
    public class ChatMessaging 
    {  
        public string users { get; set; }  
        public string message { get; set; }  
        public string dt { get; set; }  
    }  
}  