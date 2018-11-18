using System.Collections.Generic;

namespace AchtGewinnt.Services
{
    public interface IEnumService
    {
        IList<T> EnumToList<T>();
    }
}