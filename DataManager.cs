using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;

namespace GlobalEarthquakeActivity
{
    public class DataManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uriStr"></param>
        /// <returns></returns>
        public static GeoJSON GetData(string uriStr)
        {
            string data = string.Empty;

            if (uriStr == string.Empty)
                return null;

            Uri uri = new Uri(uriStr);
            WebRequest request = WebRequest.Create(uri);
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();

            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(GeoJSON));
            GeoJSON geoJSON = jsonSerializer.ReadObject(stream) as GeoJSON;

            stream.Close();
            response.Close();
            return geoJSON;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uriStr"></param>
        /// <returns></returns>
        public static async Task<GeoJSON> GetDataAsync(string uriStr)
        {
            string data = string.Empty;

            if (uriStr == string.Empty)
                return null;

            Uri uri = new Uri(uriStr);
            WebRequest request = WebRequest.Create(uri);
            //WebRequest.GetResponse() can take a long time, so use the async version
            WebResponse response = await request.GetResponseAsync();
            Stream stream = response.GetResponseStream();
            GeoJSON geoJSON = await GetGeoJSONAsync(stream);

            stream.Close();
            response.Close();
            return geoJSON;
        }

        /// <summary>
        /// DataContractJsonSerializer.ReadObject() takes a long time, so make this an async call
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        private static Task<GeoJSON> GetGeoJSONAsync(Stream stream)
        {
            return Task.Run(() =>
            {
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(GeoJSON));
                GeoJSON geoJSON = jsonSerializer.ReadObject(stream) as GeoJSON;
                return geoJSON;
            });
        }
    }
}
