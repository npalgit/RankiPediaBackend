using Ninject.Modules;
using System;
using System.Collections.Generic;
using Ninject.Extensions.Conventions;
using Ninject.Web.Common;

namespace Rankipedia.Engine
{
    public class EngineModule : NinjectModule
    {
        private static readonly IEnumerable<Type> _excludedTypes = new List<Type>()
        { };
        public override void Load()
        {
            this.Bind(syntax => syntax
            .FromThisAssembly()
            .SelectAllClasses()
            .Excluding(_excludedTypes)
            .BindDefaultInterface()
            .Configure(config => config.InRequestScope()));
        }
    }
}
