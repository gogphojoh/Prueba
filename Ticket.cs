using System;
using System.Collections.Generic;

namespace Prueba
{

    public class Ticket
    {
        public Tarjeta Tarjeta { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraSalida { get; set; }

        public Ticket(Tarjeta tarjeta, DateTime horaEntrada)
        {
            Tarjeta = tarjeta;
            HoraEntrada = horaEntrada;
        }

        public void RegistrarSalida(DateTime horaSalida)
        {
            HoraSalida = horaSalida;
        }

        public double CalcularPrecio()
        {
            TimeSpan tiempoEstacionado = HoraEntrada - HoraSalida;
            int horas = tiempoEstacionado.Hours + 1; // Redondea hacia arriba
            double precioPorHora = 30;

            // Si la salida es en un día diferente al de entrada, se cobran 24 horas completas
            if (HoraSalida.Date > HoraEntrada.Date)
            {
                horas = 24;
            }

            // Si la salida es en un año diferente al de entrada, se cobran 24 horas completas por cada día
            if (HoraSalida.Year > HoraEntrada.Year)
            {
                horas = 24 * (int)(HoraSalida.Date - HoraEntrada.Date).TotalDays;
            }

            double precioTotal = horas * precioPorHora;
            return precioTotal;
        }
    }
}