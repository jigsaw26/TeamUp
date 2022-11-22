using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamUp
{
    class С_Settigs
    {
        private int window; 

        private static С_Settigs obj;

        private С_Settigs()
        {
            window = 0; 
        }

        static С_Settigs()
        {
            obj = new С_Settigs();
        }

        public static int GetWindow()
        {
            return obj.window;
        } 

        public static void SetWindow(int x)
        {
            obj.window = x;
        } 
    }
}
