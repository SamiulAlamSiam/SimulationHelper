using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOp2.SimulationHelper.Framework;

namespace OOP2.SimulationHelper.Data
{
    public partial class UserInfo
    {
        public string ReturnNameType
        {
            get
            {
                if (UserTypeID == (int) EnumCollection.userType.Admin)
                {
                    return "Admin";
                }

                if (UserTypeID == (int)EnumCollection.userType.Student)
                {
                    return "Student";
                }
                if (UserTypeID == (int)EnumCollection.userType.Teacher)
                {
                    return "Teacher";
                }
                return null;
            }
        }
    }
}
