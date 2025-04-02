using System.Globalization;

namespace TransaccionesApp;

/// <summary>
/// Clase que contiene la lógica para procesar transacciones desde un archivo CSV.
/// </summary>
public static class ProcesadorTransacciones
{
    public static void ProcesarArchivo(string rutaArchivo)
    {
        // Validar si el archivo existe en la ruta especificada
        if (!File.Exists(rutaArchivo))
        {
            Console.WriteLine("El archivo no existe: " + rutaArchivo);
            return;
        }

        var transacciones = new List<Transaccion>(); // Lista donde se almacenarán todas las transacciones

        try
        {
            // Leer todas las líneas del archivo, ignorando la primera (encabezados)
            var lineas = File.ReadAllLines(rutaArchivo).Skip(1);

            // Procesar cada línea del archivo CSV
            foreach (var linea in lineas)
            {
                var partes = linea.Split(',');

                // Validar que la línea tenga exactamente 3 partes: id, tipo, monto
                if (partes.Length != 3)
                    continue;

                // Crear un objeto Transaccion a partir de la línea
                transacciones.Add(new Transaccion
                {
                    Id = int.Parse(partes[0]),
                    Tipo = partes[1].Trim(),
                    Monto = decimal.Parse(partes[2], CultureInfo.InvariantCulture)
                });
            }

            // Calcular el total de montos para transacciones de tipo "Crédito"
            var totalCredito = transacciones
                .Where(t => t.Tipo.Equals("Crédito", StringComparison.OrdinalIgnoreCase))
                .Sum(t => t.Monto);

            // Calcular el total de montos para transacciones de tipo "Débito"
            var totalDebito = transacciones
                .Where(t => t.Tipo.Equals("Débito", StringComparison.OrdinalIgnoreCase))
                .Sum(t => t.Monto);

            // Calcular el balance final: créditos - débitos
            var balanceFinal = totalCredito - totalDebito;

            // Encontrar la transacción con el monto más alto
            var transaccionMayor = transacciones
                .OrderByDescending(t => t.Monto)
                .First();

            // Contar la cantidad de transacciones de tipo "Crédito"
            var conteoCredito = transacciones
                .Count(t => t.Tipo.Equals("Crédito", StringComparison.OrdinalIgnoreCase));

            // Contar la cantidad de transacciones de tipo "Débito"
            var conteoDebito = transacciones
                .Count(t => t.Tipo.Equals("Débito", StringComparison.OrdinalIgnoreCase));

            // Mostrar el reporte en la terminal
            Console.WriteLine("Reporte de Transacciones");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine($"Balance Final: {balanceFinal:F2}");
            Console.WriteLine($"Transacción de Mayor Monto: ID {transaccionMayor.Id} - {transaccionMayor.Monto:F2}");
            Console.WriteLine($"Conteo de Transacciones: Crédito: {conteoCredito} Débito: {conteoDebito}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error procesando el archivo: " + ex.Message);
        }
        finally
        {
            Console.WriteLine();
            Console.WriteLine(" - Proceso de lectura de transacciones finalizado.");
        }
    }
}
