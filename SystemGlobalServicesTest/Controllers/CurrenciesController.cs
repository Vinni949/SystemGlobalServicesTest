using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Security.Policy;
using SystemGlobalServicesTest.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SystemGlobalServicesTest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CurrenciesController : ControllerBase
    {
       
        // GET: api/<CurrenciesController>
        [HttpGet]
        public IEnumerable<Currency> GetAll(int? page)
        {
           
            DBTest DBTest = new DBTest();
            int pageSize = 20;
            page = page ?? 0;
            List<Currency> currencies = new List<Currency>();
            currencies = DBTest.Currency.Skip(pageSize * page.Value).Take(pageSize).ToList();
            return currencies;
        }

        // GET api/<CurrenciesController>/5
        [HttpGet("{id}")]
        public string Get(string idCurency)
        {
            DBTest DBTest = new DBTest();
            Currency currency = DBTest.Currency.SingleOrDefault(p => p.idCurrency == idCurency);
            if (currency != null)
            {
                return currency.ToString();
            }
            else
                return "Валюта не найдена!";
        }


        // DELETE api/<CurrenciesController>/5
        [HttpDelete("{id}")]
        public string Delete(string idCurrency)
        {
            DBTest DBTest = new DBTest();
            Currency dellCurrancy = DBTest.Currency.SingleOrDefault(p => p.idCurrency == idCurrency);
            if (dellCurrancy != null)
            {
                DBTest.Currency.Remove(dellCurrancy);
                DBTest.SaveChanges();
                return "${idCurrency} Удалено!";
            }
            else
                return "Значение не найдено!";
        }
        [HttpPost("AddCurrency")]
        public void AddCurrency()
        {
            DBTest DBTest = new DBTest();
            String url = "https://www.cbr-xml-daily.ru/daily_json.js";
            string jsonString;
            using (HttpClient client = new HttpClient())
            {
                jsonString = client.GetStringAsync(url).Result;
            }

            JObject jObject = JObject.Parse(jsonString);
            foreach (var item in jObject["Valute"].Values())
            {
                Currency currency = new Currency();
                currency.idCurrency = (String)item["ID"];
                currency.numCode = (int)item["NumCode"];
                currency.charCode = (String)item["CharCode"];
                currency.nominal = (int)item["Nominal"];
                currency.name = (String)item["Name"];
                currency.value = (float)item["Value"];
                currency.previous = (float)item["Previous"];
                DBTest.Currency.Add(currency);
                DBTest.SaveChanges();
            }

        }
        
    }
}



