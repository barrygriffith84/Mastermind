using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MasterMind.APIManager
{
    internal class APIManager
    {

        private static string _baseURL = "https://www.random.org/integers/?num=4&min=0&max=7&col=1&base=10&format=plain&rnd=new";

        internal static async Task<List<string>> GetRandomNumbers()
        {
            List<string> numbers = new List<string>();

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(_baseURL))
                    {
                        if (res.ReasonPhrase != "OK")
                        {
                            throw new Exception("ReasonPhrase was not OK");
                        }

                        using (HttpContent content = res.Content)
                        {
                            var data = await content.ReadAsStringAsync();

                            List<string> onlyNumbersStringList = data.Split('\n')
                                                                     .Where(str => !string.IsNullOrEmpty(str))
                                                                     .ToList();


                            numbers = onlyNumbersStringList;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                numbers = GenerateRandomNumbersLocally();
            }

            return numbers;
        }



        internal static List<string> GenerateRandomNumbersLocally()
        {
            Random random = new Random();
            List<string> randomNumbersList = new List<string>();

            for (int i = 0; i < 4; i++)
            {
                int currentInt = random.Next(8);
                randomNumbersList.Add(currentInt.ToString());
            }

            return randomNumbersList;
        }

    }
}
