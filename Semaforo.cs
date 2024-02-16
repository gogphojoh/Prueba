namespace Prueba
{
    public class Semaforo
    {
        Estacionamiento estacionamiento = new Estacionamiento();
        public void MostrarSemaforo()
        {
            if (estacionamiento.capacidadMaxima > estacionamiento.contador)
            {
                Console.WriteLine("Semaforo: Verde - Hay lugares disponibles.");
            }
            else
            {
                Console.WriteLine("Semaforo: Rojo - Estacionamiento lleno.");
            }
        }
    }
}
