using Microsoft.AspNetCore.Mvc;
using Softline.DAL.Repository;
using Softline.UI.ViewModels;
using System;
using System.IO;
using System.Linq;

namespace Softline.UI.Controllers
{
    public class ParseController : Controller
    {
        private readonly IRequestRepository requestRepository;

        public ParseController(
            IRequestRepository requestRepository)
        {
            this.requestRepository = requestRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new ParseViewModel());
        }

        [HttpPost]
        public IActionResult ParseFile(ParseViewModel model)
        {
            if (ModelState.IsValid)
            {
                using StreamReader sr = new StreamReader(model.FilePath);
                switch (model.Separator)
                {
                    case SeparatorType.SignOfTabulation:
                        ProcessFile(model, sr, "\t");
                        break;
                    case SeparatorType.Space:
                        ProcessFile(model, sr, " ");
                        break;
                    case SeparatorType.Semicolon:
                        ProcessFile(model, sr, ";");
                        break;
                    case SeparatorType.Another:
                        ProcessFile(model, sr, "ASDASDA");
                        break;
                    default:
                        throw new NullReferenceException();
                }
            }
            return View();
        }

        private static void ProcessFile(ParseViewModel model, StreamReader sr, string separator)
        {
            if (model.IsFirstRowTitle)
            {
                foreach (var title in sr.ReadLine().Split(separator))
                {
                    model.TableTitle.Add(title);
                }
            }
            model.TableData = sr
                .ReadToEnd()
                .Split("\n")
                .Select(
                    row => new Row(row
                    .Split(separator)
                    .ToList()))
                .ToList();
        }
    }
}
