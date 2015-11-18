using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EMMTY_GO_WEB.Models;

namespace EMMTY_GO_WEB.Object
{
    public static class ScannerExtensions
    {
        public static Scanner ToSimpleScanner(this Scanner scanner)
        {
            if (scanner == null) return new Scanner();
            return new Scanner
            {
                ErrorScanner = scanner.ErrorScanner,
                IdScanner = scanner.IdScanner,
                MarcaScanner = scanner.MarcaScanner,
                ModeloScanner = scanner.ModeloScanner,
                NSScanner = scanner.NSScanner,
                NombreScanner = scanner.NombreScanner,
                StatusScanner = scanner.StatusScanner
            };
        }
    }
}