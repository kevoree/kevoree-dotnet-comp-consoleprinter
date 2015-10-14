using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.Kevoree.Annotation;
using Org.Kevoree.Core.Api;

namespace Org.Kevoree.Library
{
    [ComponentType]
    [Serializable]
    public class ConsolePrinter : MarshalByRefObject, DeployUnit
    {
        [KevoreeInject]
        private Context context;

        [Input]
        public void input(object msg)
        {
            Console.WriteLine(context.getInstanceName() + ">" + msg);
        }
    }
}
