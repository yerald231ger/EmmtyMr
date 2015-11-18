
using System.ServiceModel.Activation;
using EMMTY_GO_WEB.Models;

namespace EMMTY_GO_WEB.Services
{
    
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class DataATM : ServiceContracts.IDataATM
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        public string GetCashLevelsDispensador(string text)
        {            
            //Dispensador dispensador = db.Dispensadores.Find(IdDispensador);
            string response = "Este Texto a Sido enviado desde un Servicio WCF Habiltitado para AJAX: "+text;
            return response;
        }
    }

    
}
