using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.Kevoree.Annotation;
using Org.Kevoree.Core.Api;
using Org.Kevoree.Log.Api;
using System.ComponentModel.Composition;

namespace Org.Kevoree.Library
{
    [ComponentType]
    [Serializable]
    [Export(typeof(DeployUnit))]
    public class ConsolePrinter : MarshalByRefObject, DeployUnit
    {
        [KevoreeInject]
        private Context context;
        private bool allowPrint;

        [KevoreeInject]
        private ILogger logger;

        [Start]
        public void Start()
        {
            this.allowPrint = true;
            logger.Debug("Start");
        }

        [Stop]
        public void Stop()
        {
            this.allowPrint = false;
            logger.Debug("stop");
        }

        [Input]
        public void input(object msg)
        {
            if (this.allowPrint)
            {
                Console.WriteLine(context.getInstanceName() + ">" + msg);
            }
        }
    }
}
