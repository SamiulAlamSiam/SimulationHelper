using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP2.SimulationHelper.Data;
using OOp2.SimulationHelper.Framework;

namespace OOP2.SimulationHelper.Repo
{
    public class UserInfoRepo
    {
        SimulationHelperContext context = new SimulationHelperContext();

        public Result<List<UserInfo>> GetAll(string key)
        {
            var result = new Result<List<UserInfo>>();
            try
            {
                int id = 0;

                IQueryable<UserInfo> query = context.UserInfoes;

                if (ValidationHelper.isStringValue(key))
                    query = context.UserInfoes.Where(u => u.Name.Equals(key) || u.UserName.Equals(key));

                if (ValidationHelper.isIntValue(key))
                {
                    id = Int32.Parse(key);
                    query = context.UserInfoes.Where(u => u.ID == id);
                }   

                result.Data = query.ToList();
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.Message = "Invalid Connection ";
            }

            return result;

        }

        public Result<bool> Delete(int id)
        {
            var result = new Result<bool>();

            try
            {
                var objDelete = context.UserInfoes.FirstOrDefault(c => c.ID == id);
                if (objDelete == null)
                {
                    result.HasError = true;
                    result.Message = " Invalid ID ";
                    return result;
                }

                context.UserInfoes.Remove(objDelete);
                context.SaveChanges();
                result.Data = true;
            }

            catch (Exception ex)
            {
                result.HasError = true;
                result.Message = ex.Message;
            }

            return result;
        }

        public Result<UserInfo> Save(UserInfo userInfo)
        {
            var result = new Result<UserInfo>();

            try
            {
                var objToSave = context.UserInfoes.FirstOrDefault(s => s.ID == userInfo.ID);

                if (objToSave == null)
                {
                    objToSave = new UserInfo();
                    context.UserInfoes.Add(objToSave);
                }

                objToSave.Name = userInfo.Name;
                objToSave.Password = userInfo.Password;
                objToSave.UserName = userInfo.UserName;
                objToSave.UserTypeID = userInfo.UserTypeID;

                if (!isValidToSave(objToSave, result))
                    return result;

                context.SaveChanges();

                result.Data = context.UserInfoes.FirstOrDefault(s => s.ID == objToSave.ID);

            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.Message = ex.Message;
            }


            return result;
        }

        private bool isValidToSave(UserInfo ui, Result<UserInfo> result)
        {
            if (!ValidationHelper.isStringValue(ui.Name))
            {
                result.HasError = true;
                result.Message = " Invalid Name ";
                return false;
            }

            if (!ValidationHelper.isStringValue(ui.UserName))
            {
                result.HasError = true;
                result.Message = " Invalid Name ";
                return false;
            }

            if (!ValidationHelper.isStringValue(ui.Password))
            {
                result.HasError = true;
                result.Message = " Invalid Name ";
                return false;
            }
            if (!ValidationHelper.isIntValue(ui.UserTypeID.ToString()))
            {
                result.HasError = true;
                result.Message = " Invalid Name ";
                return false;
            }
            return true;
        }
    }
}
