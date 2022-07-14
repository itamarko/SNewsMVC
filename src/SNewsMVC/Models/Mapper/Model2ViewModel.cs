using AutoMapper;
using SNewsMVC.Models.Category;
using SNewsMVC.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SNewsMVC.Models.Author;

namespace SNewsMVC.Models.Mapper
{
    public class Model2ViewModel : Profile
    {
        public Model2ViewModel()
        {
            this.CreateMap<DataModel.Category.Category, CategoryViewModel>();
            this.CreateMap<InsertCategoryViewModel, DataModel.Category.InsertCategoryRequest>();
            this.CreateMap<DataModel.Author.Author, AuthorViewModel>();
            this.CreateMap<InsertAuthorViewModel, DataModel.Author.InsertAuthorRequest>();
        }
    }
}
