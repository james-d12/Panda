using System.Net;

namespace Panda.Core.Common.Exceptions;
public abstract class BaseException : Exception
{
    public readonly HttpStatusCode StatusCode;
    public BaseException(HttpStatusCode responseCode, string message) : base(message)
    {
        StatusCode = responseCode;
    }
}