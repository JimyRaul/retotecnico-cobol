# 📊 Procesador de Transacciones Bancarias (CLI) - .NET 8

## 🧾 Introducción

Este proyecto es una aplicación de línea de comandos desarrollada en **C# con .NET 8**. Su objetivo es procesar un archivo CSV con transacciones bancarias para generar un reporte que contenga:

- 💰 Balance Final (Créditos - Débitos)
- 🔍 Transacción de Mayor Monto
- 📊 Conteo de Transacciones por tipo ("Crédito" y "Débito")

---

## ▶️ Instrucciones de Ejecución

### 1. Requisitos

- Tener instalado **.NET 8 SDK**
  - Verifica la instalación con: `dotnet --version`
  - Descarga desde: https://dotnet.microsoft.com/download/dotnet/8.0

### 2. Crear archivo CSV de prueba

Contenido sugerido para `datos.csv`:

id,tipo,monto  
1,Crédito,100.00  
2,Débito,50.00  
3,Crédito,200.00  
4,Débito,75.00  
5,Crédito,150.00  

### 3. Ejecutar la aplicación

Ubicado en la carpeta del proyecto:

dotnet run -- datos.csv

---

## ⚙️ Enfoque y Solución

- Se creó una clase `Transaccion` para representar los datos.
- Toda la lógica de lectura, cálculo y reporte se colocó en `ProcesadorTransacciones.cs`.
- Se usó LINQ para sumar, contar y encontrar la transacción con mayor monto.
- Se separaron las responsabilidades y se manejaron errores de entrada.

---

## 📁 Estructura del Proyecto

TransaccionesApp/  
├── Program.cs  
├── Models/Transaccion.cs  
├── Services/ProcesadorTransacciones.cs  
├── datos.csv  
├── TransaccionesApp.csproj  
└── README.md

La estructura del proyecto sigue una organización clara y modular: 
- El archivo `Program.cs` actúa como punto de entrada principal, mientras que la carpeta `Models` contiene la clase `Transaccion.cs` que representa los datos de cada transacción. 
- La lógica de procesamiento y generación del reporte está encapsulada en `ProcesadorTransacciones.cs`, dentro de la carpeta `Services`, promoviendo la separación de responsabilidades y facilitando el mantenimiento del código.

---

## ✅ Resultado Esperado

=== Procesador de Transacciones ===  
Reporte de Transacciones  
---------------------------------------------  
Balance Final: 325.00  
Transacción de Mayor Monto: ID 3 - 200.00  
Conteo de Transacciones: Crédito: 3 Débito: 2  