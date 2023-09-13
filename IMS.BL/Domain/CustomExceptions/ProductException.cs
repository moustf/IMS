using System;

namespace IMS.BL.Domain.CustomExceptions
{
    public class ProductException : Exception
    {
        public ProductException() {  }
        
        public ProductException(string message) : base(message) {  }
        
        public ProductException(string message, Exception inner): base(message, inner) {  }
    }
}