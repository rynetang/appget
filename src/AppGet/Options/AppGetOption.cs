using System;
using CommandLine;

namespace AppGet.Options
{
    public abstract class AppGetOption
    {
        [Option('v', "verbose", Required = false)]
        public bool Verbose { get; set; }

        public string CommandName { get; }

        protected AppGetOption()
        {
            var verbAttr = (VerbAttribute)Attribute.GetCustomAttribute(GetType(), typeof(VerbAttribute));
            CommandName = verbAttr.Name;
        }
    }
}