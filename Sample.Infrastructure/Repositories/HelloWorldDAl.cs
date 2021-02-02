using Sample.Domain.Abstract.Repositories;
using Sample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Infrastructure.Repositories
{
    public class HelloWorldDAL : IHelloWorldRepository
    {
        public async Task<HelloWorldDTO> FetchMessage()
        {
            var helloworlddto = new HelloWorldDTO
            {
                Message = "Hello World"
            };

            await FakeAsync();
            return helloworlddto;
        }

        public Task FakeAsync()
        {
            return Task.CompletedTask;
        }

    }
}
