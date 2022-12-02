using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamUp
{
    class C_WindowState
    {
        private double width;
        private double height;

        private double top;
        private double left;


        private static C_WindowState obj;

        private C_WindowState()
        {
            width = 0;
            height = 0;

            top = 0;
            left = 0;
        }

        static C_WindowState()
        {
            obj = new C_WindowState();
        }

        public static double GetWindowStateWidth()
        {
            return obj.width;
        }
        public static double GetWindowStateHeight()
        {
            return obj.height;
        }

        public static void SetWindowStateWidth(double width1)
        {
            obj.width = width1;
        }
        public static void SetWindowStateHeight(double height1)
        {
            obj.height = height1;
        }



        public static double GetWindowStateTop()
        {
            return obj.top;
        }
        public static double GetWindowStateLeft()
        {
            return obj.left;
        }

        public static void SetWindowStateTop(double top1)
        {
            obj.top = top1;
        }
        public static void SetWindowStateLeft(double left1)
        {
            obj.left = left1;
        }
    }
}
