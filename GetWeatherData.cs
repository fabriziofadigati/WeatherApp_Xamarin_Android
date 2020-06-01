using System;
using System.IO;
using Android.App;
using Android.Content;

using Newtonsoft.Json;
using System.Net;

namespace WeatherApp
{
    class GetWeatherData
    {

        public static WeatherData Chiamata(String city, Context context)
        {
            

            try
            {
                var request = HttpWebRequest.Create(Constants.OpenWeatherMapEndpoint + "?q=" + city + "&APPID=" + Constants.OpenWeatherMapAPIKey);
                request.ContentType = "application/json";
                request.Method = "GET";

                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                if(response.StatusCode != HttpStatusCode.OK)
                {
                    var dialog = new AlertDialog.Builder(context);
                    dialog.SetMessage("Errore " + response.StatusCode + ": riprova più tardi");
                    dialog.SetNeutralButton("Ok",
                      delegate
                      {

                      });
                    dialog.Show();
                    return null;
                }
                StreamReader reader = new StreamReader(response.GetResponseStream());
                var content = reader.ReadToEnd();
                if (string.IsNullOrWhiteSpace(content))
                {
                    var dialog = new AlertDialog.Builder(context);
                    dialog.SetMessage("Città non consultabile o campo vuoto");
                    dialog.SetNeutralButton("Ok",
                      delegate
                      {

                      });
                    dialog.Show();
                    return null;
                }

                WeatherData w = JsonConvert.DeserializeObject<WeatherData>(content);
                return w;
            }
            catch (Exception e)
            {
                var dialog = new AlertDialog.Builder(context);
                dialog.SetMessage("Errore, riprova più tardi");
                dialog.SetNeutralButton("Ok",
                  delegate
                  {

                  });
                dialog.Show();
                return null;
            }

            

        }
    }
}