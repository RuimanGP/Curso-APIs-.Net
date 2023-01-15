using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploFlujoAsync
{
    internal class CalculadoraHipotecaAsync
    {
        public static async Task<int> ObtenerAniosVidaLaboral()
        {
            Console.WriteLine("\nObtenienedo años de vida laboral...");
            await Task.Delay(5000);
            return new Random().Next(1, 35);
        }

        public static async Task<bool> EsTipoContratoInfefinido()
        {
            Console.WriteLine("\nVerificando si el tipo de contrato es indefinido...");
            await Task.Delay(5000);
            return (new Random().Next(1, 10) % 2 == 0);
        }

        public static async Task<int> ObtenerSueldoNeto()
        {
            Console.WriteLine("\nObteniendo sueldo neto...");
            await Task.Delay(5000);
            return new Random().Next(800, 6000);
        }

        public static async Task<int> ObetenerGastosMensuales()
        {
            Console.WriteLine("\nObteniendo gastos mensuales del usuario...");
            await Task.Delay(10000);
            return new Random().Next(200, 1000);
        }

        public static bool AnalizarInformacionParaConcederHipoteca(
            int aniosVidaLaboral,
            bool TipoContratoEsIndefinido,
            int sueldoNeto,
            int gastosMensuales,
            int CantidadSolicitada,
            int aniosPagar)
        {
            Console.WriteLine("\nAnalizando información para conceder hipteca...");

            if (aniosVidaLaboral < 2)
                return false;

            var cuota = (CantidadSolicitada / aniosPagar) / 12;

            if (cuota >= sueldoNeto || cuota > (sueldoNeto / 2))
                return false;

            var porcentajeGatosSobreSueldo = ((gastosMensuales * 100) / sueldoNeto);

            if (porcentajeGatosSobreSueldo > 30)
                return false;

            if ((cuota + gastosMensuales) >= sueldoNeto)
                return false;

            if (!TipoContratoEsIndefinido)
            {

                if ((cuota + gastosMensuales) > (sueldoNeto / 3))
                    return false;
                else
                    return true;
            }

            return true;

        }
    }
}
