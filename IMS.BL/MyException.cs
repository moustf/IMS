using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.BL
{
    public class MyException : Exception
    {
        public int MyProperty { get; set; }
        public string Age { get; set; }
        public string Name { get; set; }


        public MyException(string name, string age) 
        {
            MyProperty = -1;
        }
    }
}
