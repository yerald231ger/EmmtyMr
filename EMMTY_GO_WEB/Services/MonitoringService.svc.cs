using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using EMMTY_GO_WEB.Models;

namespace EMMTY_GO_WEB.Services
{
    public class MonitoringService : ServiceContracts.IMonitoringService
    {
        ApplicationDbContext bd = new ApplicationDbContext();

        public bool DataDispenser(string data)
        {
            Dispensador dispensador = bd.Dispensadores.First(d => d.NSDispensador == "016786");
            dispensador.EfectivoDispensadoDispensador = int.Parse(data);
            bd.SaveChanges();
            return true;
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
