using Sample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Domain.Abstract.Repositories
{
    public interface IHelloWorldRepository
    {
        Task<HelloWorldDTO> FetchMessage();
    }
}
