using System;

namespace IMS.BL.Domain.CustomExceptions
{
    public class ProductNotFoundException : NullReferenceException
    {
        public ProductNotFoundException() {  }
        
        public ProductNotFoundException(string message = "The application couldn't find any product/s in the database!") : base(message) {  }
        
        public ProductNotFoundException(string message, Exception inner): base(message, inner) {  }
    }
}