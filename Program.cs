using System;
//lib pra trabalhar com list
using System.Collections.Generic;

namespace CaixaEletronico_ÉrikFerreira
{
    class Program
    {
        static void Main(string[] args)
        {
            //mensagem de inicio
            Console.WriteLine("\nOlá usuário, digite seu nome para iniciar seu atendimento ao caixa!\n");
            //variavel que coleta o nome do usuario
            string nomeUsuario = Console.ReadLine();
            //variavel para controlar o while
            bool sair = false;
            //variavel de saldo
            Double saldo = 0;
            //variavel para recever o tipo de operação e jogar na lista
            string operacao;
            //lista com extrato
            List<string> Extrato = new List<string>();
            Extrato.Add("\nUsuário: " + nomeUsuario + "\n\nOperação |  Data  | Horário | Valor |\n");
            
            //inicio do programa
            while(sair == false) {
                Console.Clear();
                
                //mensagens de opções
                Console.WriteLine(nomeUsuario + " seja bem vindo ao caixa eletrônico - Banco do Brasil\n");
                Console.WriteLine("O que gostaria de fazer?");
                Console.WriteLine("Tecle 1 - Consultar Saldo");
                Console.WriteLine("Tecle 2 - Sacar");
                Console.WriteLine("Tecle 3 - Depositar");
                Console.WriteLine("Tecle 4 - Extrato");
                Console.WriteLine("Tecle 5 - Sair\n");
                //passo a oção para int
                int opcaoUsuario = Int32.Parse(Console.ReadLine());

                if(opcaoUsuario == 1) {
                    Console.Clear();
                    //passa o saldo para modelo currency
                    string saldoMoeda = saldo.ToString("C");
                    //pega a hora e a data da operação
                    DateTime horaConsulta = DateTime.Now;
                    //atribui a operação certa
                    operacao = "Consulta";
                    //joga os valores certos pro extrato
                    Extrato.Add(operacao + " " + horaConsulta + " " + saldoMoeda);
                    //mostra o saldo atual
                    Console.WriteLine("O seu saldo atual é " + saldoMoeda + "\n");
                    //procedimento que mostra a mensagem com opção se o usuário quer fazer outra coisa ou sair
                    sair = verificaOutraOP(sair);
                }
                else if(opcaoUsuario == 2) {
                    //coleta o valor do saque
                    Console.WriteLine("\nDigite o valor que gostaria de sacar:\n");
                    //recebe o valor conventendo pra double
                    string saque = Console.ReadLine();
                    //troca "." por "," caso o usuario use ".", a função de currency funciona corretamente com virgula, caso o usuario use ponto ela adiciona casaas decimais na conversão
                    saque = saque.Replace('.',',');
                    //após tratar o ponto, ocorre a conversão para modelo currency
                    double saqueDouble = float.Parse(saque);

                    Console.Clear();
                    //verifica se a pessoa tem saldo
                    if(saqueDouble > saldo) {
                        Console.WriteLine("Saldo Insuficiente...\n");
                        sair = verificaOutraOP(sair);
                    } 
                    else {
                        //saldo é igual a ele - o valor sacado atualmente
                        saldo = saldo - saqueDouble;
                        //deposito na versão currency
                        string saqueMoeda = saqueDouble.ToString("C"); 
                        //pega a hora e a data da operação
                        DateTime horaConsulta = DateTime.Now;
                        //atribui a operação certa
                        operacao = "Saque   ";
                        //joga os valores certos pro extrato
                        Extrato.Add(operacao + " " + horaConsulta + " " + saqueMoeda);

                        Console.Clear();
                        Console.WriteLine(saqueMoeda + " sacado com sucesso!\n");
                        sair = verificaOutraOP(sair);
                    }
                } 
                else if(opcaoUsuario == 3) {
                    //coleta o valor do deposito
                    Console.WriteLine("\nDigite o valor que gostaria de depositar:\n");
                    //recebe o valor conventendo pra double
                    string deposito = Console.ReadLine();
                    //troca "." por "," caso o usuario use ".", a função de currency funciona corretamente com virgula, caso o usuario use ponto ela adiciona casaas decimais na conversão
                    deposito = deposito.Replace('.',',');
                    //após tratar o ponto, ocorre a conversão para modelo currency
                    double depositoDouble = float.Parse(deposito);
                    //saldo é igual a ele + o valor depositado atualmente
                    saldo = saldo + depositoDouble;
                    //deposito na versão currency
                    string depositoMoeda = depositoDouble.ToString("C"); 
                    //pega a hora e a data da operação
                    DateTime horaConsulta = DateTime.Now;
                    //atribui a operação certa
                    operacao = "Deposito";
                    //joga os valores certos pro extrato
                    Extrato.Add(operacao + " " + horaConsulta + " " + depositoMoeda);

                    Console.Clear();
                    Console.WriteLine(depositoMoeda + " depositado com sucesso!\n");
                    sair = verificaOutraOP(sair);
                } 
                else if(opcaoUsuario == 4) {
                    //foreach que mostra a lista
                    foreach (string item in Extrato)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine("\n");
                    sair = verificaOutraOP(sair);
                } 
                else if(opcaoUsuario == 5) {
                    Console.Clear();
                    //verifica se o usuario quer mesmos sair
                    Console.WriteLine("Tem certeza que deseja sair? Digite sim ou não:");
                    String decisao = Console.ReadLine();

                    //deixa a decisao do usuario em letra maiuscula para verificar
                    if(decisao.ToUpper() == "SIM"){
                        sair = true;
                        Console.Clear();
                    }
                } 
                else {
                    Console.WriteLine("Digite um Número válido");
                    opcaoUsuario = Int32.Parse(Console.ReadLine());
                }
            }
        }

        static bool verificaOutraOP (bool sair) {
            
            Console.WriteLine("Gostaria de realizar outra operação? (tecle 1) Ou gostaria de sair? (tecle 5):\n");
            int decisao = Int32.Parse(Console.ReadLine());

            if(decisao == 5){
                Console.Clear();
                    Console.WriteLine("Tem certeza que deseja sair? Digite sim ou não:");
                    String dec = Console.ReadLine();

                    if(dec.ToUpper() == "SIM"){
                        Console.Clear();
                        return sair = true;
                    }
                    else{
                        return sair = false;
                    }
            }
            else {
                return sair = false;
            }
        }
    }
}