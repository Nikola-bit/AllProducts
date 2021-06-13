using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace ConsoleAppProducts
{
    class Program
    {
        #region product
        public class Products
        {
            // [JsonProperty(PropertyName = "name")]
            public string name { get; set; }
            //[JsonProperty(PropertyName = "domestic")]
            public bool domestic { get; set; }
            //[JsonProperty(PropertyName = "price")]
            public double price { get; set; }
            // [JsonProperty(PropertyName = "weight")]
            public string weight { get; set; }
            //  [JsonProperty(PropertyName = "description")]
            public string description { get; set; }
            public void PrintDomestic()
            {
                Console.WriteLine("Name: {0}" +
                                  "\nPrice: {1}" +
                                 "\nweight: {2}" +
                                  "\ndescription: {3}", name, price, weight, description.Truncate(30));

            }
            public void PrintImported()
            {
                Console.WriteLine("Name: {0}" +
                                  "\ndomestic: {1}" +
                                  "\nPrice: {2}" +
                                 "\nweight: {3}" +
                                  "\ndescription: {4}", name, domestic, price, weight, description.Truncate(30));

            }
        }
        #endregion



        static void Main(string[] args)
        {
            var url = "https://interview-task-api.mca.dev/qr-scanner-codes/alpha-qr-gFpwhsQ8fkY1";

            var json = new WebClient().DownloadString(url);
           

            var articles = JsonConvert.DeserializeObject<List<Products>>(json).ToList();

            List<string> allUrls = new List<string>();

            allUrls = articles.Select(u => u.name).ToList();
            articles.Sort(delegate (Products x, Products y) {
                return x.name.CompareTo(y.name);
            });
            List<Products> pr = articles.Where(x => x.domestic == true).ToList();
            List<Products> pro = articles.Where(x => x.domestic == false).ToList();
            decimal i, z, e, s;
            z = 0;
            s = 0;
            Console.WriteLine("Domestic Items");
            foreach (Products c in pr)
            {
                i = (decimal)c.price;
                z = z + i;
                if (c.weight == "0" || c.weight == "")
                {
                    c.weight = "N/A";
                }
                c.PrintDomestic();


            }
            Console.WriteLine("------------------------------");
            Console.WriteLine("Imported Items");
            foreach (Products c in pro)
            {

                e = (decimal)c.price;
                s = s + e;
                if (c.weight == "0" || c.weight == " ")
                {
                    c.weight = "N/A";
                }
                c.PrintImported();


            }

            Console.WriteLine("------------------------------");
            Console.WriteLine("Domestic cost: $ {0}", z);
            Console.WriteLine("Imported cost: $ {0}", s);
            Console.WriteLine("Domestic count : {0}", pr.Count);
            Console.WriteLine("Imported count : {0}", pro.Count);
        }
    }
    }


