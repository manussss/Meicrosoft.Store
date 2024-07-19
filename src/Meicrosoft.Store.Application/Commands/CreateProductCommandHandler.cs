using MediatR;
using Meicrosoft.Store.Application.Contracts;

namespace Meicrosoft.Store.Application.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ResponseContract>
    {
        public async Task<ResponseContract> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
