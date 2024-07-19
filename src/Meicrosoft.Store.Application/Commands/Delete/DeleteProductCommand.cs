using MediatR;
using Meicrosoft.Store.Application.Contracts;

namespace Meicrosoft.Store.Application.Commands.Delete
{
    public class DeleteProductCommand(Guid id) : IRequest<ResponseContract>
    {
        public Guid Id { get; set; } = id;
    }
}
