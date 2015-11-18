using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EMMTY_GO_WEB.Services.ServiceContracts
{
    [ServiceContract(SessionMode=SessionMode.Allowed)]
    public interface IMonitoringService
    {
        [OperationContract]
        bool DataDispenser(string data);

        [OperationContract]
        bool DataTarjeta(string data);

        [OperationContract]
        bool DataAceptadorMonedas(string data);

        [OperationContract]
        bool DataAceptadorBilletes(string data);

        [OperationContract]
        bool DataToneleroA(string data);

        [OperationContract]
        bool DataToneleroB(string data);

        [OperationContract]
        bool DataImpresora(string data);

        [OperationContract]
        bool DataMonitor(string data);

        [OperationContract]
        bool DataScanner(string data);
    }
}
