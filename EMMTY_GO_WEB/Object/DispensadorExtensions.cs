using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EMMTY_GO_WEB.Models;

namespace EMMTY_GO_WEB.Object
{
    public static class DispensadorExtensions
    {
        public static Dispensador ToSimpleDispensador(this Dispensador dispensador)
        {
            if (dispensador == null) return new Dispensador();
            return new Dispensador
            {
                EfectivoActualDispensador = dispensador.EfectivoActualDispensador,
                EfectivoDispensadoDispensador = dispensador.EfectivoDispensadoDispensador,
                EfectivoInicialDispensador = dispensador.EfectivoInicialDispensador,
                ErrorDispensador = dispensador.ErrorDispensador,
                IdDispensador = dispensador.IdDispensador,
                MarcaDispensador = dispensador.MarcaDispensador,
                ModeloDispensador = dispensador.ModeloDispensador,
                NombreDispensador = dispensador.NombreDispensador,
                NSDispensador = dispensador.NSDispensador,
                StatusDispensador = dispensador.StatusDispensador
            };
        }
    }
}