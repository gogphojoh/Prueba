namespace Prueba
{
    class Posicon{}
    public class Posicion
    {
        Estacionamiento estacionamiento = new Estacionamiento();
        public void MostrarEstado()
        {
            Console.WriteLine($"Hay {estacionamiento.capacidadMaxima - estacionamiento.contador} lugares libres");

        }
    }
}