using System;
using System.Runtime.Serialization;

namespace Recurso.BulkInsert.Sample.BLL
{
    [Serializable]
    public class BulkInsertFailedException : Exception
    {
        public BulkInsertFailedException()
        {
        }

        public BulkInsertFailedException(string message) : base(message)
        {
        }

        public BulkInsertFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BulkInsertFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}