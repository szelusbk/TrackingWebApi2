using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTest.Models;

namespace WebApiTest.GpsMethods
{
    public static class TransportsService
    {
        public static TransportsInfo GetTransportsInfo(Transports transport)
        {
            TransportsInfo info = new TransportsInfo();

            info.Address = transport.Address;
            info.CustomerName = transport.CustomerName;
            info.DateFrom = transport.DateFrom;
            info.DateTo = transport.DateTo;
            info.Imei = transport.Tracker.imei;
            info.ProjectNo = transport.ProjectNo;
            info.TrackerName = transport.Tracker.name;
            info.VehicleType = transport.VehicleType;

            return info;
        }

        public static List<TransportsInfo> GetTransportsInfoList(List<Transports> transports)
        {
            List<TransportsInfo> infoList = new List<TransportsInfo>();

            foreach(Transports t in transports)
            {
                TransportsInfo info = GetTransportsInfo(t);
                infoList.Add(info);
            }

            return infoList;
        }
    }
}
