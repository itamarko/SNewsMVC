using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SNewsMVC.DataModel.Author;
using SNewsMVC.Models.Author;
using SNewsMVC.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNewsMVC.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public AuthorController(IAuthorService categoryService, IMapper mapper)
        {
            _authorService = categoryService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var authorsDM = await _authorService.Get();

            var authors = _mapper.Map<IEnumerable<AuthorViewModel>>(authorsDM.Data);

            return View(authors);
        }

        public async Task<IActionResult> Details(int id)
        {
            var authorDM = await _authorService.GetById(id);

            if (!authorDM.Success || authorDM.Data == null)
            {
                return NotFound();
            }

            var author = _mapper.Map<AuthorViewModel>(authorDM.Data);

            return View(author);
        }

        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(InsertAuthorViewModel newAuthor)
        {
            if (ModelState.IsValid)
            {
                var author = _mapper.Map<InsertAuthorRequest>(newAuthor);
                var result = await _authorService.Insert(author);
                return RedirectToAction("Details", new { id = result.Data.Id });
            }

            return View(newAuthor);
        }
    }
}
