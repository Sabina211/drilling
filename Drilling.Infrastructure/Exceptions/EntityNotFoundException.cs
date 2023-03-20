using System.Runtime.Serialization;

namespace Drilling.Exceptions
{
    public class EntityNotFoundException : Exception, ISerializable
    {
        public EntityNotFoundException(string message = "Не удалось найти объект") : base(message)
        {
        }
    }
}
