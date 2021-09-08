using System;

namespace BLL.Validation
{
    public class TestingSystemException : Exception
    {
        public string Property { get; protected set; }

        public TestingSystemException() { }

        public TestingSystemException(string message) : base(message) { }

        public TestingSystemException(string message, string prop) : base(message)
        {
            Property = prop;
        }
    }
}
