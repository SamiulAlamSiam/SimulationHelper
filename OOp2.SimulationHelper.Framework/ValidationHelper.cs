using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOp2.SimulationHelper.Framework
{
    public static class ValidationHelper
    {
        public static bool isIntValue(string key)
        {
            int id;
            return Int32.TryParse(key, out id);
        }

        public static bool isStringValue(string key)
        {
            if (string.IsNullOrEmpty(key) && string.IsNullOrWhiteSpace(key))
                return false;

            return true;
        }
    }
}
