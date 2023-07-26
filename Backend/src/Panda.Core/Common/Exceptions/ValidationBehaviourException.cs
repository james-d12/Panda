using System.Net;

namespace Panda.Core.Common.Exceptions;
public sealed class ValidationBehaviourException : BaseException
{
    public ValidationBehaviourException(IReadOnlyDictionary<string, string[]> errorsDictionary)
        : base(HttpStatusCode.NotFound, "Validation Failure.")
        => ErrorsDictionary = errorsDictionary;

    public IReadOnlyDictionary<string, string[]> ErrorsDictionary { get; }
}

