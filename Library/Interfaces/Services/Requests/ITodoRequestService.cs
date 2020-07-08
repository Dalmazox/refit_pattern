using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Interfaces.Requests;
using Library.Models;

namespace Library.Interfaces.Services.Requests
{
    public interface ITodoRequestService : IRequestService
    {
        Task<IEnumerable<Todo>> GetList();
    }
}