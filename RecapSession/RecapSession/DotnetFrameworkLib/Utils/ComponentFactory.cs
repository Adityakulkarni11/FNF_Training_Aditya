using DotnetFrameworkLib.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetFrameworkLib.Utils
{
    public static class ComponentFactory
    {
        public static ILaptopService GetComponent()
        {
            var implementorClassName=ConfigurationManager.AppSettings["ComponentName"];
            var component=Type.GetType(implementorClassName);
            var obj =Activator.CreateInstance(component) as ILaptopService;
            return obj;
        }
    }   
}
