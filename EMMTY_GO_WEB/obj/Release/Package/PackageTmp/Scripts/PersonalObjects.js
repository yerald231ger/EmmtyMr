
//function Cajero() {
//    this.EfectivoActual = 0;
//    this.EfectivoDispensado = 0;
//    this.EfectivoInicial = 0;
//    this.IdCajero = 0;
//    this.NivelBajoEfectivo = 0;
//    this.ErrorCajero = null;
//    this.StatusCajero = null;
//    Aceptador_Billetes = null;
//    Aceptador_Monedas = null;
//    Dispensador = null;
//    Impresora = null;
//    Monitor = null;
//    Scanner = null;
//    Tarjeta = null;
//    ToneleroA = null;
//    ToneleroB = null;
//}

//function Aceptador_Billetes() {
//    this.ErrorAceptador_Billetes = null;
//    this.StatusAceptador_Billetes = null;
//}

//function Aceptador_Monedas() {
//    this.ErrorAceptador_Monedas = null;
//    this.StatusAceptador_Monedas = null;
//}

//function Dispensador() {
//    this.EfectivoActualDispensador = 0;
//    this.EfectivoDispensadoDispensador = 0;
//    this.EfectivoInicialDispensador = 0;
//    this.ErrorDispensador = null;
//    this.StatusDispensador = null;
//}

//function Impresora() {
//    this.ErrorImpresora = null;
//    this.StatusImpresora = null;
//}

//function Monitor() {
//    this.StatusMonitor = null;
//    this.ErrorMonitor = null;
//}

//function Scanner() {
//    this.ErrorScanner = null;
//    this.StatusScanner = null;
//}

//function Tarjeta() {
//    this.ErrorTarjeta = null;
//    this.StatusTarjeta = null;
//}

//function ToneleroA() {
//    this.ErrorTonelero = null;
//    this.StatusTonelero = null;
//    this.EfectivoActualTonelero = 0;
//    this.EfectivoDispensadoTonelero = 0;
//    this.EfectivoInicialTonelero = 0;
//}

//function ToneleroB() {
//    this.ErrorTonelero = null;
//    this.StatusTonelero = null;
//    this.EfectivoActualTonelero = 0;
//    this.EfectivoDispensadoTonelero = 0;
//    this.EfectivoInicialTonelero = 0;
//}

//function JsonDataToCajero(jsonData) {
//    var c = new Cajero();
//    c.EfectivoActual = jsonData["EfectivoActual"];
//    c.EfectivoDispensado = jsonData["EfectivoDispensado"];
//    c.EfectivoInicial = jsonData["EfectivoInicial"];
//    return c;
//}

//var CajeroJson = {
//    ColorCajero: null,
//    FechaEntregaCajero: null,
//    FechaSalidaCajero: null,
//    FechaEnsambladoCajero: null,
//    IdCajero: 1,
//    NSCajero: null,
//    NombreCajero: null,
//    NombreEnsamblador: null,
//    UbicacionCajero: null,
//    ErrorCajero: null,
//    IdAceptador_Billetes: null,
//    IdDispensador: null,
//    IdCliente: null,
//    IdPC: null,
//    IdImpresora: null,
//    IdAceptador_Monedas: null,
//    IdTarjeta: null,
//    IdUPS: null,
//    IdScanner: null,
//    IdMonitor: null,
//    IdSucursal: null,
//    StatusCajero: "HopperJam",
//    ModeloCajero: null,
//    TipoCajero: null,
//    IdToneleroA: null,
//    IdToneleroB: null,
//    EfectivoActual: 3000,
//    EfectivoDispensado: 5000,
//    EfectivoInicial: 5000,
//    NivelBajoEfectivo: 5000,
//    LastRowUpdate: null,
//    Aceptador_Billetes: {
//            IdAceptador_Billetes: 0,
//            ModeloAceptador_Billetes: null,
//            NombreAceptador_Billetes: null,
//            NSAceptador_Billetes: null,
//            StatusAceptador_Billetes: "Working",
//            ErrorAceptador_Billetes: "NoError",
//            MarcaAceptador_Billetes: null,
//            Cajeros: null
//        },
//    Aceptador_Monedas: {
//            IdAceptador_Monedas: 0,
//            ModeloAceptador_Monedas: null,
//            NombreAceptador_Monedas: null,
//            NSAceptador_Monedas: null,
//            StatusAceptador_Monedas: "Unknow",
//            ErrorAceptador_Monedas: "NoError",
//            MarcaAceptador_Monedas: null,
//            Cajeros: null
//        },
//    Cliente: null,
//    Dispensador: {
//            IdDispensador: 0,
//            EfectivoActualDispensador: 5000,
//            EfectivoDispensadoDispensador: 0,
//            EfectivoInicialDispensador: 5000,
//            ModeloDispensador: null,
//            NSDispensador: null,
//            StatusDispensador: "Working",
//            TipoBillete: null,
//            ErrorDispensador: "NoError",
//            MarcaDispensador: null,
//            NombreDispensador: null,
//            Cajeros: null
//        },
//    Impresora: {
//        IdImpresora: 0,
//        NSImpresora: null,
//        NombreImpresora: null,
//        ModeloImpresora: null,
//        StatusImpresora: "Working",
//        PapelImpresora: null,
//        ErrorImpresora: "NoError",
//        MarcaImpresora: null,
//        Cajeros: null
//    },
//    Monitor: {
//        IdMonitor: 0,
//        MarcaMonitor: null,
//        ModeloMonitor: null,
//        NombreMonitor: null,
//        NSMonitor: null,
//        StatusMonitor: "Working",
//        ErrorMonitor: "NoError",
//        Cajeros: null
//    },
//    PC: null,
//    Scanner: {
//        IdScanner: 0,
//        MarcaScanner: null,
//        MoneloScanner: null,
//        NombreScanner: null,
//        NSScanner: null,
//        StatusScanner: "Working",
//        ErrorScanner: "NoError",
//        Cajeros: null
//    },
//    Sucursal: null,
//    Tarjeta: {
//        IdTarjeta: 0,
//        ModeloTarjeta: null,
//        NSTarjeta: null,
//        StatusTarjeta: "Wokring",
//        ErrorTarjeta: "NoError",
//        MarcaTarjeta: null,
//        NombreTarjeta: null,
//        Cajeros: null
//    },
//    ToneleroA: {
//            IdTonelero: 0,
//            NombreTonelero: null,
//            ModeloTonelero: null,
//            STonelero: null,
//            StatusTonelero: "Working",
//            TipoMoneda: null,
//            EfectivoActualTonelero: 5000,
//            EfectivoDispensadoTonelero: 0,
//            EfectivoInicialTonelero: 5000,
//            ErrorTonelero: "NoError",
//            arcaTonelero: null,
//            Cajeros: null,
//            Cajeros1: null
//    },
//    ToneleroB: {
//        IdTonelero: 0,
//        NombreTonelero: null,
//        ModeloTonelero: null,
//        NSTonelero: null,
//        StatusTonelero: "Working",
//        TipoMoneda: null,
//        EfectivoActualTonelero: 5000,
//        EfectivoDispensadoTonelero: 0,
//        EfectivoInicialTonelero: 5000,
//        ErrorTonelero: "NoError",
//        MarcaTonelero: null,
//        Cajeros: null,
//        Cajeros1: null
//    },
//    UPS: null,
//    ReportesXCajero: null
//}