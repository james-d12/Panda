using System.Net;

namespace Panda.Core.Common.Exceptions;
public sealed class NotFoundException : BaseException
{
    public NotFoundException(string message) : base(HttpStatusCode.NotFound, message) { }
}
