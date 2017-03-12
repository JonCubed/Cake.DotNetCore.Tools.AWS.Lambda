using System;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.DotNetCore.Tools.AWS.Lambda.Commands.Package;

namespace Cake.DotNetCore.Tools.AWS.Lambda
{
    /// <summary>
    /// 
    /// </summary>
    [CakeAliasCategory("DotNetCore Tools")]
    [CakeNamespaceImport("Cake.DotNetCore.Tools.AWS.Lambda")]
    [CakeNamespaceImport("Cake.DotNetCore.Tools.AWS.Lambda.Commands.Pack")]
    public static class LambdaCommandAliases
    {
        /// <summary>
        /// Pack a Lambda project into a zip file ready for deployment
        /// </summary>
        /// <param name="context">The context.</param>
        /// <example>
        /// <code>
        ///     DotNetCoreAWSLamdaPackage();
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Pack")]
        public static void DotNetCoreAWSLamdaPackage( this ICakeContext context)
        {
            DotNetCoreAWSLamdaPackage(context, null);
        }

        /// <summary>
        /// Pack a Lambda project into a zip file ready for deployment
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        ///     var settings = new PackageSettings
        ///     {
        ///         Configuration = "Release",
        ///         TargetFramework = "netcoreapp1.0",
        ///         PackageFileName = "./publish/lambda.zip"
        ///     };
        ///
        ///     DotNetCoreAWSLamdaPackage(settings);
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Pack")]
        public static void DotNetCoreAWSLamdaPackage( this ICakeContext context, PackageSettings settings )
        {
            if ( context == null )
            {
                throw new ArgumentNullException(nameof(context));
            }
            
            if ( settings == null )
            {
                settings = new PackageSettings();
            }

            var packager = new Packager(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, context.Log);
            packager.Pack(settings);
        }
    }
}
