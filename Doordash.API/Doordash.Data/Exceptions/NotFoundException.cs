using System;

namespace Doordash.Data.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message): base(message)
        {

        }
    }
}
