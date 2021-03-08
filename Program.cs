using System;
using System.Collections.Generic;
using System.Linq;

namespace TheBank
{
    class Program
    {
        static List<Option_Admin> listContasAdmin = new List<Option_Admin>();
        static List<Option_Client> listContasClient = new List<Option_Client>();

        static void Main(string[] args)
        {
            listContasAdmin.Add( new Option_Admin("Admin", "123"));//Usuario cadastrado para ser usado com admin - Indice 0

            Console.WriteLine(listContasClient.Count());

            int opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario != 3)
            {
                switch (opcaoUsuario)
                {
                    case 1:
                        PainelAdminstrativo();
                        break;
                    case 2:
                        PainelCorrentista();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Valor não confere\nFavor verificar");
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por usar nosso sistema\nVolte Sempre");
            Console.ReadLine();
        }
        //Menus: geral - cliente - administrador
        private static int ObterOpcaoUsuario(){
            Console.WriteLine("*******************************************");

            Console.WriteLine("Bem vindo ao THE BANK\n");
            Console.WriteLine("Escolha uma opção abaixo:");
            Console.WriteLine("1 - Administrador");
            Console.WriteLine("2 - Correntista");
            Console.WriteLine("3 - Sair");

            int opcaoUsuario = int.Parse(Console.ReadLine());
            Console.WriteLine("*******************************************");

            Console.WriteLine();
            return opcaoUsuario;
        }
        private static int MenuCliente()
        {
            Console.WriteLine();
            Console.WriteLine("Escolha uma opção abaixo:");
            Console.WriteLine("1 - Consultar conta");
            Console.WriteLine("2 - Sacar");
            Console.WriteLine("3 - Depositar");
            Console.WriteLine("4 - Sair");

            int opc = int.Parse(Console.ReadLine());

            return opc;
        }
        private static int MenuAdministrador()
        {
            Console.WriteLine();
            Console.WriteLine("Escolha uma opção abaixo:");
            Console.WriteLine("1 - Consultar administrador");
            Console.WriteLine("2 - Cadastrar administrador");
            Console.WriteLine("3 - Remover administrador");
            Console.WriteLine("4 - Cadastrar correntista");
            Console.WriteLine("5 - Consultar correntistas");
            Console.WriteLine("6 - Remover correntista");
            Console.WriteLine("7 - Sair");

            Console.WriteLine();

            int opcao = int.Parse(Console.ReadLine());

            return opcao;
        }
        //Metodos operacionais
        public static int PainelAdminstrativo()
        {
            Console.Write("Informe seu ID:\t\t");
            int id = int.Parse(Console.ReadLine());

            int opcao = 0;

            if ((id >= 0) && (id < listContasAdmin.Count()))
            {
                opcao = MenuAdministrador();   
            }
            else
            {
                Console.WriteLine("Não existe esta conta cadastrada!");
                opcao = 7;
            }

            while (opcao != 7)
            {
                switch (opcao)
                {
                    case 1:
                        ListarContasAdmin();
                        break;
                    case 2:
                        Console.Write("Informe o nome:\t\t");
                        string nomeCadastrar = Console.ReadLine();

                        Console.Write("Informe a senha:\t");
                        string senha = Console.ReadLine();

                        listContasAdmin.Add(new Option_Admin(nomeCadastrar, senha));
                        break;
                    case 3:
                        Console.Write("ID para remoção:\t");
                        int idRemover = int.Parse(Console.ReadLine());

                        listContasAdmin.RemoveAt(idRemover);
                        break;
                    case 4:
                        Console.Write("Nome do correntista:\t");
                        string nome = Console.ReadLine();

                        Console.Write("Informe o saldo:\t");
                        double saldo = double.Parse(Console.ReadLine());

                        listContasClient.Add(new Option_Client(saldo, nome));                        
                        break;
                    case 5:
                        ListarContasCliente();
                        break;
                    case 6:
                        Console.Write("ID para remoção:\t");
                        int idRemoverCliente = int.Parse(Console.ReadLine());

                        listContasClient.RemoveAt(idRemoverCliente);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                    }

                opcao = MenuAdministrador();

            }
                return opcao;    
        }
        private static int PainelCorrentista()
        {
            Console.Write("Informe seu ID:\t\t");
            int id = int.Parse(Console.ReadLine());

            int opcao = 0;

            if ((id >= 0) && (id < listContasClient.Count()))
            {
                opcao = MenuCliente();   
            }
            else
            {
                Console.WriteLine("Não existe esta conta cadastrada!");
                opcao = 4;
            }

            while (opcao != 4)
            {
                switch (opcao)
                {
                    case 1:
                        listContasClient[id].Consultar();
                        break;
                    case 2:
                        Console.Write("Valor do saque:\t\t");
                        double valorSaque = double.Parse(Console.ReadLine());

                        listContasClient[id].Sacar(valorSaque);
                        break;
                    case 3:
                        Console.Write("Valor do deposito:\t");
                        double valorDeposito = double.Parse(Console.ReadLine());

                        listContasClient[id].Depositar(valorDeposito);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcao = MenuCliente(); 
            }
            return opcao;
        }
        private static void ListarContasAdmin()
        {
            for (int i = 0; i < listContasAdmin.Count; i++)
            {
                Option_Admin option_admin = listContasAdmin[i];
                Console.Write("# {0} - ", i);
                Console.WriteLine(option_admin);
            }
        }
        private static void ListarContasCliente()
        {
            for (int i = 0; i < listContasClient.Count; i++)
            {
                Option_Client option_client = listContasClient[i];
                Console.Write("# {0} - ", i);
                Console.WriteLine(option_client);   
            }
        }
    }
}