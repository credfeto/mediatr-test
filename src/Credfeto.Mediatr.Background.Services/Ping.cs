using MediatR;

namespace Credfeto.Mediatr.Background.Services;

public sealed class Ping : INotification
{
    /// <summary>
    ///     Constructor.
    /// </summary>
    /// <param name="message">The message</param>
    public Ping(string message)
    {
        this.Message = message;
    }

    public string Message { get; }
}