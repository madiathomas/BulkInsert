using System;
using System.Runtime.Serialization;

namespace Recurso.BulkInsert.Sample.BLL
{
    [Serializable]
    public class StoredProcedureInsertFailedException : Exception
    {
        public StoredProcedureInsertFailedException()
        {
        }

        public StoredProcedureInsertFailedException(string message) : base(message)
        {
        }

        public StoredProcedureInsertFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected StoredProcedureInsertFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}