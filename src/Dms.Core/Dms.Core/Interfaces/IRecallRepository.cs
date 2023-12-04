using Dms.Models.ReCall;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dms.Core.Interfaces
{
    public interface IRecallRepository
    {
        Task<IEnumerable<Recall>> GetAllRecallsAsync();
        Task<Recall> GetRecallByIdAsync(Guid id);
        Task AddRecallAsync(Recall recall);
        Task UpdateRecallAsync(Recall recall);
        Task DeleteRecallByIdAsync(Guid id);
    }
}
