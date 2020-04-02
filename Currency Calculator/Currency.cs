using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Currency_Calculator
{
    public class Currency
    {
        public String CharCode { get; set; }
        public String Name { get; set; }
        public double Value { get; set; }
        public int Nominal { get; set; }

        public static Currency[] CreateValuta(Currency[] AllValuta)
        {
            var requestUri = "https://www.cbr-xml-daily.ru/daily_json.js";

            string json = String.Empty;
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(requestUri).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                }
            }
            dynamic json1 = JObject.Parse(json);
            JObject json2 = json1.Valute;

            foreach (var val in json2)
            {
                Array.Resize(ref AllValuta, AllValuta.Length + 1);
                AllValuta[AllValuta.Length - 1] = new Currency
                {
                    Name = Convert.ToString(val.Value[key: @"Name"]),
                    CharCode = Convert.ToString(val.Value[key: @"CharCode"]),
                    Value = Convert.ToDouble(val.Value[key: @"Value"]),
                    Nominal = Convert.ToInt32(val.Value[key: @"Nominal"])
                };
            }
            Array.Resize(ref AllValuta, AllValuta.Length + 1);
            AllValuta[AllValuta.Length - 1] = new Currency
            {
                Name = "Российский рубль",
                CharCode = "RUB",
                Value = 1,
                Nominal = 1
            };
            return AllValuta;
        }
    }
    
    
}
