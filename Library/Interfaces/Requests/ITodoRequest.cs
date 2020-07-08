using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Models;
using Refit;

namespace Library.Interfaces.Requests
{
    public interface ITodoRequest
    {
        [Get("/todos")]
        Task<IEnumerable<Todo>> GetList();
    }
}