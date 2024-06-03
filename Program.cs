using System;
using System.Globalization;
using EspacioEmpleado;
//opcion 2
Empleado[] arreglo = new Empleado[3];

for (int i = 0; i < 3; i++)
{
    Console.WriteLine($"Ingrese los datos del empleado {i + 1}:");
    string nombre = LeerDatoNoVacio("Nombre");
    string apellido = LeerDatoNoVacio("Apellido");
    DateTime fechaNacimiento = LeerFecha("Fecha de nacimiento (yyyy-MM-dd)");//ejemplo 1990-05-02. en casode mes y dia siempre 2 numeros
    char estadoCivil = LeerEstadoCivil("Estado civil (S/C)");
    DateTime fechaIngreso = LeerFecha("Fecha de ingreso en la empresa (yyyy-MM-dd)");
    double sueldoBasico = LeerDouble("Sueldo básico");
    Cargos cargo = LeerCargo("Cargo (Auxiliar/Administrativo/Ingeniero/Especialista/Investigador)");
    arreglo[i] = new Empleado(nombre, apellido, fechaNacimiento, estadoCivil, fechaIngreso, sueldoBasico, cargo);
}
/*
//opcion1
Empleado empleado1 = new Empleado("Juan", "Pérez", new DateTime(1990, 5, 15), 'S', new DateTime(2010, 3, 20), 50000, Cargos.Ingeniero);
Empleado empleado2 = new Empleado("María", "González", new DateTime(1985, 8, 10), 'C', new DateTime(2005, 6, 12), 60000, Cargos.Especialista);
Empleado empleado3 = new Empleado("Pedro", "López", new DateTime(1995, 2, 25), 'S', new DateTime(2018, 9, 5), 45000, Cargos.Auxiliar);
Empleado[] arreglo= new Empleado[]{empleado1,empleado2,empleado3};
*/
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
        Console.Write($"{mensaje}: ");
        datito = Console.ReadLine();
    } while (string.IsNullOrWhiteSpace(datito));
    return datito;
}
static DateTime LeerFecha(string mensaje)
{
    DateTime fecha;
    while (true)
    {
        Console.Write($"{mensaje}: ");
        if (DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out fecha))
        {
            return fecha;
        }
        else
        {
            Console.WriteLine("Fecha inválida. Inténtalo nuevamente en el formato 'aaaa-MM-dd'.");
        }
    }
}
static char LeerEstadoCivil(string mensaje)
{
    char estadoCivil;
    do
    {
        Console.Write($"{mensaje}: ");
    } while (!char.TryParse(Console.ReadLine(), out estadoCivil) || (estadoCivil != 'S' && estadoCivil != 'C'));
    return estadoCivil;
}
static double LeerDouble(string mensaje)
{
    double sueldo;
    do
    {
        Console.Write($"{mensaje}: ");
    } while (!double.TryParse(Console.ReadLine(), out sueldo) || sueldo <= 0);
    return sueldo;
}
static Cargos LeerCargo(string mensaje)
{
    string? cargo;
    while (true)
    {
        Console.Write($"{mensaje}: ");
        cargo = Console.ReadLine();
        if (Enum.TryParse(cargo, true, out Cargos resultado))
        {
            return resultado;
        }
        else
        {
            Console.WriteLine("Cargo inválido. Ingrese nuevamente (Auxiliar/Administrativo/Ingeniero/Especialista/Investigador): ");
        }
    }
}

