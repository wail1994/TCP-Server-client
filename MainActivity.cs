using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Android.Views;
using System.Net.Sockets;
using System.Text;
using Java.Interop;

namespace App16
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button button;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);



           



            


        }
        [Export("C")]
        public void C(View v )
        {
             button = FindViewById<Button>(Resource.Id.button1);

            button.Click += delegate
            {
                string textToSend = "hi";

                //---create a TCPClient object at the IP and port no.---
                TcpClient client = new TcpClient("192.168.1.8", 5555);
                NetworkStream nwStream = client.GetStream();
                byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(textToSend);

                //---send the text---
              
                nwStream.Write(bytesToSend, 0, bytesToSend.Length);

                //---read back the text---


                client.Close();
                nwStream.Close();
               




            };
        }
    }
}