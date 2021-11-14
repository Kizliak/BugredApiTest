using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserBugredApi.Helpers
{
    static class Utils
    {
        static public Random rnd = new Random();
        static public string GetNameRandom()
        {
            return "GomoTrio" + rnd.Next(11, 99) + rnd.Next(11, 99) + DateTime.Now.ToString("hhmmssMMddyy");
        }

        static public string GetEmailRandom()
        {
            return DateTime.Now.ToString("hhmmssMMddyy") + rnd.Next(11, 99) + rnd.Next(11, 99) + "@gomotrio.com";
        }
        static public string GetPassword()
        {
            return "mySecretPass123";
        }
    }
}
