using MediatR;

namespace Panda.Core.Common.Abstractions.Messaging;

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}