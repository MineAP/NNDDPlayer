using System;

using UIKit;

namespace NNDDPlayer_iOS
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            string html = "<video id='video' width='300' height='200' src='{0}' controls autoplay></video>";
            html = String.Format(html, "http://192.168.0.10:12300/NNDDServer/sm29577290");

            webView.LoadHtmlString(html, null);

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}