using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;

namespace NNDDPlayer_Android
{
    [Activity(Label = "NNDDPlayer_Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            VideoView videoView = FindViewById<VideoView>(Resource.Id.videoView1);

            button.Click += delegate 
            {

                videoView.StopPlayback();

                string url = "http://192.168.0.10:12300/NNDDServer/sm29577290";
                
                System.Net.WebRequest req = System.Net.WebRequest.Create(url);

                System.Net.WebResponse res = req.GetResponse();
                
                using (Stream stream = res.GetResponseStream())
                {

                    Java.IO.File[] files = GetExternalCacheDirs();
                    Java.IO.File dir = files[0];

                    string tempFilePath = dir.AbsolutePath + "/temp_video.mp4";

                    if (File.Exists(tempFilePath))
                    {
                        File.Delete(tempFilePath);
                    }

                    FileStream tempFile = File.Create(tempFilePath);

                    stream.CopyTo(tempFile);
                    stream.Close();
                    tempFile.Close();

                    videoView.SetVideoPath(tempFilePath);

                    //videoView.SetVideoURI(uri);
                    //videoView.Start();

                }
            };

            videoView.Prepared += delegate
            {
                videoView.Start();
            };
        }

    }
}

