using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopProjectLib.Exceptions
{

    [Serializable]
    public class PlannerItemNotFoundException : Exception
    {
        public PlannerItemNotFoundException() { }
        public PlannerItemNotFoundException(string message) : base(message) { }
        public PlannerItemNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected PlannerItemNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
   
}
