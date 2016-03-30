using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

// Schema from http://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
namespace GlobalEarthquakeActivity
{
    [DataContract]
    public class GeoJSON
    {
        [DataMember(Name = "type")]
        public string Type
        {
            get; set;
        }

        [DataMember(Name = "metadata")]
        public Metadata Metadata
        {
            get; set;
        }

        [DataMember(Name = "bbox")]
        public decimal[] Bbox
        {
            get; set;
        }

        [DataMember(Name = "features")]
        public Data[] Features
        {
            get; set;
        }
    }

    [DataContract]
    public class Metadata
    {
        [DataMember(Name = "generated")]
        public long Generated
        {
            get; set;
        }

        [DataMember(Name = " url")]
        public string Url
        {
            get; set;
        }

        [DataMember(Name = " title")]
        public string Title
        {
            get; set;
        }

        [DataMember(Name = " api")]
        public string Api
        {
            get; set;
        }

        [DataMember(Name = "count")]
        public int Count
        {
            get; set;
        }

        [DataMember(Name = "status")]
        public int Status
        {
            get; set;
        }
    }

    [DataContract]
    public class Data
    {
        [DataMember(Name = "type")]
        public string Type
        {
            get; set;
        }

        [DataMember(Name = "properties")]
        public Props Properties
        {
            get; set;
        }

        [DataMember(Name = "geometry")]
        public Geometry Geometry
        {
            get; set;
        }

        [DataMember(Name = "id")]
        public string Id
        {
            get; set;
        }
    }

    [DataContract]
    public class Geometry
    {
        [DataMember(Name = "type")]
        public string Type
        {
            get; set;
        }

        [DataMember(Name = "coordinates")]
        public decimal[] Coordinates
        {
            get; set;
        }
    }

    [DataContract]
    public class Props
    {
        [DataMember(Name = "mag")]
        public decimal? Magnitude
        {
            get; set;
        }

        [DataMember(Name = "place")]
        public string Place
        {
            get; set;
        }

        [DataMember(Name = "time")]
        public long? Time
        {
            get; set;
        }

        [DataMember(Name = "updated")]
        public long? Updated
        {
            get; set;
        }

        [DataMember(Name = "tz")]
        public int? Tz
        {
            get; set;
        }

        [DataMember(Name = "url")]
        public string Url
        {
            get; set;
        }

        [DataMember(Name = "detail")]
        public string Detail
        {
            get; set;
        }

        [DataMember(Name = "felt")]
        public int? Felt
        {
            get; set;
        }

        [DataMember(Name = "cdi")]
        public decimal? Cdi
        {
            get; set;
        }

        [DataMember(Name = "mmi")]
        public decimal? Mmi
        {
            get; set;
        }

        [DataMember(Name = "alert")]
        public string Alert
        {
            get; set;
        }

        [DataMember(Name = "status")]
        public string Status
        {
            get; set;
        }

        [DataMember(Name = "tsunami")]
        public int? Tsunami
        {
            get; set;
        }

        [DataMember(Name = "sig")]
        public int? Sig
        {
            get; set;
        }

        [DataMember(Name = "net")]
        public string Net
        {
            get; set;
        }

        [DataMember(Name = "code")]
        public string Code
        {
            get; set;
        }

        [DataMember(Name = "ids")]
        public string Ids
        {
            get; set;
        }

        [DataMember(Name = "sources")]
        public string Sources
        {
            get; set;
        }

        [DataMember(Name = "types")]
        public string Types
        {
            get; set;
        }

        [DataMember(Name = "nst")]
        public int? Nst
        {
            get; set;
        }

        [DataMember(Name = "dmin")]
        public decimal? Dmin
        {
            get; set;
        }

        [DataMember(Name = "rms")]
        public decimal? Rms
        {
            get; set;
        }

        [DataMember(Name = "gap")]
        public decimal? Gap
        {
            get; set;
        }

        [DataMember(Name = "magType")]
        public string MagType
        {
            get; set;
        }

        [DataMember(Name = "type")]
        public string Type
        {
            get; set;
        }

    }
}
