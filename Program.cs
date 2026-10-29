using System;

namespace CapitalizacionRecursiva
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("==================================================");
            Console.WriteLine("   MÓDULO DE CAPITALIZACIÓN RECURSIVA (INTERÉS)   ");
            Console.WriteLine("==================================================\n");

            // 1. Lectura y validación de entradas
            double capitalInicial = LeerDecimalPositivo("Ingrese el capital inicial (m): $");
            double tasaPorcentaje = LeerTasaInteres("Ingrese la tasa de interés anual X (%): ");
            int anos = LeerEnteroPositivo("Ingrese el tiempo de inversión en años (n): ");

            // Convertir tasa porcentual X a factor i = X / 100
            double interesFactor = tasaPorcentaje / 100.0;

            // 2. Ejecución de la función ESTRICTAMENTE RECURSIVA
            double montoFinal = CalcularCapitalizacionRecursiva(capitalInicial, interesFactor, anos);

            // 3. Presentación de resultados
            Console.WriteLine("\n--------------------------------------------------");
            Console.WriteLine("                 RESUMEN DEL CÁLCULO               ");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"Capital Inicial (m):       ${capitalInicial:N2}");
            Console.WriteLine($"Tasa Anual (X):            {tasaPorcentaje}%");
            Console.WriteLine($"Factor de Interés (i):      {interesFactor:F4}");
            Console.WriteLine($"Factor de Crecimiento:     {(1 + interesFactor):F4}");
            Console.WriteLine($"Tiempo (n):                {anos} año(s)");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"Monto Acumulado C({anos}):    ${montoFinal:N2}");
            Console.WriteLine("--------------------------------------------------");

            // Desglose año por año para evidenciar el comportamiento recursivo
            Console.WriteLine("\nDesglose de capitalización año por año:");
            for (int k = 0; k <= anos; k++)
            {
                double c_k = CalcularCapitalizacionRecursiva(capitalInicial, interesFactor, k);
                Console.WriteLine($" - Año {k}: ${c_k:N2}");
            }

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }

        /// <summary>
        /// Calcula el monto acumulado C(n) utilizando una función ESTRICTAMENTE RECURSIVA.
        /// Cumple la restricción técnica de evitar bucles (for, while).
        /// </summary>
        /// <param name="m">Capital inicial depositado.</param>
        /// <param name="i">Factor de interés (X / 100).</param>
        /// <param name="n">Tiempo de inversión en años.</param>
        /// <returns>Monto total acumulado al finalizar el año n.</returns>
        static double CalcularCapitalizacionRecursiva(double m, double i, int n)
        {
            // Caso Base (Estado Básico): Si n == 0, C(0) = m
            if (n == 0)
            {
                return m;
            }

            // Caso Recursivo (Estado Recursivo): C(n) = C(n - 1) * (1 + i)
            return CalcularCapitalizacionRecursiva(m, i, n - 1) * (1 + i);
        }

        #region Métodos de Validación de Entrada

        static double LeerDecimalPositivo(string mensaje)
        {
            double valor;
            do
            {
                Console.Write(mensaje);
            } while (!double.TryParse(Console.ReadLine(), out valor) || valor <= 0);
            return valor;
        }

        static double LeerTasaInteres(string mensaje)
        {
            double tasa;
            do
            {
                Console.Write(mensaje);
            } while (!double.TryParse(Console.ReadLine(), out tasa) || tasa <= 0);
            return tasa;
        }

        static int LeerEnteroPositivo(string mensaje)
        {
            int entero;
            do
            {
                Console.Write(mensaje);
            } while (!int.TryParse(Console.ReadLine(), out entero) || entero < 0);
            return entero;
        }

        #endregion
    }
}