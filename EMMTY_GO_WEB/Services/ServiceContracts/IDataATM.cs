using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Serialization;
using EMMTY_GO_WEB.Models;
using System.IO;
using System.Runtime.Serialization.Json;

namespace EMMTY_GO_WEB.Services.ServiceContracts
{
    [ServiceContract(Namespace = "")]
    public interface IDataATM
    {
        [WebGet]
        [OperationContract]
        string GetCashLevelsDispensador(string text);

    }
}
