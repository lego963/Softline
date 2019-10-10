using Microsoft.AspNetCore.Mvc;
using Softline.DAL.Repository;
using Softline.Model.Entity;
using Softline.UI.ViewModels;
using System;
using System.Collections.Generic;
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
        public IActionResult Index(ParseViewModel model)
        {
            if (ModelState.IsValid)
            {
                switch (model.Separator)
                {
                    case "SignOfTabulation":
                        ProcessFile(ref model, "\t");
                        break;
                    case "Space":
                        ProcessFile(ref model, " ");
                        break;
                    case "Semicolon":
                        ProcessFile(ref model, ";");
                        break;
                    case "Another":
                        ProcessFile(ref model, "ASDASDA");
                        break;
                    default:
                        return NotFound();
                }
            }
            var request = new Request { RequestTime = DateTime.Now, RequestAction = $"Create database <{model.DbName}>\nCreate table <{model.File.FileName}>\n" };
            foreach (var item in model.TableTitle)
            {
                request.RequestAction += $"\tCreate column <{item}>\n";
            }
            foreach (var row in model.TableData)
            {
                string tmpRow = string.Empty;
                foreach (var dataItem in row.RowData)
                {
                    tmpRow += @$"\{dataItem}\ ";
                }
                request.RequestAction += $"Insert row <{tmpRow}>\n";
            }
            requestRepository.AddRequest(request);
            return View(model);
        }

        private static void ProcessFile(ref ParseViewModel model, string separator)
        {
            List<char> letters;
            using (var memoryStream = new MemoryStream())
            {
                model.File.CopyTo(memoryStream);
                letters = memoryStream.ToArray().Select(letter => (char)letter).ToList();
            }
            string tmpRow = string.Empty;
            letters.RemoveAll(letter => letter == '\r');
            foreach (var letter in letters)
            {
                if (letter != '\n')
                {
                    tmpRow += letter;
                }
                else
                {
                    model.TableData.Add(new Row(tmpRow.ToString().Split(separator).ToList()));
                    tmpRow = string.Empty;
                }
            }

            if (model.IsFirstRowTitle)
            {
                model.TableTitle = model.TableData[0].RowData;
                model.TableData.RemoveAt(0);
            }
        }
    }
}
