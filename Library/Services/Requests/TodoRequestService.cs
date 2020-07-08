using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Interfaces.Requests;
using Library.Interfaces.Services;
using Library.Interfaces.Services.Requests;
using Library.Models;

namespace Library.Services.Requests
{
    public class TodoRequestService : RequestService, ITodoRequestService
    {
        private IHermesService _hermes;

        public TodoRequestService()
        {
            _hermes = new HermesService();
        }

        public Task<IEnumerable<Todo>> GetList()
        {
            return _hermes
                .GetClient<ITodoRequest>("https://jsonplaceholder.typicode.com")
                .GetList();
        }
    }
}