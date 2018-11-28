using System.Collections.Generic;
using System.Linq;
using WebApiTest.Models;

namespace WebApiTest.GpsMethods
{
    public static class TransportsService
    {
        public static TransportsInfo GetTransportInfo(Transports transport)
        {
            TransportsInfo transportInfo = new TransportsInfo()
            {
                OrderNo = transport.Id,
                Address = transport.Address,
                CustomerName = transport.CustomerName,
                DateFrom = transport.DateFrom,
                DateTo = transport.DateTo,
                Imei = transport.Tracker.Imei,
                ProjectNo = transport.ProjectNo,
                TrackerName = transport.Tracker.Name,
                VehicleType = transport.VehicleType,
                AddressLatitude = transport.AddressLatitude,
                AddressLongitude = transport.AddressLongitude,
            };

            return transportInfo;
        }

        public static List<TransportsInfo> GetTransportsInfoList(List<Transports> transports)
        {
            List<TransportsInfo> transportsInfoList = new List<TransportsInfo>();

            foreach(Transports t in transports)
            {
                TransportsInfo info = GetTransportInfo(t);
                transportsInfoList.Add(info);
            }

            return transportsInfoList;
        }

        public static List<TransportsInfo> GetTransportsInfoList()
        {
            List<TransportsInfo> transportsInfoList = new List<TransportsInfo>();

            using (var context = new GPSContext())
            {
                var transports = context.Transports.OrderByDescending(x => x.DateFrom).Take(1000).ToList();
                transportsInfoList = GetTransportsInfoList(transports);
            }

            return transportsInfoList;
        }

        public static TransportsInfo GetTransportInfo(int orderNo)
        {
            TransportsInfo transportInfo = new TransportsInfo();

            using (var context = new GPSContext())
            {
                var transport = context.Transports.Where(x => x.Id == orderNo).FirstOrDefault();
                if (transport != null)
                {
                    transportInfo = GetTransportInfo(transport);
                }
            }

            return transportInfo;
        }
    }
}
