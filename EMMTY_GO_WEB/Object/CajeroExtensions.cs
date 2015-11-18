using EMMTY_GO_WEB.Models;

namespace EMMTY_GO_WEB.Object
{
    public static class CajeroExtensions
    {
        public static Cajero ToSimpleCajero(this Cajero cajero)
        {
            if (cajero == null) return new Cajero();
            return new Cajero()
            {
                IdCajero =  cajero.IdCajero,
                ErrorCajero = cajero.ErrorCajero,
                NivelBajoEfectivo = cajero.NivelBajoEfectivo,
                EfectivoActual = cajero.EfectivoActual,
                EfectivoDispensado = cajero.EfectivoDispensado,
                EfectivoInicial = cajero.EfectivoInicial,
                StatusCajero = cajero.StatusCajero,
                Aceptador_Billetes = cajero.Aceptador_Billetes.ToSipleAceptador_Billetes(),
                Aceptador_Monedas = cajero.Aceptador_Monedas.ToSimpleAceptadorMonedas(),
                Dispensador = cajero.Dispensador.ToSimpleDispensador(),
                Impresora = cajero.Impresora.ToSimpleImpresora(),
                Scanner = cajero.Scanner.ToSimpleScanner(),
                Tarjeta = cajero.Tarjeta.ToSimpleTarjeta(),
                ToneleroA = cajero.ToneleroA.ToSimpleTonelero<ToneleroA>(),
                ToneleroB = cajero.ToneleroB.ToSimpleTonelero<ToneleroB>()
            };
        }
    }
}