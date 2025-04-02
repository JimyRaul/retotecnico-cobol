namespace TransaccionesApp;

/// <summary>
/// Representa una transacción bancaria con ID, tipo y monto.
/// </summary>
public class Transaccion
{
    public int Id { get; set; }                  // ID único de la transacción
    public required string Tipo { get; set; }    // Tipo de transacción: "Crédito" o "Débito"
    public decimal Monto { get; set; }           // Monto de la transacción
}
