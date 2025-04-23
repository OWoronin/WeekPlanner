using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopProjectLib.Exceptions
{

    [Serializable]
    public class IncorrectSearchParametersException : Exception
    {
        public IncorrectSearchParametersException() { }
        public IncorrectSearchParametersException(string message) : base(message) { }
        public IncorrectSearchParametersException(string message, Exception inner) : base(message, inner) { }
        protected IncorrectSearchParametersException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
