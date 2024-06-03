using System;
using EspacioEmpleado;
/*
//opcion1
Empleado empleado1 = new Empleado("Juan", "Pérez", new DateTime(1990, 5, 15), 'S', new DateTime(2010, 3, 20), 50000, Cargos.Ingeniero);
Empleado empleado2 = new Empleado("María", "González", new DateTime(1985, 8, 10), 'C', new DateTime(2005, 6, 12), 60000, Cargos.Especialista);
Empleado empleado3 = new Empleado("Pedro", "López", new DateTime(1995, 2, 25), 'S', new DateTime(2018, 9, 5), 45000, Cargos.Auxiliar);
Empleado[] arreglo= new Empleado[]{empleado1,empleado2,empleado3};
*/
//opcion 2
Empleado[] arreglo = new Empleado[3];

for (int i = 0; i < 3; i++)
{
    Console.WriteLine($"Ingrese los datos del empleado {i + 1}:");
    string nombre = LeerDatoNoVacio("Nombre");
    string apellido = LeerDatoNoVacio("Apellido");
    DateTime fechaNacimiento = LeerFecha("Fecha de nacimiento (yyyy-MM-dd)");
    char estadoCivil = LeerEstadoCivil("Estado civil (S/C)");
    DateTime fechaIngreso = LeerFecha("Fecha de ingreso en la empresa (yyyy-MM-dd)");
    double sueldoBasico = LeerDouble("Sueldo básico");
    Cargos cargo = LeerCargo("Cargo (Auxiliar/Administrativo/Ingeniero/Especialista/Investigador)");
    arreglo[i] = new Empleado(nombre, apellido, fechaNacimiento, estadoCivil, fechaIngreso, sueldoBasico, cargo);
}
double salarioTotal=0;
foreach (Empleado item in arreglo)
{
    salarioTotal+= item.CalcularSalario();   
}
Console.WriteLine($"Monto Total de salarios {salarioTotal}");

Empleado proximoJubilacion = arreglo.OrderBy(emp => emp.AniosHastaJubilacion()).First();
Console.WriteLine($"Empleado más próximo a jubilarse: {proximoJubilacion.Nombre} {proximoJubilacion.Apellido}");
Console.WriteLine($"Edad: {proximoJubilacion.edad()}");
Console.WriteLine($"Antigüedad: {proximoJubilacion.Antiguedad()} años");
Console.WriteLine($"Años hasta jubilación: {proximoJubilacion.AniosHastaJubilacion()}");
Console.WriteLine($"Salario: {proximoJubilacion.CalcularSalario()}");

//opcion 2
static string LeerDatoNoVacio(string mensaje){
    string? datito;
    do
    {
        Console.Write($"{mensaje}");
        datito = Console.ReadLine();
    } while (string.IsNullOrWhiteSpace(datito));
    return datito;
}
static DateTime LeerFecha(string mensaje)
{
    DateTime fecha;
    while (!DateTime.TryParse(Console.ReadLine(), out fecha))
    {
        Console.Write($"{mensaje} inválida. Ingrese nuevamente: ");
    }
    return fecha;
}
static char LeerEstadoCivil(string mensaje){
    char estadoCivil;
    while (!char.TryParse(Console.ReadLine(), out estadoCivil) || (estadoCivil != 'S' && estadoCivil != 'C'))
    {
        Console.Write($"{mensaje} inválido. Ingrese nuevamente (S/C): ");
    }
    return estadoCivil;
}
static double LeerDouble(string mensaje){
    double sueldo;
    while (!double.TryParse(Console.ReadLine(), out sueldo) || sueldo <= 0)
    {
        Console.Write($"{mensaje} inválido. Ingrese nuevamente: ");
    }
    return sueldo;
}
static Cargos LeerCargo(string mensaje){
    int opcion;
    while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 5)
    {
        Console.Write($"{mensaje} inválido. Ingrese nuevamente (1-5): ");
    }
    return (Cargos)opcion;
}
