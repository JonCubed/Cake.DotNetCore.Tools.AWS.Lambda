using Cake.Common.Tools.DotNetCore;
using Cake.Core.IO;

namespace Cake.DotNetCore.Tools.AWS.Lambda.Commands.Package
{
    /// <summary>
    /// 
    /// </summary>
    public class PackageSettings : DotNetCoreSettings
    {
        /// <summary>
        /// 
        /// </summary>
        public string Configuration { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TargetFramework { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DirectoryPath PackageFileName { get; set; }
    }
}
