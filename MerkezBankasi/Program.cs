using System.Xml;

namespace MerkezBankasi
{
    internal class Program
    {
        /*
         
         Kaynak Kodlar Github uzerinden alinmistir.
          https://github.com/fatihgol/TCMBExchangeRates
         */



        static void Main(string[] args)
        {



            string exchangeRate = @"http://www.tcmb.gov.tr/kurlar/today.xml";
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(exchangeRate);


            for (int i = 2; i < 10; i++)
            {
                var result = CurrenciesExchange.GetAllCurrenciesHistoricalExchangeRates(2023, 1, i);
                Console.WriteLine(result);
            }


          


        }
    }
}