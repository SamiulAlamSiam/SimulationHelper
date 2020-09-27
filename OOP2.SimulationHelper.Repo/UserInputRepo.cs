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
    public class UserInputRepo
    {
        SimulationHelperContext context = new SimulationHelperContext();

        public Result<List<UserInput>> GetAll()
        {
            var result = new Result<List<UserInput>>();
            try
            {
                int id = 0;

                IQueryable<UserInput> query = context.UserInputs.Where(u => u.UserID == LogInHelper.UserProfile.ID);

                if (LogInHelper.UserProfile.ID == (int) EnumCollection.userType.Teacher)
                {
                    query = context.UserInputs.Where(u => u.UserID == LogInHelper.UserProfile.ID || u.UserID == (int)EnumCollection.userType.Student);
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
                var objDelete = context.UserInputs.FirstOrDefault(c => c.ID == id);
                if (objDelete == null)
                {
                    result.HasError = true;
                    result.Message = " Invalid ID ";
                    return result;
                }

                context.UserInputs.Remove(objDelete);
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

        public Result<UserInput> Save(UserInput userInput)
        {
            var result = new Result<UserInput>();

            try
            {
                var objToSave = context.UserInputs.FirstOrDefault(s => s.ID == userInput.ID);

                if (objToSave == null)
                {
                    objToSave = new UserInput();
                    context.UserInputs.Add(objToSave);
                }

                objToSave.Title = userInput.Title;
                objToSave.Inputs = userInput.Inputs;
                objToSave.UserID = userInput.UserID;

                context.SaveChanges();

                result.Data = context.UserInputs.FirstOrDefault(s => s.ID == objToSave.ID);

            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.Message = ex.Message;
            }


            return result;
        }
    }
}
