using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EMMTY_GO_WEB.Models;

namespace EMMTY_GO_WEB.Object
{
    public static class TarjetaExtensions
    {
        public static Tarjeta ToSimpleTarjeta(this Tarjeta tarjeta)
        {
            if (tarjeta == null) return new Tarjeta();
            return new Tarjeta
            {
                ErrorTarjeta = tarjeta.ErrorTarjeta,
                IdTarjeta = tarjeta.IdTarjeta,
                MarcaTarjeta = tarjeta.MarcaTarjeta, 
                ModeloTarjeta = tarjeta.ModeloTarjeta,
                NSTarjeta = tarjeta.NSTarjeta,
                StatusTarjeta = tarjeta.StatusTarjeta,
                NombreTarjeta = tarjeta.NombreTarjeta
            };
        }
    }
}