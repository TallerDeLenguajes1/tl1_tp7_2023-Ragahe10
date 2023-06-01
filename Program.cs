using escpacioCalculadora;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
// calculadora

Calculadora valor = new Calculadora();// NO OLVIDAR INICIALIZAR CON EL CONSTRUCTOR
int resp = 1, op;
bool result;
double num;
while(resp==1){
    Console.WriteLine("--------CALCULADORA--------");
    Console.WriteLine("VALOR: "+valor.Resultado);
    Console.WriteLine("OPERACIONES:");
    Console.WriteLine("  ~ SUMAR........(1)");
    Console.WriteLine("  ~ RESTAR.......(2)");
    Console.WriteLine("  ~ MULTIPLICAR..(3)");
    Console.WriteLine("  ~ DIVIDIR......(4)");
    Console.WriteLine("  ~ LIMPIAR......(5)");
    Console.WriteLine("Seleccione operación: ");
    result = int.TryParse(Console.ReadLine(), out op);
    if(result && (op>0 && op<6)){
        if(op!=5){
            Console.WriteLine("Ingrese un nùmero: ");
            if(double.TryParse(Console.ReadLine(),out num)){
                switch (op){
                    case 1: 
                        valor.Sumar(num);
                        Console.WriteLine("La suma es: "+ valor.Resultado);
                        break;
                    case 2: 
                        valor.Restar(num);
                        Console.WriteLine("La resta es: "+ valor.Resultado);
                        break;
                    case 3: 
                        valor.Multiplicar(num);
                        Console.WriteLine("La multiplicación es: "+ valor.Resultado);
                        break;
                    case 4: 
                        valor.Dividir(num);
                        Console.WriteLine("La división es: "+ valor.Resultado);
                        break;
                }
            }else{
                Console.WriteLine("No es número");
            }
        }else{
            valor.Limpiar();
        }
    }else{
        Console.WriteLine("No es una operación válida");
    }
    Console.WriteLine("Desea seguir operando?(SI:1/NO:0)");
    if(!(int.TryParse(Console.ReadLine(),out resp))){
        resp = 0;
    }
}