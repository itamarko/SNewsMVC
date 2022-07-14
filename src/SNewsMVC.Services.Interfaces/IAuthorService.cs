using SNewsMVC.DataModel;
using SNewsMVC.DataModel.Author;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNewsMVC.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<CommandResponse<Author>> Insert(InsertAuthorRequest author);
        Task<CommandResponse<IEnumerable<Author>>> Get();
        Task<CommandResponse<Author>> GetById(int id);
    }
}
