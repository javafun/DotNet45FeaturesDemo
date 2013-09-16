using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DotNet45FeaturesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            DefaultCultureForAnAppDomain40();

            DefaultCultureForAnAppDomain45();

            Console.Read();
        }


        static void DefaultCultureForAnAppDomain40()
        {
            Console.OutputEncoding = Encoding.UTF8;

            var culture = CultureInfo.CreateSpecificCulture("ja-JP");            

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            Action randomCurrency = () =>
            {
                Console.WriteLine();
                Console.WriteLine("Current Culture:\t{0}", Thread.CurrentThread.CurrentCulture);
                Console.WriteLine("Current Culture:\t{0}", Thread.CurrentThread.CurrentUICulture);

                Console.WriteLine("Random currency: ");
                var rand = new Random();

                for (int i = 0; i < 2; i++)
                {
                    Console.WriteLine("\t{0:C2}\t", rand.NextDouble());
                }

                Console.WriteLine();
            };

            randomCurrency();

            Task.Factory.StartNew(randomCurrency);
        }

        static void DefaultCultureForAnAppDomain45()
        {
            Console.OutputEncoding = Encoding.UTF8;

            var culture = CultureInfo.CreateSpecificCulture("ja-JP");

            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            
            /*
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
             * */

            Action randomCurrency = () =>
            {
                Console.WriteLine();
                Console.WriteLine("Current Culture:\t{0}", Thread.CurrentThread.CurrentCulture);
                Console.WriteLine("Current Culture:\t{0}", Thread.CurrentThread.CurrentUICulture);

                Console.WriteLine("Random currency: ");
                var rand = new Random();

                for (int i = 0; i < 2; i++)
                {
                    Console.WriteLine("\t{0:C2}\t", rand.NextDouble());
                }

                Console.WriteLine();
            };

            randomCurrency();


            //Task.Factory.StartNew(randomCurrency);
            Task.Run(randomCurrency);

            
        }
    }
}
