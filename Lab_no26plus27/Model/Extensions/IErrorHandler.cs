#region Using namespaces

using System;

#endregion

namespace Lab_no26plus27.Model.Extensions
{
    public interface IErrorHandler
    {
        void HandleError(Exception ex);
    }
}