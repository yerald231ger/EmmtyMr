using EMMTY_GO_WEB.Models;

namespace EMMTY_GO_WEB.Object
{
    public static class CajeroExtencions
    {
        public static Cajero ToSimpleCajero(this Cajero cajero)
        {
            if (cajero == null) return null;
            return new Cajero()
            {
                IdCajero =  cajero.IdCajero,
                ErrorCajero = cajero.ErrorCajero,
                NivelBajoEfectivo = cajero.NivelBajoEfectivo,
                EfectivoActual = cajero.EfectivoActual,
                EfectivoDispensado = cajero.EfectivoDispensado,
                EfectivoInicial = cajero.EfectivoInicial,
                StatusCajero = cajero.StatusCajero,
                Aceptador_Billetes = new Aceptador_Billetes() { ErrorAceptador_Billetes = cajero.Aceptador_Billetes.ErrorAceptador_Billetes, StatusAceptador_Billetes = cajero.Aceptador_Billetes.StatusAceptador_Billetes },
                Aceptador_Monedas = new Aceptador_Monedas() { ErrorAceptador_Monedas = cajero.Aceptador_Monedas.ErrorAceptador_Monedas, StatusAceptador_Monedas = cajero.Aceptador_Monedas.StatusAceptador_Monedas },
                Dispensador = new Dispensador() { EfectivoActualDispensador = cajero.Dispensador.EfectivoActualDispensador, EfectivoDispensadoDispensador = cajero.Dispensador.EfectivoDispensadoDispensador, EfectivoInicialDispensador = cajero.Dispensador.EfectivoInicialDispensador, ErrorDispensador = cajero.Dispensador.ErrorDispensador, StatusDispensador = cajero.Dispensador.StatusDispensador },
                Impresora = new Impresora() { ErrorImpresora = cajero.Impresora.ErrorImpresora, StatusImpresora = cajero.Impresora.StatusImpresora },
                Monitor = new Monitor() { StatusMonitor = cajero.Monitor.StatusMonitor, ErrorMonitor = cajero.Monitor.ErrorMonitor },
                Scanner = new Scanner() { StatusScanner = cajero.Scanner.StatusScanner, ErrorScanner = cajero.Scanner.ErrorScanner },
                Tarjeta = new Tarjeta() { ErrorTarjeta = cajero.Tarjeta.ErrorTarjeta, StatusTarjeta = cajero.Tarjeta.StatusTarjeta },
                ToneleroA = new ToneleroA() { ErrorTonelero = cajero.ToneleroA.ErrorTonelero, StatusTonelero = cajero.ToneleroA.StatusTonelero, EfectivoActualTonelero = cajero.ToneleroA.EfectivoActualTonelero, EfectivoDispensadoTonelero = cajero.ToneleroA.EfectivoDispensadoTonelero, EfectivoInicialTonelero = cajero.ToneleroA.EfectivoInicialTonelero },
                ToneleroB = new ToneleroB() { ErrorTonelero = cajero.ToneleroB.ErrorTonelero, StatusTonelero = cajero.ToneleroB.StatusTonelero, EfectivoActualTonelero = cajero.ToneleroB.EfectivoActualTonelero, EfectivoDispensadoTonelero = cajero.ToneleroB.EfectivoDispensadoTonelero, EfectivoInicialTonelero = cajero.ToneleroB.EfectivoInicialTonelero }

            };
        }
    }
}