using System;

namespace TrackingWebApi.Models
{
    public class TransportsInfo
    {
        public int OrderNo { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string CustomerName { get; set; }
        public string VehicleType { get; set; }
        public string Address { get; set; }
        public string ProjectNo { get; set; }
        public string Imei { get; set; }
        public string TrackerName { get; set; }
        public string AddressLatitude { get; set; }
        public string AddressLongitude { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;

            TransportsInfo transportsInfo = obj as TransportsInfo;

            return int.Equals(OrderNo, transportsInfo.OrderNo)
                    && DateTime.Equals(DateFrom, transportsInfo.DateFrom)
                    && DateTime.Equals(DateTo, transportsInfo.DateTo)
                    && string.Equals(CustomerName, transportsInfo.CustomerName)
                    && string.Equals(VehicleType, transportsInfo.VehicleType)
                    && string.Equals(Address, transportsInfo.Address)
                    && string.Equals(ProjectNo, transportsInfo.ProjectNo)
                    && string.Equals(Imei, transportsInfo.Imei)
                    && string.Equals(TrackerName, transportsInfo.TrackerName)
                    && string.Equals(AddressLatitude, transportsInfo.AddressLatitude)
                    && string.Equals(AddressLongitude, transportsInfo.AddressLongitude);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                const int HashingBase = (int)2166136261;
                const int HashingMultiplier = 16777619;

                int hash = HashingBase;
                hash = (hash * HashingMultiplier) ^ OrderNo.GetHashCode();
                hash = (hash * HashingMultiplier) ^ ((DateFrom != null) ? DateFrom.GetHashCode() : 0);
                hash = (hash * HashingMultiplier) ^ ((DateTo != null) ? DateTo.GetHashCode() : 0);
                hash = (hash * HashingMultiplier) ^ CustomerName.GetHashCode();
                hash = (hash * HashingMultiplier) ^ VehicleType.GetHashCode();
                hash = (hash * HashingMultiplier) ^ Address.GetHashCode();
                hash = (hash * HashingMultiplier) ^ ProjectNo.GetHashCode();
                hash = (hash * HashingMultiplier) ^ Imei.GetHashCode();
                hash = (hash * HashingMultiplier) ^ TrackerName.GetHashCode();
                hash = (hash * HashingMultiplier) ^ AddressLatitude.GetHashCode();
                hash = (hash * HashingMultiplier) ^ AddressLongitude.GetHashCode();
                return hash;
            }
        }
    }
}
