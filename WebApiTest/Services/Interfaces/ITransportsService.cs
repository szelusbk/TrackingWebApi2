using System.Collections.Generic;
using TrackingWebApi.Models;

namespace TrackingWebApi.Services.Interfaces
{
    public interface ITransportsService
    {
        TransportsInfo GetTransportInfo(Transports transport);
        List<TransportsInfo> GetTransportsInfoList(List<Transports> transports);
        List<TransportsInfo> GetTransportsInfoList();
        TransportsInfo GetTransportInfo(int orderNo);
    }
}
