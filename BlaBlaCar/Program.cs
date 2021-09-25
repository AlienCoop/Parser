using Newtonsoft.Json.Linq;
using System;

namespace BlaBlaCar
{
    class Program
    {
        static void Main(string[] args)
           
        {
            var key = "bzxKThZ8TWYxCyX6r5Juzh6omErxATBC";
            var coord1 = "51.7727000,55.0988000";
            var coord2 = "55.7522200,37.6155600";
            var currency = "RUB";
            var data = DateTime.Now.ToString("yyyy-MM-ddT00:00:00");
            var country = "ru-RU";

            var request = new GetRequest($"https://public-api.blablacar.com/api/v3/trips?from_coordinate={coord1}&to_coordinate={coord2}&locale={country}&currency={currency}&start_date_local={data}&key={key}");
            request.Run();

            var response = request.Response;

            var json = JObject.Parse(response);
            var trips = json["trips"];
          
            foreach (var trip in trips)
            {
                var price = trip["price"];
                var amount = price["amount"];
                Console.WriteLine($"Цена поездки={amount}руб");

            }

        }
    }
}
