using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.IO;

namespace GoogleGeocoding
{

    public class GeocodingResponses
    {
        public List<GeocodingResponse> results { get; set; }
        public string status { get; set; }

        public GeocodingResponses() {}

        public GeocodingResponses(string address)
        {

            string requestUri = string.Format("http://maps.googleapis.com/maps/api/geocode/json?address={0}&sensor=false", Uri.EscapeDataString(address));

            WebRequest request = WebRequest.Create(requestUri);
            WebResponse response = request.GetResponse();

            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                string json = sr.ReadToEnd();
                GeocodingResponses responses = JsonConvert.DeserializeObject<GeocodingResponses>(json);
                this.results = responses.results;
                this.status = responses.status;
            }
        }
    }

    public class GeocodingResponse
    {
        public List<AddressComponent> address_components { get; set; }
        public string formatted_address { get; set; }
        public Geometry geometry { get; set; }
        public string place_id { get; set; }
        public List<string> types { get; set; }
    }

    public class AddressComponent
    {
        public string long_name { get; set; }
        public string short_name { get; set; }
        public List<string> types { get; set; }
    }

    public class Geometry
    {
        public Location location { get; set; }
        public string location_type { get; set; }
        public Viewport viewport { get; set; }
    }

    public class Location
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Viewport
    {
        public Northeast northeast { get; set; }
        public Southwest southwest { get; set; }
    }

    public class Northeast
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Southwest
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }
}
