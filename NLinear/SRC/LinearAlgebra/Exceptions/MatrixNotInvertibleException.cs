using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace NLinear
{
#if !SILVERLIGHT
    [Serializable]
#endif

    public class MatrixNotInvertibleException : System.Exception
    {
        public MatrixNotInvertibleException()
        {
        }

        public MatrixNotInvertibleException(string message)
            : base(message)
        {
        }

        public MatrixNotInvertibleException(string message,
        Exception innerException)
            : base(message, innerException)
        {
        }

#if !SILVERLIGHT
        protected MatrixNotInvertibleException(SerializationInfo info,
          StreamingContext context)
            : base(info, context)
        {
        }
#endif
    }
}
