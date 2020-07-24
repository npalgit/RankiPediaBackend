using Ninject.Modules;
using System;
using System.Collections.Generic;
using Ninject.Extensions.Conventions;
using System.Configuration;
using Ninject.Web.Common;

namespace Rankipedia.Data
{
    public class DataModule : NinjectModule
    {
        private static IEnumerable<Type> _excludedTypes = new List<Type>()
        {
        };
        public override void Load()
        {
            this.Bind(syntax => syntax
            .FromThisAssembly()
            .SelectAllClasses()
            .Excluding(_excludedTypes)
            .BindDefaultInterface()
            .Configure(config => config.InSingletonScope()));
        }
    }
}
