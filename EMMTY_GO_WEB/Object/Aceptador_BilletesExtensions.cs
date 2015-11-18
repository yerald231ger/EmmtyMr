using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EMMTY_GO_WEB.Models;

namespace EMMTY_GO_WEB.Object
{
    public static class AceptadorBilletesExtensions
    {
        public static Aceptador_Billetes ToSipleAceptador_Billetes(this Aceptador_Billetes aceptadorBilletes)
        {
            if (aceptadorBilletes == null) return new Aceptador_Billetes();
            return new Aceptador_Billetes
            {
                ErrorAceptador_Billetes = aceptadorBilletes.ErrorAceptador_Billetes,
                IdAceptador_Billetes =  aceptadorBilletes.IdAceptador_Billetes,
                MarcaAceptador_Billetes = aceptadorBilletes.MarcaAceptador_Billetes,
                ModeloAceptador_Billetes = aceptadorBilletes.ModeloAceptador_Billetes,
                NombreAceptador_Billetes = aceptadorBilletes.NombreAceptador_Billetes,
                NSAceptador_Billetes = aceptadorBilletes.NSAceptador_Billetes,
                StatusAceptador_Billetes = aceptadorBilletes.StatusAceptador_Billetes
            };
        }
    }
}