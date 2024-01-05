using System.Net;

namespace Panda.Core.Common.Exceptions;

public sealed class ConflictException : BaseException
{
    public ConflictException(string message) : base(HttpStatusCode.Conflict, message) { }
}