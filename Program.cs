namespace Prueba
{
    class Program
    {
        
        public DateTime HoraEntrada = DateTime.Now;
        
        static void Main()
        {
            Console.WriteLine("SEXOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO");
            Estacionamiento estacionamiento = new Estacionamiento();
            Semaforo semaforo = new Semaforo();
            Posicion pos = new Posicion();
            string opcion = "";
            do
            {
                semaforo.MostrarSemaforo();
                Console.WriteLine("Estacionamiento - Star Medica");
                Console.WriteLine("Menu \n Introduce uno de los numeros en los corchetes para realizar una accion: \n [1]Resgitrar entrada de un coche \n [2]Registrar salida de un coche \n [3]Mostrar estado del estacionamiento \n [4]Salir del programa");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        if (estacionamiento.capacidadMaxima > 0)
                        {
                            Console.WriteLine("Introduce el codigo de la tarjeta");
                            string codigo = Console.ReadLine();
                            Console.WriteLine("Introduce la marca del auto");
                            string modelo = Console.ReadLine();
                            Console.WriteLine("Introduce las placas del auto");
                            string placas = Console.ReadLine();
                            Console.WriteLine("Introduce el color del auto");
                            string color = Console.ReadLine();
                            DateTime HoraEntrada = DateTime.Now;
                            estacionamiento.RegistrarEntrada(codigo, modelo, placas, color, HoraEntrada);
                        }
                        else
                        {
                            Console.WriteLine("Estacionamiento lleno, no se permite la entrada de más coches.");
                        }
                        break;
                    case "2":
                        if (estacionamiento.contador < estacionamiento.capacidadMaxima)
                        {
                            Console.WriteLine("Introduce el codigo de la tarjeta");
                            string codigoSalida = Console.ReadLine();
                            do
                            {
                                try
                                {
                                    
                                    Console.WriteLine("Introduce la hora y fecha de salida (yyyy-MM-dd HH:mm:ss) (Ejemplo:  2024-02-16 16:32:10 )");
                                    DateTime horaSalida = DateTime.Parse(Console.ReadLine());
                                    estacionamiento.RegistrarSalida(codigoSalida, horaSalida);
                                    break;
                                }
                                catch(System.Exception)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Escribe corretamente el formato");
                                }
                            }while(true);
                        }
                        else
                        {
                            Console.WriteLine("No hay coches dentro del estacionamiento, no es posible realizar un proceso de salida.");
                        }
                        break;
                    case "3":
                        pos.MostrarEstado();
                        break;
                    case "4":
                        Console.WriteLine("Saliendo del programa...");
                        estacionamiento.LimpiarLista();
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                        break;
                }
            } while (opcion != "4");
        }
    }
}