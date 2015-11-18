using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EMMTY_GO_WEB.Models;

namespace EMMTY_GO_WEB.Object
{
    public static class ImpresoraExtensions
    {
        public static Impresora ToSimpleImpresora(this Impresora impresora)
        {
            if (impresora == null) return new Impresora();
            return new Impresora
            {
                ErrorImpresora = impresora.ErrorImpresora,
                IdImpresora = impresora.IdImpresora,
                MarcaImpresora = impresora.MarcaImpresora,
                ModeloImpresora = impresora.ModeloImpresora,
                NombreImpresora = impresora.NombreImpresora,
                NSImpresora = impresora.NSImpresora,
                StatusImpresora = impresora.StatusImpresora,
                PapelImpresora = impresora.PapelImpresora
            };
        }
    }
}