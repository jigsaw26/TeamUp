using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamUp
{
    class C_Localization
    {
        private int rus, en, nem;

        private static C_Localization obj;

        private C_Localization()
        {
            rus = 0;
            en = 0;
            nem = 0;
        }

        static C_Localization()
        {
            obj = new C_Localization();
        }

        public static int GetLanguage()
        {
            if (obj.rus == 1) return obj.rus; 
            else if (obj.nem == 2) return obj.nem;
            else return obj.en;
        }

        public static void SetLanguageRu()
        {
            obj.rus = 1;
        }

        public static void SetLanguageNem()
        {
            obj.nem = 2;
        }

        public static void SetLanguageEn()
        {
            obj.en = 3;
        } 
    }
}
