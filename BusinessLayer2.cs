using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace c_sharp_thread
{
    public struct User
    {
        //"id": 1,
        //  "name": "Leanne Graham",
        //  "username": "Bret",
        //  "email": "Sincere@april.biz",
        //  "address": {
        //    "street": "Kulas Light",
        //    "suite": "Apt. 556",
        //    "city": "Gwenborough",
        //    "zipcode": "92998-3874",
        //    "geo": {
        //      "lat": "-37.3159",
        //      "lng": "81.1496"
        //    }
        //  },
        //  "phone": "1-770-736-8031 x56442",
        //  "website": "hildegard.org",
        //  "company": {
        //    "name": "Romaguera-Crona",
        //    "catchPhrase": "Multi-layered client-server neural-net",
        //    "bs": "harness real-time e-markets"
        //  }
        //},
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
    }

    //"userId": 1,
    //"id": 3,
    //"title": "ea molestias quasi exercitationem repellat qui ipsa sit aut",
    //"body": "et iusto sed quo iure\nvoluptatem occaecati omnis eligendi aut ad\nvoluptatem doloribus vel accusantium quis pariatur\nmolestiae porro eius odio et labore et velit aut"

        public struct Post
    {
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }

    }

    public class BusinessLayer2
    {
        public static void ProcessUserData(int data, Action< List<User> > updateUICallback)
        {  
            Task.Factory.StartNew(
                () =>
                {
                    // do request 

                    string html = string.Empty;
                    string url = @"https://jsonplaceholder.typicode.com/users"; //  https://api.stackexchange.com/2.2/answers?order=desc&sort=activity&site=stackoverflow";

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.AutomaticDecompression = DecompressionMethods.GZip;

                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    using (Stream stream = response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        html = reader.ReadToEnd();
                    }

                    return html;

                })
                .ContinueWith((cw) =>
                {
                    var users = JsonHelper.JsonDeserialize<List<User>>(cw.Result);
                    updateUICallback(users);                 
                });
        }

        public static void ProcessPostData(int data, Action<List<Post>> updateUICallback)
        {
            Task.Factory.StartNew(
                () => {
                    // do request 

                    string html = string.Empty;
                    string url = @"https://jsonplaceholder.typicode.com/posts"; //  https://api.stackexchange.com/2.2/answers?order=desc&sort=activity&site=stackoverflow";

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.AutomaticDecompression = DecompressionMethods.GZip;

                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    using (Stream stream = response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        html = reader.ReadToEnd();
                    }

                    return html;

                })
                .ContinueWith((cw) => {
                    try
                    {
                        var posts = JsonHelper.JsonDeserialize<List<Post>>(cw.Result);
                        updateUICallback(posts);
                    }
                    catch (Exception err)
                    {

                    }
                });
        }

    }
}
