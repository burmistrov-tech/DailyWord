using DailyWord.Models;
using DailyWord.Services;

using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MongoDB.Bson;
using System;
using System.Diagnostics.CodeAnalysis;

namespace DailyWord.Controllers
{
    public class MainController : Controller
    {
        public MainController(IWordDataService<IWordModel> dataService)
        {
            this.dataService = dataService;
        }
        private readonly IWordDataService<IWordModel> dataService;
        [HttpGet]
        public ViewResult Index() => View();
        [HttpGet]
        public ViewResult Result([NotNull]string word)
        {
            return View(new ResultViewModel
            {
                MostPopularWord = dataService.GetMostPopularWord(),
                UserWord = dataService.GetUserWord(word),
                SimilarWords = dataService.GetSimilarWords(word)
            });
        }
        [HttpPost]
        public IActionResult AddWord([NotNull]WordViewModel viewModel)
        {
            dataService.Insert(new WordModel
            {
                Id = ObjectId.GenerateNewId(),
                Value = viewModel.Value,
                Email = viewModel.Email,
                DateTime = DateTime.UtcNow
            });
            return RedirectToAction("Result", new { word = viewModel.Value });
        }
    }
}
