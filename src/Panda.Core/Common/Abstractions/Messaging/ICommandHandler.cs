using MediatR;

namespace Panda.Core.Common.Abstractions.Messaging;
public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
{
}