using System;
using System.IO;
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

        private static string numberPattern = " ({0})";

        // grabbed from https://stackoverflow.com/a/1078898
        public static string NextAvailableFilename(string path)
        {
            // Short-cut if already available
            if (!File.Exists(path))
                return path;

            // If path has extension then insert the number pattern just before the extension and return next filename
            if (Path.HasExtension(path))
                return GetNextFilename(path.Insert(path.LastIndexOf(Path.GetExtension(path)), numberPattern));

            // Otherwise just append the pattern to the path and return next filename
            return GetNextFilename(path + numberPattern);
        }

        private static string GetNextFilename(string pattern)
        {
            string tmp = string.Format(pattern, 1);
            if (tmp == pattern)
                throw new ArgumentException("The pattern must include an index place-holder", "pattern");

            if (!File.Exists(tmp))
                return tmp; // short-circuit if no matches

            int min = 1, max = 2; // min is inclusive, max is exclusive/untested

            while (File.Exists(string.Format(pattern, max)))
            {
                min = max;
                max *= 2;
            }

            while (max != min + 1)
            {
                int pivot = (max + min) / 2;
                if (File.Exists(string.Format(pattern, pivot)))
                    min = pivot;
                else
                    max = pivot;
            }

            return string.Format(pattern, max);
        }
    }
}
