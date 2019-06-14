using System;
using System.Runtime.CompilerServices;

namespace utilities_bucket
{
    public static class Utility
    {
        /// <summary>
        /// Uses System Runtime Compiler Services to resolve the name of the calling method.
        /// https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.callermembernameattribute?view=netframework-4.8
        /// </summary>
        /// <param name="memberName">
        /// calling method -- no need to pass this parameter in;
        /// it's optional and this works as intended even if this is null.
        /// </param>
        /// <returns>
        /// name of the method that called this method
        /// </returns>
        public static string GetCallerMemberName([CallerMemberName] string memberName = "")
        {
            return string.IsNullOrEmpty(memberName) ? null : memberName;
        }
    }
}
