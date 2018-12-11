using System;
using System.Collections.Generic;
using System.Linq;

namespace TrackingWebApi.Models
{
    public class RouteInfo
    {
        public string GpsName { get; set; }
        public string GpsStatus { get; set; }
        public string Imei { get; set; }
        public string LastDate { get; set; }
        public string Battery { get; set; }
        public string ElapsedTime { get; set; }
        public string Distance { get; set; }
        public string GoogleDistance { get; set; }
        public string LastLatitude { get; set; }
        public string LastLongitude { get; set; }
        public List<LatLng> LatLngList { get; set; } = new List<LatLng>();

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;

            RouteInfo routeInfo = obj as RouteInfo;

            return string.Equals(GpsName, routeInfo.GpsName)
                    && string.Equals(GpsStatus, routeInfo.GpsStatus)
                    && string.Equals(Imei, routeInfo.Imei)
                    && string.Equals(LastDate, routeInfo.LastDate)
                    && string.Equals(Battery, routeInfo.Battery)
                    && string.Equals(Imei, routeInfo.Imei)
                    && string.Equals(ElapsedTime, routeInfo.ElapsedTime)
                    && string.Equals(Distance, routeInfo.Distance)
                    && string.Equals(GoogleDistance, routeInfo.GoogleDistance)
                    && string.Equals(LastLatitude, routeInfo.LastLatitude)
                    && string.Equals(LastLongitude, routeInfo.LastLongitude)
                    && Enumerable.SequenceEqual(LatLngList, LatLngList);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                const int HashingBase = (int)2166136261;
                const int HashingMultiplier = 16777619;

                int hash = HashingBase;
                hash = (hash * HashingMultiplier) ^ GpsName.GetHashCode();
                hash = (hash * HashingMultiplier) ^ GpsStatus.GetHashCode();
                hash = (hash * HashingMultiplier) ^ Imei.GetHashCode();
                hash = (hash * HashingMultiplier) ^ LastDate.GetHashCode();
                hash = (hash * HashingMultiplier) ^ Battery.GetHashCode();
                hash = (hash * HashingMultiplier) ^ ElapsedTime.GetHashCode();
                hash = (hash * HashingMultiplier) ^ Distance.GetHashCode();
                hash = (hash * HashingMultiplier) ^ Imei.GetHashCode();
                hash = (hash * HashingMultiplier) ^ GoogleDistance.GetHashCode();
                hash = (hash * HashingMultiplier) ^ LastLatitude.GetHashCode();
                hash = (hash * HashingMultiplier) ^ LastLongitude.GetHashCode();
                hash = (hash * HashingMultiplier) ^ ((LatLngList != null) ? LatLngList.GetHashCode() : 0);
                return hash;
            }
        }
    }

    public class LatLng
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public override string ToString()
        {
            return Latitude + ", " + Longitude;
        }
    }
}
