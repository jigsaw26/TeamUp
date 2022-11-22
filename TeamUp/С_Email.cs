using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamUp
{
    class С_Email
    {
        private string email;

        private static С_Email obj;

        private С_Email()
        {
            email = "";
        }

        static С_Email()
        {
            obj = new С_Email();
        }

        public static string GetEmail()
        {
            return obj.email;
        }

        public static void SetEmail(string x)
        {
            obj.email = x;
        }
    }
}
