using System;
using EMMTY_GO_WEB.Models;

namespace EMMTY_GO_WEB.Object
{
    public static class CastTonelero
    {

        public static T ToSimpleTonelero<T>(this ITonelero tonelero)
        {
            var a = tonelero as ToneleroA;
            if (a != null)
            {
                tonelero = new ToneleroA
                {
                    EfectivoActualTonelero = a.EfectivoActualTonelero,
                    EfectivoDispensadoTonelero = a.EfectivoDispensadoTonelero,
                    EfectivoInicialTonelero = a.EfectivoInicialTonelero,
                    ErrorTonelero = a.ErrorTonelero,
                    IdToneleroA = a.IdToneleroA,
                    MarcaTonelero = a.MarcaTonelero,
                    ModeloTonelero = a.ModeloTonelero,
                    NombreTonelero = a.NombreTonelero,
                    StatusTonelero = a.StatusTonelero,
                    NSTonelero = a.NSTonelero
                };

            }
            else
            {
                var b = tonelero as ToneleroB;
                if (b != null)
                {
                    tonelero = new ToneleroB
                    {
                        EfectivoActualTonelero = b.EfectivoActualTonelero,
                        EfectivoDispensadoTonelero = b.EfectivoDispensadoTonelero,
                        EfectivoInicialTonelero = b.EfectivoInicialTonelero,
                        ErrorTonelero = b.ErrorTonelero,
                        IdToneleroB = b.IdToneleroB,
                        MarcaTonelero = b.MarcaTonelero,
                        ModeloTonelero = b.ModeloTonelero,
                        NombreTonelero = b.NombreTonelero,
                        StatusTonelero = b.StatusTonelero,
                        NSTonelero = b.NSTonelero
                    };
                }
            }
            return (T) tonelero;
        }
    }
}

 