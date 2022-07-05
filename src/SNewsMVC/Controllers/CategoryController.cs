using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
    }
}
