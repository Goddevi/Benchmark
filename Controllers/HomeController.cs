using Benchmark.Models;
using Benchmark.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Benchmark.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStringCalculationService _stringCalculationService;
        public HomeController(IStringCalculationService stringCalculationService)
        {
            _stringCalculationService = stringCalculationService;
        }

        public IActionResult Index()
        {
            StringCalculatorViewModel viewModel = new StringCalculatorViewModel { Output = null };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Index(StringCalculatorViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            //have sanitized the input to convert return key to new line for sake of testing
            //in future more serverside validation should be included
            string sanitizedInput = Regex.Replace(viewModel.Input, "[\r]", string.Empty);

            INumberParser numberParser = new MultipleCustomDelimiterNumberParser(false, false);
            viewModel.Output = _stringCalculationService.Add(sanitizedInput, numberParser);

            return View(viewModel);
        }
    }
}