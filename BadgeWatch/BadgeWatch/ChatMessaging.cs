using System;
using System.*;
using Newtonsoft.Json;  
using PushNotification.Models;  //class inside of model directory
/*Currently filled with errors only pushing this one to show what I'm working on. I don't have VS studio and alot of 
tutorials are around just simply going through the options. I've already made a box in a seperate file but I can't see
it as I don't have Studio. So I can't see what it looks like. If I can acces the options it will be alot easier. Since
I can't see I'll post and see from someone elses studio.
*/


namespace PushNotication.Controllers
{
  public class ChatMessaging : ApiController
  {
      private static ConcurrentBag<StreamWriter> clients;   //https://stackoverflow.com/questions/37491563/trouble-getting-json-response-from-api-in-c-sharp-mvc
        static ChatController(){
            clients = new ConcurrentBag<StreamWriter>();
        }

        private async Task CallBackMessage(ChatMessage i)
        {
            foreach (var item in collection)
            {
                try{
                    var info = string.Format("data:{0}|{1}|{2}\n\n", i.users, m.text, m.dt);
                    await item.WriteAsync(info);
                    await item.FlushAsync();
                    client.Dispose();
                }
                catch (Except){
                    StreamWriter ignore;
                    collection.TryTake(out ignore);
                }
            }
        }
        //[HttpGet]
        public ResponseMessage Subscribe(ResponseMessage i){
            var response = i.CreateResponse();
            response.Content = new PushStreamContent((a, b, c) => { OnStreamAvailable(a, b, c);}, "text/event-stream" );
            return response;
        }
        //Error 
        private void OnStreamAvailable(Stream s, HttpContent hc, TransportContext tc)  
        {  
            var client = new StreamWriter(s);  
            collection.Add(client);  
        }  
  }  
}