using System;
using System.Runtime.Serialization;

namespace CaisseWebDAL.Repositories
{
    [Serializable]
    internal class MysqlException : Exception
    {
        public MysqlException()
        {
        }

        public MysqlException(string message) : base(message)
        {
        }

        public MysqlException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MysqlException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}