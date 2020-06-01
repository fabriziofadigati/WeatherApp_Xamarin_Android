using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;

namespace WeatherApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText input;
        Button search;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            input = FindViewById<EditText>(Resource.Id.input);
            search = FindViewById<Button>(Resource.Id.searchbutton);

            search.Click += Search_Click;

        }

        private void Search_Click(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(input.Text))
            {
                string city = input.Text;
                var intent = new Intent(this, typeof(ResultActivity));
                intent.PutExtra("city", city);
                StartActivity(intent);
            }
            else
            {

                var dialog = new Android.App.AlertDialog.Builder(ApplicationContext.ApplicationContext);
                dialog.SetMessage("Campo città vuoto");
                dialog.SetNeutralButton("Ok",
                  delegate
                  {

                  });
                dialog.Show();

            }

        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

    }

}
