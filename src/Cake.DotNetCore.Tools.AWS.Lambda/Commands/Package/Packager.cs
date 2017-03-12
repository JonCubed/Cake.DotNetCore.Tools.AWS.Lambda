using System;
using Cake.Common.Tools.DotNetCore;
using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.DotNetCore.Tools.AWS.Lambda.Commands.Package
{
    /// <summary>
    /// 
    /// </summary>
    public class Packager : DotNetCoreTool<PackageSettings>
    {
        private readonly ICakeLog _log;

        /// <summary>
        /// Initializes a new instance of the <see cref="Packager" /> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator.</param>
        /// <param name="log"></param>
        public Packager(
            IFileSystem fileSystem,
            ICakeEnvironment environment,
            IProcessRunner processRunner,
            IToolLocator tools,
            ICakeLog log) : base(fileSystem, environment, processRunner, tools)
        {
            _log = log;
        }

        /// <summary>
        /// Pack the lamda project using the specified settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void Pack(PackageSettings settings )
        {
            if ( settings == null )
            {
                throw new ArgumentNullException(nameof(settings));
            }
            
            Run(settings, GetArguments(settings));
        }

        private ProcessArgumentBuilder GetArguments( PackageSettings settings )
        {
            var builder = CreateArgumentBuilder(settings);

            builder.Append("lambda package");

            if ( settings.Configuration != null )
            {
                builder.Append("--configuration");
                builder.AppendQuoted(settings.Configuration);
            }

            if ( settings.TargetFramework != null )
            {
                builder.Append("--framework");
                builder.AppendQuoted(settings.TargetFramework);
            }

            if ( settings.PackageFileName != null )
            {
                builder.Append("--output-package");
                builder.AppendQuoted(settings.PackageFileName.FullPath);
            }

            return builder;
        }
    }
}
