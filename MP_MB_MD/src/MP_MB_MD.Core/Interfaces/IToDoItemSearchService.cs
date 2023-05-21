using Ardalis.Result;
using MP_MB_MD.Core.ProjectAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MP_MB_MD.Core.Interfaces
{
    public interface IToDoItemSearchService
    {
        Task<Result<ToDoItem>> GetNextIncompleteItemAsync(int projectId);
        Task<Result<List<ToDoItem>>> GetAllIncompleteItemsAsync(int projectId, string searchString);
    }
}
