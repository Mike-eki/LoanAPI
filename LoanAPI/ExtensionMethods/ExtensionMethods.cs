using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LoanAPI.ExtensionMethods
{
    public static class ExtensionMethods
    {
        public static object GetPropValue(this object src, string propertyName)
        {
            return src.GetType()?.GetProperty(propertyName)?.GetValue(src);
        }

        public static T GetPropertyValue<T>(object obj, string propName) 
        { 
            return (T)obj.GetType()?.GetProperty(propName)?.GetValue(obj, null); 
        }

        public static T SetValueOfProp<T>(T entity, object obj)
        {
            foreach (var prop in obj.GetType().GetProperties())
            {
                //Console.WriteLine($"Property Name: {prop.Name}");
                entity.GetType()?.GetProperty(prop.Name)?.SetValue(entity, prop.GetValue(obj, null), null);
            }
            return entity;
        }
    }
}
