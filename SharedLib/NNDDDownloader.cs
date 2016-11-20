using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace SharedLib
{
    public class NNDDDownloader
    {

        public NNDDDownloader()
        {

        }

        public void downloadByVideoId(string videoId)
        {

        }

        public void downloadByNNDDServer(string videoId, string serverUrl)
        {
            //string serverUrl = "http://localhost:12300/NNDDServer";


            //downloadByUri(new Uri(serverUrl + ""))

        }

        public void downloadByUri(Uri url)
        {

            WebRequest req = WebRequest.Create(url);

            //メソッドにGETを指定
            req.Method = "GET";

            req.GetRequestStream();




        }



    }
}
