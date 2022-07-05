using AutoMapper;
using SNewsMVC.Models.Category;
using SNewsMVC.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNewsMVC.Models.Mapper
{
    public class Model2ViewModel : Profile
    {
        public Model2ViewModel()
        {
            this.CreateMap<DataModel.Category.Category, CategoryViewModel>();
        }
    }
}
