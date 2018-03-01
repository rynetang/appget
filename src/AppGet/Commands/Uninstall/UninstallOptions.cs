using CommandLine;

namespace AppGet.Commands.Uninstall
{
    [Verb("uninstall", HelpText = "Uninstall a package")]
    public class UninstallOptions : PackageCommandOptions
    {
        [Value(0, MetaName = PACKAGE_META_NAME, HelpText = "package to uninstall", Required = true)]
        public override string Package { get; set; }
    }
}