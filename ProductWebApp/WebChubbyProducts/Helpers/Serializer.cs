namespace WebChubbyProducts.Helpers
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using System;

    /// <summary>
    /// Clase auxiliar para serialización
    /// </summary>
    public class Serializer
    {

        /// <summary>
        /// Serializa un objeto a JSON
        /// </summary>
        /// <param name="item">Objeto a serializar</param>
        /// <returns></returns>
        public static string SerializeObject<T>(T item)
        {
            return JsonConvert.SerializeObject(item, typeof(T), new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            });
        }

        /// <summary>
        /// Deserializa objeto
        /// </summary>
        /// <typeparam name="T">Cadena serializada</typeparam>
        /// <param name="args">Argumentos de serialización</param>
        /// <returns>Objeto T</returns>
        public static T DeserializeObject<T>(string args)
        {
            try
            {
                if (!string.IsNullOrEmpty(args))
                {
                    return JsonConvert.DeserializeObject<T>(args, new JsonSerializerSettings()
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    });
                }

            }
            catch (Exception exception)
            {
                return default(T);
            }
            return default(T);
        }
    }
}
