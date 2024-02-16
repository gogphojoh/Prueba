using System.Diagnostics.Contracts;

namespace Prueba
{
   public class Estacionamiento
    {
        Program ob = new Program();
        public List<Tarjeta> tarjetasRegistradas;
        public List<Ticket> tickets;
        public List<int> posicionesOcupadas;
        public int contador = 0;
        public int capacidadMaxima = 400;
        
        public Estacionamiento()
        {
            tarjetasRegistradas = new List<Tarjeta>();
            tickets = new List<Ticket>();
            posicionesOcupadas = new List<int>();
        }

        public void RegistrarEntrada(string codigo, string marca, string placas, string color, DateTime horaEntrada)
        {
            Tarjeta tarjeta = new Tarjeta(codigo, marca, placas, color);
            if (tarjetasRegistradas.Exists(t => t.Codigo == codigo))
            {
                Console.WriteLine("La tarjeta ya está registrada");
                return;
            }
            if (tarjetasRegistradas.Exists(t => t.Placas == placas))
            {
                Console.WriteLine("Esas placas ya están registradas");
                return;
            }
            tarjetasRegistradas.Add(tarjeta);
            Random rnd = new Random();
            int posicion = rnd.Next(1, capacidadMaxima + 1);
            Console.WriteLine($"La barrera se ha levantado. Pasa al estacionamiento");
            contador ++;
            ob.HoraEntrada = DateTime.Now;
            Console.WriteLine("La hora de entrada es: " + ob.HoraEntrada);
        }

        public void RegistrarSalida(string codigo, DateTime horaSalida)
        {
            Tarjeta tarjeta = tarjetasRegistradas.Find(t => t.Codigo == codigo);
            if (tarjeta != null)
            {
                Ticket ticket = new Ticket(tarjeta, ob.HoraEntrada);
                ticket.RegistrarSalida(horaSalida);
                if(horaSalida > ob.HoraEntrada)
                {
                tickets.Add(ticket);
                tarjetasRegistradas.Remove(tarjeta);
                posicionesOcupadas.Remove(posicionesOcupadas.Find(p => p == int.Parse(codigo))); // Suponiendo que el código de la tarjeta se usa como posición
                Console.WriteLine($"*********************************************** \n Ticket: \n Fecha y hora de entrada: {ticket.HoraEntrada} \n Fecha y hora de salida: {ticket.HoraSalida} \n Precio: ${ticket.CalcularPrecio():F2} \n Marca: {tarjeta.Marca} \n Placas: {tarjeta.Placas} \n Color: {tarjeta.Color} \n ***********************************************");
                contador --;
                }
                else 
                {
                    Console.WriteLine("No es posible calcular una fecha de salida anterior a la de entrada");
                }
            }
            else
            {
                Console.WriteLine("La tarjeta no está registrada en el sistema.");
            }
        }

        public void LimpiarLista()
        {
            tarjetasRegistradas.Clear();
        }
    }
}