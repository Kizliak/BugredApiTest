using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserBugredApi.Helpers
{
    static class Utils
    {
        static public string GetNameRandom()
        {
            return "GomoTrio" + DateTime.Now.ToString("hhmmssMMddyy");
        }

        static public string GetEmailRandom()
        {
            return DateTime.Now.ToString("hhmmssMMddyy") + "@gomotrio.com";
        }
        static public string GetPassword()
        {
            return "mySecretPass123";
        }
    }
}
