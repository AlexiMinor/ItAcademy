using System.Net.Mime;
using Hangfire;
using ItAcademy.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ItAcademy.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public TestController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet]
        public async Task<IActionResult> RecurringJobInit()
        {
            //optional algorithm for article rate
            const string data =
                "Цены на авиабилеты редко приводят в восторг, но это как раз такой случай: авиабилеты первого класса туда и обратно из Австралии в США можно было купить со скидкой 85%. Обычно эти билеты стоят у авиакомпании Qantas около 19 000 долларов. Из-за сбоя около 300 счастливчиков смогли купить их на сайте авиакомпании за 3400 долларов, пока ошибку не исправили.«К сожалению, это тот случай, когда тариф был слишком хорош, чтобы быть правдой», — заявили в авиакомпании.Тем не менее Qantas не аннулировала проданные по ошибке билеты, а пообещала перебронировать их в бизнес-класс «в качестве жеста доброй воли» без дополнительной платы. Кроме того, пассажиры, которых не устраивает бизнес-класс, могут получить полный возврат денег.Перелет бизнес-классом на рейсах Qantas между Австралией и США обычно стоит около 11 000 долларов, уточняет CNN.Это не первый случай, когда авиакомпании по ошибке продавали билеты по вопиюще низким ценам. И иногда они действительно перевозили пассажиров с такими билетами.Но бывает и наоборот. Например, авиакомпания British Airways ошибочно продавала за 40 долларов билеты из Северной Америки в Индию, а когда ошибка была обнаружена, то предложила вместо этого ваучеры на 300 долларов.Авиакомпания American Airlines отказалась предоставить места первого класса из США в Австралию стоимостью до 20 000 долларов, которые она продавала по цене эконом-класса — 1100 долларов. Вместо этого она предложила ваучеры на 200 долларов.";
            var key = "5bb1435cfbfff510af2d0ae87bf1d15aeee5bbdf";
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Post,
                    $"http://api.ispras.ru/texterra/v1/nlp?targetType=lemma&apikey={key}");
                
                request.Headers.Add("Accept", "application/json");
                request.Content = JsonContent.Create(new[]
                {
                    new { Text = data }
                });
                
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var responseString= await response.Content.ReadAsStringAsync();
                    
                    
                    //var lemmas = //JsonConvert.DeserializeObject<>
                    
                    //lemmasDictionary
                   
                    //based on dict calculate rate of your article
                    
                    return Ok(responseString);
                }
                else
                {
                    return StatusCode(500);
                }
            }
            //RecurringJob.AddOrUpdate(
            //    "RssDataAggregation", 
            //    () => _articleService.AggregateAsync(),
            //  "0/30 * * * *");
            //RecurringJob.AddOrUpdate(
            //    "WebScrapping",
            //    () => _articleService.AggregateAsync(),
            //    "0/30 * * * *");

            return Ok();
        }
        
        [HttpPost]
        public async Task<IActionResult> FireAndForget()
        {
            var jobId = BackgroundJob.Enqueue(() => Console.WriteLine("hello"));
            var delayedJobId = BackgroundJob.Schedule(() => Console.WriteLine("delayed"), 
                TimeSpan.FromMinutes(15));
            var jobAfterFaFId = BackgroundJob.ContinueJobWith(jobId, () => Console.WriteLine("world"));
            
            return Ok();
        }
    }
}
