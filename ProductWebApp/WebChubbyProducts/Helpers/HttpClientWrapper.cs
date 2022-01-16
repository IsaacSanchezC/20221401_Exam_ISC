namespace WebChubbyProducts.Helpers
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using System.Configuration;
    using System.Diagnostics;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;

    /// <summary>
    /// Permite gestionar los distintos métodos o verbos HTTP que se van a utlizar a través de <see cref="HttpClient"/>  para consumir los servicios de Web API 
    /// </summary>
    public class HttpClientWrapper<TRequest, TResponse> where TRequest : class where TResponse : class
    {
        /// <summary>
        /// Se inicializa clase base para enviar solicitudes HTTP
        /// </summary>
        private static HttpClient client;

        /// <summary>
        /// Constante para JSON Header
        /// </summary>
        private static readonly string HeaderValueAppJson = "application/json";


        /// <summary>
        /// Realiza una llamada tipo GEt (verbo HTTP) asíncrona, enviandole una solicitud en formato Json
        /// </summary>
        /// <param name="baseAddress">Uri base del servicio</param>
        /// <param name="methodAddress">Uri del método del servicio que se va a consumir</param>
        /// <returns>Respuesta (objeto Response) que devuelve el servicio</returns>
        public async Task<TResponse> GetJsonAsync(Uri baseAddress, string methodAddress)
        {
            if (ReferenceEquals(client, null))
            {
                client = new HttpClient
                {
                    BaseAddress = baseAddress
                };
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(HeaderValueAppJson));
            }

            var responseMessage = await client.GetAsync(methodAddress).ConfigureAwait(false);
            var responseContent = string.Empty;
            if (!responseMessage.IsSuccessStatusCode)
            {
                responseContent = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
            else
            {
                responseContent = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
            }

            var result = Serializer.DeserializeObject<TResponse>(responseContent);
            return result;
        }

        /// <summary>
        /// Realiza una llamada tipo Delete (verbo HTTP) asíncrona, enviandole una solicitud en formato Json
        /// </summary>
        /// <param name="baseAddress">Uri base del servicio</param>
        /// <param name="methodAddress">Uri del método del servicio que se va a consumir</param>
        /// <returns>Respuesta (objeto Response) que devuelve el servicio</returns>
        public async Task<TResponse> DeleteJsonAsync(Uri baseAddress, string methodAddress)
        {
            if (ReferenceEquals(client, null))
            {
                client = new HttpClient
                {
                    BaseAddress = baseAddress
                };
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(HeaderValueAppJson));
            }

            var responseMessage = await client.DeleteAsync(methodAddress).ConfigureAwait(false);
            var responseContent = string.Empty;
            if (!responseMessage.IsSuccessStatusCode)
            {
                responseContent = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
            else
            {
                responseContent = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
            }

            var result = Serializer.DeserializeObject<TResponse>(responseContent);
            return result;
        }

        /// <summary>
        /// Realiza una llamada tipo POST (verbo HTTP) asíncrona, enviandole una solicitud en formato Json
        /// </summary>
        /// <param name="baseAddress">Uri base del servicio</param>
        /// <param name="methodAddress">Uri del método del servicio que se va a consumir</param>
        /// <param name="request">Objeto con los datos de la solicitud que se va a enviar al servicio</param>
        /// <returns>Respuesta (objeto Response) que devuelve el servicio</returns>
        public async Task<TResponse> PostJsonAsync(Uri baseAddress, string methodAddress, TRequest request, List<KeyValuePair<string, string>> headers = null)
        {
            if (ReferenceEquals(client, null))
            {
                client = new HttpClient()
                {
                    BaseAddress = baseAddress
                };
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(HeaderValueAppJson));

                if (!ReferenceEquals(headers, null))
                {
                    foreach (KeyValuePair<string, string> header in headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }
            }

            var serializedRequest = JsonConvert.SerializeObject(request, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            var requestContent = new StringContent(serializedRequest, Encoding.Unicode, HeaderValueAppJson);

            var responseMessage = await client.PostAsync(methodAddress, requestContent).ConfigureAwait(false);
            var responseContent = string.Empty;
            if (!responseMessage.IsSuccessStatusCode)
            {

                responseContent = await responseMessage.Content.ReadAsStringAsync();

            }
            else
            {
                responseContent = await responseMessage.Content.ReadAsStringAsync();

            }


            return Serializer.DeserializeObject<TResponse>(responseContent);
        }

        /// <summary>
        /// Realiza una llamada tipo POST (verbo HTTP) asíncrona, enviandole una solicitud en formato Json
        /// </summary>
        /// <param name="baseAddress">Uri base del servicio</param>
        /// <param name="methodAddress">Uri del método del servicio que se va a consumir</param>
        /// <param name="request">Objeto con los datos de la solicitud que se va a enviar al servicio</param>
        /// <returns>Respuesta (objeto Response) que devuelve el servicio</returns>
        public async Task<TResponse> PostJsonAsync(string baseAddress, string methodAddress, TRequest request, List<KeyValuePair<string, string>> headers = null)
        {
            if (ReferenceEquals(client, null))
            {
                client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();
            }

            if (!ReferenceEquals(headers, null))
            {
                client.DefaultRequestHeaders.Clear();
                foreach (KeyValuePair<string, string> header in headers)
                {
                    client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }

            var serializedRequest = JsonConvert.SerializeObject(request, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });


            var requestContent = new StringContent(serializedRequest, Encoding.UTF8, HeaderValueAppJson);

            string resourceAddress = baseAddress + methodAddress;
            var responseMessage = await client.PostAsync(resourceAddress, requestContent).ConfigureAwait(false);
            var responseContent = string.Empty;
            if (!responseMessage.IsSuccessStatusCode)
            {
                responseContent = await responseMessage.Content.ReadAsStringAsync();
            }
            else
            {
                responseContent = await responseMessage.Content.ReadAsStringAsync();
            }

            return Serializer.DeserializeObject<TResponse>(responseContent);
        }

        /// <summary>
        /// Realiza una llamada tipo PUT (verbo HTTP) asíncrona, enviandole una solicitud en formato Json
        /// </summary>
        /// <param name="baseAddress">Uri base del servicio</param>
        /// <param name="methodAddress">Uri del método del servicio que se va a consumir</param>
        /// <param name="request">Objeto con los datos de la solicitud que se va a enviar al servicio</param>
        /// <returns>Respuesta (objeto Response) que devuelve el servicio</returns>
        public async Task<TResponse> PutJsonAsync(Uri baseAddress, string methodAddress, TRequest request)
        {
            if (ReferenceEquals(client, null))
            {
                client = new HttpClient
                {
                    BaseAddress = baseAddress
                };
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(HeaderValueAppJson));
            }

            var serializedRequest = Serializer.SerializeObject(request);

            var guidTrace = Guid.NewGuid(); // Para poder identificar los registros en el log la peticion y la respuesta a la peticion.

            var requestContent = new StringContent(serializedRequest, Encoding.Unicode, HeaderValueAppJson);

            var responseMessage = await client.PutAsync(methodAddress, requestContent).ConfigureAwait(false);
            var responseContent = string.Empty;
            if (!responseMessage.IsSuccessStatusCode)
            {
                responseContent = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
            else
            {
                responseContent = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
            }

            var result = Serializer.DeserializeObject<TResponse>(responseContent);
            return result;
        }
    }
}
