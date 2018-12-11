using System.Collections.Generic;
using System.Linq;
using TrackingWebApi.Models;
using TrackingWebApi.Services.Interfaces;

namespace TrackingWebApi.Services
{
    public class TransportsService : ITransportsService
    {
        private readonly IGpsContext context;

        public TransportsService(IGpsContext context)
        {
            this.context = context;
        }

        public TransportsInfo GetTransportInfo(Transports transport)
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

        public List<TransportsInfo> GetTransportsInfoList(List<Transports> transports)
        {
            List<TransportsInfo> transportsInfoList = new List<TransportsInfo>();

            foreach(Transports t in transports)
            {
                TransportsInfo info = GetTransportInfo(t);
                transportsInfoList.Add(info);
            }

            return transportsInfoList;
        }

        public List<TransportsInfo> GetTransportsInfoList()
        {
            List<TransportsInfo> transportsInfoList = new List<TransportsInfo>();

            var transports = context.Transports.OrderByDescending(x => x.DateFrom).Take(1000).ToList();
            transportsInfoList = GetTransportsInfoList(transports);

            return transportsInfoList;
        }

        public TransportsInfo GetTransportInfo(int orderNo)
        {
            TransportsInfo transportInfo = new TransportsInfo();

            var transport = context.Transports.Where(x => x.Id == orderNo).FirstOrDefault();
            if (transport != null)
            {
                transportInfo = GetTransportInfo(transport);
            }

            return transportInfo;
        }
    }
}
