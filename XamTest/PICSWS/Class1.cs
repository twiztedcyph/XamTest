using System;
using System.Collections.Generic;
using System.Text;

namespace PICSWS
{
    class Class1
    {
        public static void Test()
        {
            PICSWebService.PICSWebServiceClient client = new PICSWebService.PICSWebServiceClient();
            client.AuthenticateUserAsync(new PICSWebService.AuthenticateUserRequest1() { });
        }
    }
}
