using SNewsMVC.DataModel;
using SNewsMVC.DataModel.Category;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SNewsMVC.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<CommandResponse<Category>> Insert(InsertCategoryRequest category);
        Task<CommandResponse<IEnumerable<Category>>> Get();
        Task<CommandResponse<Category>> GetById(int id);
    }
}
