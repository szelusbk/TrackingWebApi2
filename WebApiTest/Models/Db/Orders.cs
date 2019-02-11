using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackingWebApi.Models.Db
{
    [Table("Orders")]
    public class Orders
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("date_from")]
        public DateTime? DateFrom { get; set; }
        [Column("date_to")]
        public DateTime? DateTo { get; set; }
        [Column("customer_name")]
        public string CustomerName { get; set; }
        [Column("vehicle_type")]
        public string VehicleType { get; set; }
        [Column("address")]
        public string Address { get; set; }
        [Column("proj_no")]
        public string ProjectNo { get; set; }
        [Column("distance")]
        public string Distance { get; set; }
        [Column("status")]
        public string Status { get; set; }
        [Column("leader")]
        public string Leader { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;

            Orders orders = obj as Orders;

            return int.Equals(Id, orders.Id)
                    && DateTime.Equals(DateFrom, orders.DateFrom)
                    && DateTime.Equals(DateTo, orders.DateTo)
                    && string.Equals(CustomerName, orders.CustomerName)
                    && string.Equals(VehicleType, orders.VehicleType)
                    && string.Equals(Address, orders.Address)
                    && string.Equals(ProjectNo, orders.ProjectNo)
                    && string.Equals(Distance, orders.Distance)
                    && string.Equals(Status, orders.Status)
                    && string.Equals(Leader, orders.Leader);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                const int HashingBase = (int)2166136261;
                const int HashingMultiplier = 16777619;

                int hash = HashingBase;
                hash = (hash * HashingMultiplier) ^ Id.GetHashCode();
                hash = (hash * HashingMultiplier) ^ ((DateFrom != null) ? DateFrom.GetHashCode() : 0);
                hash = (hash * HashingMultiplier) ^ ((DateTo != null) ? DateTo.GetHashCode() : 0);
                hash = (hash * HashingMultiplier) ^ CustomerName.GetHashCode();
                hash = (hash * HashingMultiplier) ^ VehicleType.GetHashCode();
                hash = (hash * HashingMultiplier) ^ Address.GetHashCode();
                hash = (hash * HashingMultiplier) ^ ProjectNo.GetHashCode();
                hash = (hash * HashingMultiplier) ^ Distance.GetHashCode();
                hash = (hash * HashingMultiplier) ^ Status.GetHashCode();
                hash = (hash * HashingMultiplier) ^ Leader.GetHashCode();
                return hash;
            }
        }
    }
}
