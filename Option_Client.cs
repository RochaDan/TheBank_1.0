using System;
using System.Globalization;

namespace TheBank
{
    public class Option_Client
    {
        private double Saldo {get; set;} 
        private string Nome {get; set;}

        public Option_Client(double saldo, string nome)
        {
            this.Saldo = saldo;
            this.Nome = nome;
        }
        public void Cadastrar(string nome, double saldo)
        {
            this.Nome = nome;
            this.Saldo = saldo;
        }
        public void Consultar()
        {
            Console.WriteLine("Dados da conta:\n Cliente: {0}\n Saldo: {1}", this.Nome, this.Saldo.ToString("C", CultureInfo.CurrentCulture));
        }
        public void Sacar(double valorSaque)
        {
            if (valorSaque <= 0)
            {
                Console.WriteLine("Valores negativos não são permitidos\nFavor corrigir");
                return;
            }
            else if ((this.Saldo <= 0) || (this.Saldo < valorSaque))
            {
                Console.WriteLine("Saldo insuficiente");
                return;
            }
            else
            {
                this.Saldo = this.Saldo - valorSaque;
                Console.WriteLine("Saldo atualizado:\n Cliente: {0}\n Saldo: {1}", this.Nome, this.Saldo.ToString("C", CultureInfo.CurrentCulture));
            }
        }
        public void Depositar(double valorDeposito)
        {
            if (valorDeposito > 0)
            {
                this.Saldo += valorDeposito;
                Console.WriteLine("Saldo atualizado:\n Cliente: {0}\n Saldo: {1}", this.Nome, this.Saldo.ToString("C", CultureInfo.CurrentCulture));
            }
            else
            {
                Console.WriteLine("Valor de deposito inconsistente\nInforme outro valor");
            }
        }
        //sobrescrever o construtor
        public override string ToString()
        {
            string retorno = "";

            retorno += "Nome: " + this.Nome + " | ";
            retorno += "Saldo: " + this.Saldo;
            
            return retorno;
        }
    }
}