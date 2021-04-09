#region Using namespaces

using System;
using System.Threading.Tasks;

#endregion

namespace Lab_no26plus27.Model.Extensions
{
    public static class TaskExtensions
    {
        public async static void FireAndForgetSafeAsync(this Task task, IErrorHandler handler = null)
        {
            try
            {
                await task;
            }
            catch (Exception ex)
            {
                handler?.HandleError(ex);
            }
        }
    }
}