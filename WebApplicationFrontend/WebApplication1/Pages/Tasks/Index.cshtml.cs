using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Pages.Tasks
{
    using NameLink = KeyValuePair<string, string>;
    public class TasksModel : PageModel
    {
        private readonly ILogger<TasksModel> _logger;
        public string openedFrame;
        public string openedFrameKey;
        public Dictionary<string, NameLink> frames = new Dictionary<string, NameLink>();
        public TasksModel(ILogger<TasksModel> logger)
        {
            _logger = logger;
            frames.Add("task1", new NameLink("Тенденция изменения средней зарплаты в Москве по основным ЯП",
                "http://localhost:5601/goto/a88e65d6ecc17786b39026d3a63a0969"));
            frames.Add("task2", new NameLink("Тенденция изменения средней зарплаты в России по основным ЯП",
               "http://localhost:5601/goto/dcc25ce3f40ce604acc8e960d0b23bc4"));
            frames.Add("task3", new NameLink("Тенденция изменения средней зарплаты в СПб по основным ЯП",
                "http://localhost:5601/goto/77a95401da493b044f66b6f7f1b0f854"));
            frames.Add("task5", new NameLink("Распределение вакансий по городам",
                "http://localhost:5601/goto/d91ef1b46f06e3843af6559e2ff75297"));
            frames.Add("task6", new NameLink("Наиболее популярные ЯП в крупных городах России",
                "http://localhost:5601/goto/ffb731cb974858b314dc24dc0d5290b4"));
            frames.Add("task12", new NameLink("Количество вакансий по языкам программирования в крупных городах России",
                "http://localhost:5601/goto/42ec063a73688f38398cf793b9680fdb"));
            frames.Add("task7", new NameLink("Валютное распределение вакансий",
                "http://localhost:5601/goto/5f5af190337a0e9b3ab4bdc021b9d94e"));
            frames.Add("task8", new NameLink("Валютное распределение вакансий в Минске",
                "http://localhost:5601/goto/8e9a4e6f11c49c553bef3cbe230ee8b1"));
            frames.Add("task9", new NameLink("Валютное распределение вакансий в Москве и СПб",
                "http://localhost:5601/goto/06fff0db450346f24ede75d6f3b86bed"));
            frames.Add("task10", new NameLink("Требуемый уровень владения английским",
                "http://localhost:5601/goto/3fdb734c3145f78bc5bbbe875d6ec6ab"));
            frames.Add("task11", new NameLink("Популярность языков программирования",
                "http://localhost:5601/goto/7886780cbe2c0834364b93e2e2482e2a"));
            frames.Add("task4", new NameLink("Наиболее популярные фреймворки (backend)",
                "http://localhost:5601/goto/8c4e55aa3920ba6ba52d4042fd14a3fd"));
            frames.Add("task13", new NameLink("Требуемая квалификация специалиста",
                "http://localhost:5601/goto/442ae408f4c7ea61c1d4c5a5c10aea93"));
            frames.Add("task14", new NameLink("Количество вакансий по станциям метро Москвы",
                "http://localhost:5601/goto/86c15d8eaa2e8516a3c0aa9d74769530"));
            frames.Add("task15", new NameLink("Количество вакансий по станциям метро СПб",
                "http://localhost:5601/goto/b729fdc55308fe5e8957a4da8cfe0a1f"));
            frames.Add("task16", new NameLink("Популярность вакансий по сферам разработки ПО",
                "http://localhost:5601/goto/3f6fc133445b2151bfc5c738f051b064"));
            frames.Add("task17", new NameLink("Количество вакансий по уровню зарплаты",
                "http://localhost:5601/goto/e483bb161ce6ebf3f988dde866b795de"));
            frames.Add("task18", new NameLink("Количество вакансий по уровню зарплаты в Москве",
                "http://localhost:5601/goto/2f4688a2cfa779dd0451924d251ee51a"));
            frames.Add("task19", new NameLink("Количество вакансий по уровню зарплаты в СПб",
                "http://localhost:5601/goto/649dab8c2b42882f8d983f26bf9c1148"));
            frames.Add("task20", new NameLink("Средняя зарплата по крупным городам России",
                "http://localhost:5601/goto/0a28875f1c5c21425838baed14097778"));
            frames.Add("task21", new NameLink("Зарплатная вилка по популярным языкам программирования",
                "http://localhost:5601/goto/d1ce8a46f8abe91f3100935a2d9ee618"));
            frames.Add("task22", new NameLink("Зарплатная вилка junior-разработчиков по популярным языкам программирования",
                "http://localhost:5601/goto/d1eaf391b2f3afb6941b2589d986e360"));
            frames.Add("task23", new NameLink("Зарплатная вилка middle-разработчиков по популярным языкам программирования",
                "http://localhost:5601/goto/9d6f719a15139623138d8a422ca70cec"));
            frames.Add("task24", new NameLink("Зарплатная вилка senior-разработчиков по популярным языкам программирования",
                "http://localhost:5601/goto/8d8c6a2453cf45cb382d4000fdf51582"));
            frames.Add("task25", new NameLink("Количество вакансий по типу занятости",
                "http://localhost:5601/goto/7cbf9477268963b7637b2785bdaeef96"));
            frames.Add("task26", new NameLink("Количество вакансий по крупным компаниям России",
                "http://localhost:5601/goto/34bbf43a690971b44c66c8125770d1ed"));
            frames.Add("task27", new NameLink("Количество вакансий по крупным компаниям в Москве",
                "http://localhost:5601/goto/c4df6fffe68a6f41374758a282fce35a"));
            frames.Add("task28", new NameLink("Количество вакансий по крупным компаниям в СПб",
                "http://localhost:5601/goto/363cbb9fa201bf298425c0bd2c8d3896"));
            frames.Add("task29", new NameLink("Количество вакансий по требуемому опыту работы",
                "http://localhost:5601/goto/50dc06f1bec006fdce93d174c2d0d3c1"));
            frames.Add("task30", new NameLink("Тепловая карта вакансий СПб",
                "http://localhost:5601/app/maps#/map/e03cdf70-208f-11eb-85a4-43b6a048db86?embed=true&_g=refreshInterval%3A(pause%3A!t%2Cvalue%3A0)%2Ctime%3A(from%3Anow-1y%2Cto%3Anow))"));
            frames.Add("task31", new NameLink("Тепловая карта вакансий Москвы",
                "http://localhost:5601/app/maps#/map/6a6131a0-246a-11eb-b1bb-d5bce6ec888d?embed=true&_g=refreshInterval%3A(pause%3A!t%2Cvalue%3A0)%2Ctime%3A(from%3Anow-1y%2Cto%3Anow))"));
            frames.Add("task32", new NameLink("Точечная карта вакансий СПб",
                "http://localhost:5601/app/maps#/map/d36cb6f0-246b-11eb-b1bb-d5bce6ec888d?embed=true&_g=refreshInterval%3A(pause%3A!t%2Cvalue%3A0)%2Ctime%3A(from%3Anow-1y%2Cto%3Anow))"));
            openedFrameKey = null;
        }
        public void OnGet()
        {

        }

        public void OnPost()
        {
        }

        public IActionResult OnGetUpdate()
        {
            StartServices.StartDBUpdate();
            return Redirect("/");
        }

        public void OnPostOpenTask(string key)
        {
            openedFrame = frames[key].Value;
            openedFrameKey = key;
            //return Page();
        }


    }
}
