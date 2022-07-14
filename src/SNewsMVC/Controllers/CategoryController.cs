using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SNewsMVC.DataModel.Category;
using SNewsMVC.Models.Category;
using SNewsMVC.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNewsMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var categoriesDM = await _categoryService.Get();

            var categories = _mapper.Map<IEnumerable<CategoryViewModel>>(categoriesDM.Data);

            return View(categories);
        }

        public async Task<IActionResult> Details(int id)
        {
            var categoryDM = await _categoryService.GetById(id);

            if(!categoryDM.Success || categoryDM.Data == null)
            {
                return NotFound();
            }

            var category = _mapper.Map<CategoryViewModel>(categoryDM.Data);

            return View(category);
        }

        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(InsertCategoryViewModel newCategory)
        {
            if (ModelState.IsValid)
            {
                var category = _mapper.Map<InsertCategoryRequest>(newCategory);
                var result = await _categoryService.Insert(category);
                return RedirectToAction("Details", new { id = result.Data.Id});
            }

            return View(newCategory);
        }
    }
}
