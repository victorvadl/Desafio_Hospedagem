using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Hotel.Models
{
  public class Reserva
  {
    public List<Pessoa> Hospedes { get; set; }
    public Suite Suite { get; set; }
    public int DiasReservados { get; set; }

    public Reserva() { }

    public Reserva(int diasReservados)
    {
      DiasReservados = diasReservados;
    }

    public void CadastrarHospedes(List<Pessoa> hospedes)
    {
      if (hospedes.Count <= Suite.Capacidade)
      {
        Hospedes = hospedes;
      }
      else
      {
        throw new Exception($"\nA capacidade para a suite escolhida é de: {Suite.Capacidade} hospedes. \nInfelizmente não é possível cadastras todos os hóspedes nessa suite.");
      }
    }

    public void CadastrarSuite(Suite suite)
    {
      Suite = suite;
    }

    public int ObterQuantidadeHospedes()
    {
      return Hospedes.Count;
    }

    public decimal CalcularValorDiaria()
    {
      decimal valor = 0;
      valor = DiasReservados * Suite.ValorDiaria;

      if (DiasReservados >= 10)
      {
        valor = valor * 0.9M;
      }

      return valor;
    }
  }
}