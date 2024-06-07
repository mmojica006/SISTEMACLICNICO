using System.Reflection;

namespace CLINICAL.Utilities.HelperExtensions
{
    /// <summary>
    /// Clase que ayuda a obtener valores que no sean nulos de las entidades
    /// Obtiene solamente las propiedades que tienen valores
    /// </summary>
    public static class GetEntityPropertties
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static Dictionary<string, object> GetPropertiesWithValues<T>(this T entity)
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            var entityParams = new Dictionary<string, object>();

            foreach (PropertyInfo property in properties)
            {
                object value = property.GetValue(entity)!;
                if (value != null)
                {
                    entityParams[property.Name] = value;
                }
            }

            return entityParams;

        }

    }
}
