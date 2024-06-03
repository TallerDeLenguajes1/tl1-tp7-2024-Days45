using System;
namespace EspacioEmpleado;
public enum Cargos
{
    Auxiliar,
    Administrativo,
    Ingeniero,
    Especialista,
    Investigador
}
public class Empleado
{
    private string nombre;
    public string Nombre { get => nombre; set => nombre = value; }
    private string apellido;
    public string Apellido { get => apellido; set => apellido = value; }
    private DateTime fechaNacimiento;
    public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
    private char estadoCivil;
    public char EstadoCivil { get => estadoCivil; set => estadoCivil = value; }
    private DateTime fechaIngreso;
    public DateTime FechaIngreso { get => fechaIngreso; set => fechaIngreso = value; }
    private double sueldoBasico;
    public double SueldoBasico { get => sueldoBasico; set => sueldoBasico = value; }
    private Cargos cargo; 
    public Cargos Cargo { get => cargo; set => cargo = value; }
    public Empleado(string nombre, string apellido, DateTime fechaNacimiento, char estadoCivil, DateTime fechaIngreso, double sueldoBasico, Cargos cargo){
        this.nombre = nombre;
        this.apellido = apellido;
        this.fechaNacimiento = fechaNacimiento;
        this.estadoCivil = estadoCivil;
        this.fechaIngreso = fechaIngreso;
        this.sueldoBasico = sueldoBasico;
        this.cargo = cargo; 
    }
    public int Antiguedad()
    { 
        return DateTime.Now.Year - fechaIngreso.Year;  
    }
    public int edad(){
        return DateTime.Now.Year-fechaNacimiento.Year;
    }
    public int AniosHastaJubilacion()
    {
        return 65 - edad();  
    }
    public double CalcularSalario(){
        double adicional=0;
        if (Antiguedad()<20)
        {
            adicional+=sueldoBasico* 0.1* Antiguedad();
        }else
        {
            adicional=sueldoBasico*0.25;
        }
        if (cargo==Cargos.Ingeniero || cargo==Cargos.Especialista)
        {
            adicional*=1.5;
        }
        if (estadoCivil=='C' || estadoCivil=='c')
        {
            adicional += 150000;
        }
        return sueldoBasico +adicional;
     }
    
}
