using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace EMMTY_GO_WEB.Services.ServiceContracts
{

    [ServiceContract(Namespace = "")]
    public interface IMonitoringAjax
    {
        [WebGet]
        [OperationContract]
        bool DataDispenser(string data);

        [WebGet]
        [OperationContract]
        bool DataTarjeta(string data);

        [WebGet]
        [OperationContract]
        bool DataAceptadorMonedas(string data);

        [WebGet]
        [OperationContract]
        bool DataAceptadorBilletes(string data);

        [WebGet]
        [OperationContract]
        bool DataToneleroA(string data);

        [WebGet]
        [OperationContract]
        bool DataToneleroB(string data);

        [WebGet]
        [OperationContract]
        bool DataImpresora(string data);

        [WebGet]
        [OperationContract]
        bool DataMonitor(string data);

        [WebGet]
        [OperationContract]
        bool DataScanner(string data);
    }
}
