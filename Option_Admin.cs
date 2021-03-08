using System;

namespace TheBank
{
    public class Option_Admin
    {
        private string Nome {get; set;}
        private string Senha {get; set;}

        public Option_Admin(string nome, string senha)
        {
            this.Nome = nome;
            this.Senha = senha;
            
        }
        public int Consultar(int id)
        {
            Console.Write("Informe seu ID:\t\t");
            id = int.Parse(Console.ReadLine());

            Console.WriteLine("Dados cadastrados:\nNome:\t{0}"+ this.Nome);

            return id;
        }
        public void Cadastrar(string nome, string senha)
        {
            this.Nome = nome;
            this.Senha = senha;

            Console.WriteLine("Cadastro realizado:\nNome:\t{0}\nSenha:\t{1}", this.Nome, this.Senha);
        }
        public void Remover(int id)
        {
            Console.WriteLine("Informe o ID para ser removido:");
            id = int.Parse(Console.ReadLine());

            Remover(id);
        }
        //subscrever construtor option_admin
        public override string ToString()
        {
            string retorno = "";
            retorno += "Nome: " + this.Nome + " | ";
            retorno += "Senha: " + this.Senha;

            return retorno;
        }

    }
}