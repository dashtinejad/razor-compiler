using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RazorCompiler.Helpers;
using RazorCompiler.Models;
using RazorLight;
using RazorLight.Extensions;

namespace RazorCompiler.Controllers
{
    public class HomeController : Controller
    {
        private readonly ViewRenderService _renderService;

        public HomeController(ViewRenderService renderService)
        {
            _renderService = renderService;
        }

        public IActionResult FileIndex()
        {
            var model = new World { Title = "Earth" };
            var compiled = _renderService.Render("Views/_SampleRazorTemplate.cshtml", model);
            return Content(compiled);
        }

        public IActionResult Index()
        {
            const string content = "Hello @Model.Name. Welcome to @Model.Title repository";
            var engine = EngineFactory.CreatePhysical(@"c:\Windows" /*it's fake, not needed and going to fix in 2.0.0*/);

            var model = new
            {
                Name = "Posht-Kohi",
                Title = "RazorLight"
            };

            string result = engine.ParseString(content, model);

            return Content(result);
        }
    }
}
