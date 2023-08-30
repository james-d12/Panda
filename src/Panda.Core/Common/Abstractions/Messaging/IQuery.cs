using MediatR;

namespace Panda.Core.Common.Abstractions.Messaging;
public interface IQuery<out TResponse> : IRequest<TResponse>
{
}