using System;

namespace ShortcutLib
{
    public class ShortcutLibraryException : Exception
    {
        public ShortcutLibraryException() {}

        public ShortcutLibraryException(string message) : base(message) {}

        public ShortcutLibraryException(string message, Exception innerException) : base(message, innerException) {}
    }
}