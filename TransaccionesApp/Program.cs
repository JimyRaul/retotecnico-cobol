// See https://aka.ms/new-console-template for more information
using TransaccionesApp;

Console.WriteLine("=== Procesador de Transacciones ===");
Console.WriteLine();

// Validación de argumentos: se espera que se pase un solo argumento (la ruta del archivo CSV)
if (args.Length != 1)
{
    Console.WriteLine("Uso: dotnet run <ruta_del_archivo_csv>");
    return;
}

ProcesadorTransacciones.ProcesarArchivo(args[0]);
Console.WriteLine();