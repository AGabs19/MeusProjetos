using VendasApp.Models.Enums;
using System.Collections.Generic;

namespace VendasApp.Models
{
    public class RegistroDeVenda
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public double Quantia { get; set; }
        public VendasStatus Status { get; set; }
        public Vendedor Vendedor { get; set; } //Ligação de 1 para 1

        public RegistroDeVenda()
        {

        }
        public RegistroDeVenda(int id, DateTime data, double quantia, VendasStatus status,Vendedor vendedor) //Como a liggação não é uma coleção, eu coloco ela aqui! 
        {
            Id = id;
            Data = data;
            Quantia = quantia;
            Status = status;
            Vendedor = vendedor;
        }
    }
}
