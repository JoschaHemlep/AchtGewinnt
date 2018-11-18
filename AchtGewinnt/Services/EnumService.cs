using System;
using System.Collections.Generic;
using System.Linq;

namespace AchtGewinnt.Services
{
    public class EnumService : IEnumService
    {
        /// <summary>
        /// Returns a List of Enum Values
        /// </summary>
        /// <typeparam name="T">Enum</typeparam>
        public IList<T> EnumToList<T>()
        {
            var enumValues = Enum.GetValues(typeof(T)).Cast<T>();
            return enumValues.ToList();
        }
    }
}
