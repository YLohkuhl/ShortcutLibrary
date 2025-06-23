using System;

namespace ShortcutLib.Utils;

public class ShortcutLibError : Exception
{
    public ShortcutLibError() {}

    public ShortcutLibError(string message) : base(message) { }

    public ShortcutLibError(string message, Exception innerException) : base(message, innerException) { }
}