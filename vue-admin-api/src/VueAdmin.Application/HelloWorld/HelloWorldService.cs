using System;
using System.Collections.Generic;
using System.Text;

namespace VueAdmin.HelloWorld
{
    public class HelloWorldService : VueAdminAppService, IHelloWorldService
    {
        public string HelloWorld()
        {
            return "Hello World";
        }
    }
}
