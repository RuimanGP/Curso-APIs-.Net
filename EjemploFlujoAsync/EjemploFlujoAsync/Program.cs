using EjemploFlujoSync;
using EjemploFlujoAsync;
using System.Diagnostics;

// Iniciamos un contador de tiempo - SÍNCRONA
Stopwatch stopwatch = new();
stopwatch.Start();

Console.WriteLine("\nBienvenido a la calculadora de Hipotecas Síncrona");

var aniosVidaLaboral = CalculadoraHipotecaSync.ObtenerAniosVidaLaboral();
Console.WriteLine($"\nAños de Vida Laboral Obtenidos: {aniosVidaLaboral}");

var esTipoContratoIndefinido = CalculadoraHipotecaSync.EsTipoContratoInfefinido();
Console.WriteLine($"\nTipo de contrato indefinido: {esTipoContratoIndefinido}");

var sueldoNeto = CalculadoraHipotecaSync.ObtenerSueldoNeto();
Console.WriteLine($"\nSueldo neto obtenido: {sueldoNeto}");

var gastosMensuales = CalculadoraHipotecaSync.ObetenerGastosMensuales();
Console.WriteLine($"\nGastos Mensuales obtenidos: {gastosMensuales}");

var hipotecaSyncConcedida = CalculadoraHipotecaSync.AnalizarInformacionParaConcederHipoteca(aniosVidaLaboral, esTipoContratoIndefinido, sueldoNeto, gastosMensuales, CantidadSolicitada: 5000, aniosPagar: 30);

var resultado = hipotecaSyncConcedida ? "APROBADA" : "DENEGADA";

Console.WriteLine($"\nAnálisis Finalizado. Su solicitud de hipoteca ha sido: {resultado}");

stopwatch.Stop();

Console.WriteLine($"\nLa operación síncrona ha durado: {stopwatch.Elapsed}");

// Iniciamos un contador de tiempo - ASÍNCRONA
stopwatch.Reset();
stopwatch.Start();

Console.WriteLine("\n*************************************************");
Console.WriteLine("Bienvenido a la calculadora de Hipotecas Síncrona");
Console.WriteLine("*************************************************");

Task<int> aniosVidaLaboralTask = CalculadoraHipotecaAsync.ObtenerAniosVidaLaboral();
Task<bool> esTipoContratoIndefinidoTask = CalculadoraHipotecaAsync.EsTipoContratoInfefinido();
Task<int> sueldoNetoTask = CalculadoraHipotecaAsync.ObtenerSueldoNeto();
Task<int> gastosMensualesTask = CalculadoraHipotecaAsync.ObetenerGastosMensuales();

var analisisHipotecaTasks = new List<Task>
{
    aniosVidaLaboralTask,
    esTipoContratoIndefinidoTask,
    sueldoNetoTask,
    gastosMensualesTask,
};

while (analisisHipotecaTasks.Any())
{
    Task tareaFinalizada = await Task.WhenAny(analisisHipotecaTasks);
    if (tareaFinalizada == aniosVidaLaboralTask)
    {
        Console.WriteLine($"\nAños de Vida Laboral Obtenidos: {aniosVidaLaboralTask.Result}");
    }
    else if (tareaFinalizada ==esTipoContratoIndefinidoTask)
    {
        Console.WriteLine($"\nTipo de contrato indefinido: {esTipoContratoIndefinidoTask.Result}");
    }
    else if ( tareaFinalizada == sueldoNetoTask)
    {
        Console.WriteLine($"\nSueldo neto obtenido: {sueldoNetoTask.Result}");
    }
    else if (tareaFinalizada == gastosMensualesTask)
    {
        Console.WriteLine($"\nGastos Mensuales obtenidos: {gastosMensualesTask.Result}");
    }

    analisisHipotecaTasks.Remove(tareaFinalizada); // eliminamos de la lista de tareas para ir vaciando y salir del while
}

bool hipotecaAsyncConcedida = CalculadoraHipotecaAsync.AnalizarInformacionParaConcederHipoteca(aniosVidaLaboralTask.Result, esTipoContratoIndefinidoTask.Result, sueldoNetoTask.Result, gastosMensualesTask.Result, CantidadSolicitada: 5000, aniosPagar: 30);

var resultadoAsync = hipotecaAsyncConcedida ? "APROBADA" : "DENEGADA";

Console.WriteLine($"\nAnálisis Finalizado. Su solicitud de hipoteca ha sido: {resultadoAsync}");

stopwatch.Stop();

Console.WriteLine($"\nLa operación Asíncrona ha durado: {stopwatch.Elapsed}");

Console.Read();