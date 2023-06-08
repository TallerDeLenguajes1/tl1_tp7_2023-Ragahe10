namespace espacioEmpleado;
public enum cargos{
        Auxiliar,
        Administrativo, 
        Ingeniero,
        Especialista,
        Investigado
    }
public class Empleado{
    //ATRIBUTOS
    private string? nombre;
    private string? apellido;
    private DateTime fechaNac;
    private char estadoCivil;
    private char genero;
    private DateTime fechaIngreso;
    private double sueldoBasico;
    public cargos cargo;
    //ATRIBUTOS
    //PROPIEDADES
    public string? Nombre { get => nombre; set => nombre = value; }
    public string? Apellido { get => apellido; set => apellido = value; }
    public DateTime FechaNac { get => fechaNac; set => fechaNac = value; }
    public char EstadoCivil { get => estadoCivil; set => estadoCivil = value; }
    public char Genero { get => genero; set => genero = value; }
    public DateTime FechaIngreso { get => fechaIngreso; set => fechaIngreso = value; }
    public double SueldoBasico { get => sueldoBasico; set => sueldoBasico = value; }
    //PROPIEDADES
    //EMPLEADO
    public Empleado(string n, string a, DateTime fn, char ec, char g, DateTime fi, double s, cargos c){
        Nombre = n;
        Apellido = a;
        FechaNac = fn;
        EstadoCivil = ec;
        Genero = g;
        FechaIngreso = fi;
        SueldoBasico = s;
        cargo = c;
    }
    //EMPLEADO
    //METODOS

    public int Antiguedad() {
        TimeSpan duracion = DateTime.Today - FechaIngreso;
        int antiguedad = (int)duracion.TotalDays / 365;
        return antiguedad;
    }
    public int EdadEmpleado(){
        TimeSpan duracion = DateTime.Today - FechaNac;
        int edad = (int)duracion.TotalDays/365;
        return edad;
    }
    public int AñosParaJubilacion(){
        int años;
        if(Genero == 'M'){
            años = 60 - EdadEmpleado();
        }else{
            años = 65 - EdadEmpleado();
        }
        if(años <= 0){
            return 0;
        }else{
            return años;
        }
    }

    public double Salario(){
        double adicional;
        int porc = Antiguedad();
        if(porc >= 20){
           porc = 25;
        }
        adicional = (SueldoBasico*porc)/100;
        if(cargo == cargos.Ingeniero || cargo == cargos.Especialista){
            adicional += adicional*0.5;
        }
        if(EstadoCivil == 'C'){
            adicional += 15000;
        }
        return(sueldoBasico + adicional);
    }
    public void MostrarEmpleado(){
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine("NOMBRE: "+Nombre);
        Console.WriteLine("APELLIDO: "+Apellido);
        Console.WriteLine("FECHA DE NNACIMIENTO: "+FechaNac);
        Console.WriteLine("EDAD: "+EdadEmpleado());
        Console.WriteLine("ESTADO CIVIL: "+EstadoCivil);
        Console.WriteLine("GENERO: "+Genero);
        Console.WriteLine("FECHA DE INGRESO: "+FechaIngreso);
        Console.WriteLine("ANTIGUEDAD: "+Antiguedad());
        Console.WriteLine("AÑOS PARA JUBILARSE: "+AñosParaJubilacion());
        Console.WriteLine("SUELDO BASICO: $"+SueldoBasico);
        Console.WriteLine("SUELDO NETO: $"+Salario());
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
    }
    //METODOS
}