﻿using MediatR;

namespace Panda.Core.Common.Abstractions.Messaging;
public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
{
}
