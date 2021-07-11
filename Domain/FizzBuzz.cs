using System;
using System.Net.Http;

namespace Domain
{
    public class FizzBuzz : IFizzBuzz
    {
        public string CalculateResult()
        {
            using (var client= new HttpClient())
            {
                var value =  client.GetAsync("https://localhost:5001/Peer").Result.Content.ReadAsStringAsync().Result.Split(":");
                if (value.Length == 2)
                {
                    return $"{int.Parse(value[0]) * int.Parse(value[1])}";
                }
                else
                {
                    var A = int.Parse(value[0]);
                    var B = int.Parse(value[1]);
                    var C = int.Parse(value[2]);

                    return $"{(C % A == 0 ? "FIZZ" : string.Empty)}{(C % B == 0 ? "BUZZ" : string.Empty)}";
                } 
            }
        }
    }
}
