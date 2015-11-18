using System;
using System.ServiceModel.Activation;
using EMMTY_GO_WEB.Models;

namespace EMMTY_GO_WEB.Services
{

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class MonitoringAjax : ServiceContracts.IMonitoringAjax
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        public bool DataDispenser(string data)
        {
            throw new NotImplementedException();
        }

        public bool DataTarjeta(string data)
        {
            throw new NotImplementedException();
        }

        public bool DataAceptadorMonedas(string data)
        {
            throw new NotImplementedException();
        }

        public bool DataAceptadorBilletes(string data)
        {
            throw new NotImplementedException();
        }

        public bool DataToneleroA(string data)
        {
            throw new NotImplementedException();
        }

        public bool DataToneleroB(string data)
        {
            throw new NotImplementedException();
        }

        public bool DataImpresora(string data)
        {
            throw new NotImplementedException();
        }

        public bool DataMonitor(string data)
        {
            throw new NotImplementedException();
        }

        public bool DataScanner(string data)
        {
            throw new NotImplementedException();
        }
    }

}
