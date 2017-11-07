using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RazorCompiler.Helpers;
using RazorCompiler.Models;

namespace RazorCompiler.Controllers
{
    public class HomeController : Controller
    {
        private readonly ViewRenderService _renderService;

        public HomeController(ViewRenderService renderService)
        {
            _renderService = renderService;
        }

        public IActionResult Index()
        {
            var model = new World { Title = "Earth" };
            var compiled = _renderService.Render("Views/_SampleRazorTemplate.cshtml", model);
            return Content(compiled);
        }
    }
}
