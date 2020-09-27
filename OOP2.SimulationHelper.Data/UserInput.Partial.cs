using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOp2.SimulationHelper.Framework;

namespace OOP2.SimulationHelper.Data
{
    public partial class UserInput
    {
        SimulationHelperContext context = new SimulationHelperContext();
        public string UserName {
            get
            {
                var obj = context.UserInfoes.FirstOrDefault(u => u.ID == LogInHelper.UserProfile.ID);

                if(obj==null)
                    return null;

                return obj.Name;

                //if (UserID == (int)EnumCollection.userType.Student)
                //{
                //    return "Student";
                //}
                //if (UserID == (int)EnumCollection.userType.Teacher)
                //{
                //    return "Teacher";
                //}
            }

        }
    }
}
