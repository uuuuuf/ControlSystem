using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContrlSystem
{
    internal class Marker
    {
        public string MarkerID { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Altitude { get; set; }
        public GMarkerGoogle GMapMarker { get; set; }

        public Marker(string markerID, double latitude, double longitude, GMarkerGoogle gMarker)
        {
            MarkerID = markerID;
            Latitude = latitude;
            Longitude = longitude;
            GMapMarker = gMarker;
        }
    }
}
