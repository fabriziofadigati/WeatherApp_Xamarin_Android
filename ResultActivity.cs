using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System;

namespace WeatherApp
{
    [Activity(Label = "ResultActivity")]
    public class ResultActivity : Activity
    {
        TextView city;
        TextView temperature;
        TextView windspeed;
        TextView humidity;
        TextView time;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.result_layout);

            city = FindViewById<TextView>(Resource.Id.city);
            temperature = FindViewById<TextView>(Resource.Id.temperature);
            windspeed = FindViewById<TextView>(Resource.Id.windspeed);
            humidity = FindViewById<TextView>(Resource.Id.humidity);
            time = FindViewById<TextView>(Resource.Id.visibility);

            string extracted_city = Intent.Extras.GetString("city");

            WeatherData w = GetWeatherData.Chiamata(extracted_city, this);
            Double temp = Double.Parse(w.main["temp"]) - 273.15;

            city.Text = extracted_city;
            temperature.Text = Convert.ToString(temp) + " °C";
            windspeed.Text = w.wind["speed"] + " nodi";
            humidity.Text = w.main["humidity"] + "%";
            time.Text = w.visibility + " metri";


        }
    }
}