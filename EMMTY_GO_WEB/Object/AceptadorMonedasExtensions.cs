using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EMMTY_GO_WEB.Models;

namespace EMMTY_GO_WEB.Object
{
    public static class AceptadorMonedasExtensions
    {
        public static Aceptador_Monedas ToSimpleAceptadorMonedas(this Aceptador_Monedas aceptadorMonedas)
        {
            if (aceptadorMonedas == null) return new Aceptador_Monedas();
            return new Aceptador_Monedas
            {
                IdAceptador_Monedas = aceptadorMonedas.IdAceptador_Monedas,
                ErrorAceptador_Monedas = aceptadorMonedas.ErrorAceptador_Monedas,
                MarcaAceptador_Monedas = aceptadorMonedas.MarcaAceptador_Monedas,
                ModeloAceptador_Monedas = aceptadorMonedas.ModeloAceptador_Monedas,
                NSAceptador_Monedas = aceptadorMonedas.NSAceptador_Monedas,
                NombreAceptador_Monedas = aceptadorMonedas.NombreAceptador_Monedas,
                StatusAceptador_Monedas = aceptadorMonedas.StatusAceptador_Monedas
            };
        }
    }
}