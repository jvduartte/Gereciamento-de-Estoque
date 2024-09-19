using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace SistemaGerenciamentoLogistico
{
    class Program
    {
        static List<Produto> produtos = new List<Produto>();
        static List<Fornecedor> fornecedores = new List<Fornecedor>();
        static List<Transporte> transportes = new List<Transporte>();

        static string caminhoProdutos = @"C:\Users\Aluno Noite\Documents\GerenciamentoEstoque\produtos.json";
        static string caminhoFornecedores = @"C:\Users\Aluno Noite\Documents\GerenciamentoEstoque\fornecedores.json";
        static string caminhoTransportes = @"C:\Users\Aluno Noite\Documents\GerenciamentoEstoque\transportes.json";

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear();

            CarregarDados();

            int opcao;
            do
            {
                Console.Clear();
                ExibirMenuPrincipal();
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        MenuProdutos();
                        break;
                    case 2:
                        MenuFornecedores();
                        break;
                    case 3:
                        MenuTransportes();
                        break;
                    case 4:
                        Relatorio();
                        break;
                    case 0:
                        SalvarDados();
                        Console.WriteLine("\nSaindo do programa...");
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida, tente novamente.");
                        break;
                }
            } while (opcao != 0);
        }

        static void ExibirMenuPrincipal()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            CentralizarTexto("╔═══════════════════════════════════════════════════════╗");
            CentralizarTexto("║                 SISTEMA DE GERENCIAMENTO LOGÍSTICO     ║");
            CentralizarTexto("║                       DE PRODUTOS, FORNECEDORES E     ║");
            CentralizarTexto("║                       TRANSPORTES                       ║");
            CentralizarTexto("╚═══════════════════════════════════════════════════════╝");
            Console.ForegroundColor = ConsoleColor.White;
            CentralizarTexto("║1. Gerenciar Produtos                                  ║");
            CentralizarTexto("║2. Gerenciar Fornecedores                              ║");
            CentralizarTexto("║3. Gerenciar Transportes                               ║");
            CentralizarTexto("║4. relatorio                                           ║");
            CentralizarTexto("║0. Sair                                                ║");
            CentralizarTexto($"║Criador: JVD-LTDA                                     ║");
            CentralizarTexto($"║Versão: 1.0                                           ║");
            CentralizarTexto($"║Data e Hora: {DateTime.Now:dd/MM/yyyy HH:mm}                          ║");
            CentralizarTexto($"║Local: [Insert location here]                         ║");
            Console.ForegroundColor = ConsoleColor.Cyan;
            CentralizarTexto("╚═══════════════════════════════════════════════════════╝");
            Console.ForegroundColor = ConsoleColor.White;
            CentralizarTexto("Escolha uma opção: ");
        }

        static void ExibirMenuProdutos()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            CentralizarTexto("╔═══════════════════════════════════════════════════════╗");
            CentralizarTexto("║                 GERENCIAR PRODUTOS                     ║");
            CentralizarTexto("╚═══════════════════════════════════════════════════════╝");
            Console.ForegroundColor = ConsoleColor.White;
            CentralizarTexto("║1. Adicionar Produto                                  ║");
            CentralizarTexto("║2. Listar Produtos                                    ║");
            CentralizarTexto("║3. Atualizar Produto                                  ║");
            CentralizarTexto("║4. Remover Produto                                    ║");
            CentralizarTexto("║0. Voltar                                            ║");
            CentralizarTexto($"║Data e Hora: {DateTime.Now:dd/MM/yyyy HH:mm}                          ║");
            Console.ForegroundColor = ConsoleColor.Cyan;
            CentralizarTexto("╚═══════════════════════════════════════════════════════╝");
            Console.ForegroundColor = ConsoleColor.White;
            CentralizarTexto("Escolha uma opção: ");
        }

        static void ExibirMenuFornecedores()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            CentralizarTexto("╔═══════════════════════════════════════════════════════╗");
            CentralizarTexto("║                 GERENCIAR FORNECEDORES               ║");
            CentralizarTexto("╚═══════════════════════════════════════════════════════╝");
            Console.ForegroundColor = ConsoleColor.White;
            CentralizarTexto("║1. Adicionar Fornecedor                              ║");
            CentralizarTexto("║2. Listar Fornecedores                                ║");
            CentralizarTexto("║3. Atualizar Fornecedor                               ║");
            CentralizarTexto("║4. Remover Fornecedor                                 ║");
            CentralizarTexto("║0. Voltar                                            ║");
            CentralizarTexto($"║Data e Hora: {DateTime.Now:dd/MM/yyyy HH:mm}                          ║");
            Console.ForegroundColor = ConsoleColor.Cyan;
            CentralizarTexto("╚═══════════════════════════════════════════════════════╝");
            Console.ForegroundColor = ConsoleColor.White;
            CentralizarTexto("Escolha uma opção: ");
        }

        static void ExibirMenuTransportes()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            CentralizarTexto("╔═══════════════════════════════════════════════════════╗");
            CentralizarTexto("║                 GERENCIAR TRANSPORTES                 ║");
            CentralizarTexto("╚═══════════════════════════════════════════════════════╝");
            Console.ForegroundColor = ConsoleColor.White;
            CentralizarTexto("║1. Adicionar Transporte                              ║");
            CentralizarTexto("║2. Listar Transportes                                 ║");
            CentralizarTexto("║3. Atualizar Transporte                               ║");
            CentralizarTexto("║4. Remover Transporte                                 ║");
            CentralizarTexto("║0. Voltar                                            ║");
            CentralizarTexto($"║Data e Hora: {DateTime.Now:dd/MM/yyyy HH:mm}                          ║");
            Console.ForegroundColor = ConsoleColor.Cyan;
            CentralizarTexto("╚═══════════════════════════════════════════════════════╝");
            Console.ForegroundColor = ConsoleColor.White;
            CentralizarTexto("Escolha uma opção: ");
        }

        static void CarregarDados()
        {
            if (File.Exists(caminhoProdutos))
            {
                string json = File.ReadAllText(caminhoProdutos);
                produtos = JsonSerializer.Deserialize<List<Produto>>(json);
            }

            if (File.Exists(caminhoFornecedores))
            {
                string json = File.ReadAllText(caminhoFornecedores);
                fornecedores = JsonSerializer.Deserialize<List<Fornecedor>>(json);
            }

            if (File.Exists(caminhoTransportes))
            {
                string json = File.ReadAllText(caminhoTransportes);
                transportes = JsonSerializer.Deserialize<List<Transporte>>(json);
            }
        }

        static void SalvarDados()
        {
            string jsonProdutos = JsonSerializer.Serialize(produtos);
            File.WriteAllText(caminhoProdutos, jsonProdutos);

            string jsonFornecedores = JsonSerializer.Serialize(fornecedores);
            File.WriteAllText(caminhoFornecedores, jsonFornecedores);

            string jsonTransportes = JsonSerializer.Serialize(transportes);
            File.WriteAllText(caminhoTransportes, jsonTransportes);
        }

        static void MenuProdutos()
        {
            int opcao;
            do
            {
                ExibirMenuProdutos();
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        AdicionarProduto();
                        break;
                    case 2:
                        ListarProdutos();
                        break;
                    case 3:
                        AtualizarProduto();
                        break;
                    case 4:
                        RemoverProduto();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("\nOpção inválida, tente novamente.");
                        break;
                }
            } while (opcao != 0);
        }

        static void MenuFornecedores()
        {
            int opcao;
            do
            {
                ExibirMenuFornecedores();
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        AdicionarFornecedor();
                        break;
                    case 2:
                        ListarFornecedores();
                        break;
                    case 3:
                        AtualizarFornecedor();
                        break;
                    case 4:
                        RemoverFornecedor();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("\nOpção inválida, tente novamente.");
                        break;
                }
            } while (opcao != 0);
        }

        static void MenuTransportes()
        {
            int opcao;
            do
            {
                ExibirMenuTransportes();
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        AdicionarTransporte();
                        break;
                    case 2:
                        ListarTransportes();
                        break;
                    case 3:
                        AtualizarTransporte();
                        break;
                    case 4:
                        RemoverTransporte();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("\nOpção inválida, tente novamente.");
                        break;
                }
            } while (opcao != 0);
        }

        static void AdicionarProduto()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            CentralizarTexto("Adicionar Produto");

            string nome;
            do
            {
                CentralizarTexto("Nome do produto (não pode estar vazio ou conter números): ");
                nome = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(nome) || ContainsNumber(nome));

            decimal preco;
            do
            {
                CentralizarTexto("Preço do produto (deve ser um número): ");
            } while (!decimal.TryParse(Console.ReadLine(), out preco));

            Produto produto = new Produto(nome, preco);
            produtos.Add(produto);
            CentralizarTexto("Produto adicionado com sucesso!");
            Console.ResetColor();
            Console.ReadKey();
        }

        static void AdicionarFornecedor()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            CentralizarTexto("Adicionar Fornecedor");

            string nome;
            do
            {
                CentralizarTexto("Nome do fornecedor (não pode estar vazio ou conter números): ");
                nome = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(nome) || ContainsNumber(nome));

            Fornecedor fornecedor = new Fornecedor(nome);
            fornecedores.Add(fornecedor);
            CentralizarTexto("Fornecedor adicionado com sucesso!");
            Console.ResetColor();
            Console.ReadKey();
        }

        static void AdicionarTransporte()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            CentralizarTexto("Adicionar Transporte");

            string placa;
            do
            {
                CentralizarTexto("Placa do veículo (não pode estar vazia): ");
                placa = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(placa));

            Transporte transporte = new Transporte(placa);
            transportes.Add(transporte);
            CentralizarTexto("Transporte adicionado com sucesso!");
            Console.ResetColor();
            Console.ReadKey();
        }

        static void ListarProdutos()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            CentralizarTexto("Lista de Produtos");
            foreach (var produto in produtos)
            {
                CentralizarTexto($"Nome: {produto.Nome}, Preço: {produto.Preco:C}");
            }
            Console.ResetColor();
            Console.ReadKey();
        }

        static void ListarFornecedores()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            CentralizarTexto("Lista de Fornecedores");
            foreach (var fornecedor in fornecedores)
            {
                CentralizarTexto($"Nome: {fornecedor.Nome}");
            }
            Console.ResetColor();
            Console.ReadKey();
        }

        static void ListarTransportes()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            CentralizarTexto("Lista de Transportes");
            foreach (var transporte in transportes)
            {
                CentralizarTexto($"Placa: {transporte.Placa}");
            }
            Console.ResetColor();
            Console.ReadKey();
        }

        static void AtualizarProduto()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            CentralizarTexto("Atualizar Produto");
            ListarProdutos();
            // Implementar lógica para atualizar produto
        }

        static void AtualizarFornecedor()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            CentralizarTexto("Atualizar Fornecedor");
            ListarFornecedores();
            // Implementar lógica para atualizar fornecedor
        }

        static void AtualizarTransporte()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            CentralizarTexto("Atualizar Transporte");
            ListarTransportes();
            // Implementar lógica para atualizar transporte
        }

        static void RemoverProduto()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            CentralizarTexto("Remover Produto");
            ListarProdutos();

            Console.WriteLine("Digite o nome do produto que deseja remover:");
            string nomeProduto = Console.ReadLine();

            var produto = produtos.Find(p => p.Nome.Equals(nomeProduto, StringComparison.OrdinalIgnoreCase));
            if (produto != null)
            {
                produtos.Remove(produto);
                CentralizarTexto("Produto removido com sucesso!");
            }
            else
            {
                CentralizarTexto("Produto não encontrado!");
            }
            Console.ResetColor();
            Console.ReadKey();
        }

        static void RemoverFornecedor()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            CentralizarTexto("Remover Fornecedor");
            ListarFornecedores();

            Console.WriteLine("Digite o nome do fornecedor que deseja remover:");
            string nomeFornecedor = Console.ReadLine();

            var fornecedor = fornecedores.Find(f => f.Nome.Equals(nomeFornecedor, StringComparison.OrdinalIgnoreCase));
            if (fornecedor != null)
            {
                fornecedores.Remove(fornecedor);
                CentralizarTexto("Fornecedor removido com sucesso!");
            }
            else
            {
                CentralizarTexto("Fornecedor não encontrado!");
            }
            Console.ResetColor();
            Console.ReadKey();
        }

        static void RemoverTransporte()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            CentralizarTexto("Remover Transporte");
            ListarTransportes();

            Console.WriteLine("Digite a placa do transporte que deseja remover:");
            string placaTransporte = Console.ReadLine();

            var transporte = transportes.Find(t => t.Placa.Equals(placaTransporte, StringComparison.OrdinalIgnoreCase));
            if (transporte != null)
            {
                transportes.Remove(transporte);
                CentralizarTexto("Transporte removido com sucesso!");
            }
            else
            {
                CentralizarTexto("Transporte não encontrado!");
            }
            Console.ResetColor();
            Console.ReadKey();
        }

        static bool ContainsNumber(string input)
        {
            foreach (char c in input)
            {
                if (char.IsDigit(c))
                    return true;
            }
            return false;
        }

        static void CentralizarTexto(string texto)
        {
            int posicao = (Console.WindowWidth / 2) - (texto.Length / 2);
            Console.SetCursorPosition(posicao, Console.CursorTop);
            Console.WriteLine(texto);
        }

        static void Relatorio()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            CentralizarTexto("╔═══════════════════════════════════════════════════════╗");
            CentralizarTexto("║                       RELATÓRIO                        ║");
            CentralizarTexto("╚═══════════════════════════════════════════════════════╝");

            // Relatório de Produtos
            CentralizarTexto("Lista de Produtos");
            if (produtos.Count == 0)
            {
                CentralizarTexto("Nenhum produto cadastrado.");
            }
            else
            {
                foreach (var produto in produtos)
                {
                    CentralizarTexto($"Nome: {produto.Nome}, Preço: {produto.Preco:C}");
                }
            }

            Console.WriteLine(); // Espaço

            // Relatório de Fornecedores
            CentralizarTexto("Lista de Fornecedores");
            if (fornecedores.Count == 0)
            {
                CentralizarTexto("Nenhum fornecedor cadastrado.");
            }
            else
            {
                foreach (var fornecedor in fornecedores)
                {
                    CentralizarTexto($"Nome: {fornecedor.Nome}");
                }
            }

            Console.WriteLine(); // Espaço

            // Relatório de Transportes
            CentralizarTexto("Lista de Transportes");
            if (transportes.Count == 0)
            {
                CentralizarTexto("Nenhum transporte cadastrado.");
            }
            else
            {
                foreach (var transporte in transportes)
                {
                    CentralizarTexto($"Placa: {transporte.Placa}");
                }
            }

            Console.ResetColor();
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
            Console.ReadKey();
        }
    }
   


    public class Produto
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        public Produto(string nome, decimal preco)
        {
            Nome = nome;
            Preco = preco;
        }
    }

    public class Fornecedor
    {
        public string Nome { get; set; }

        public Fornecedor(string nome)
        {
            Nome = nome;
        }
    }

    public class Transporte
    {
        public string Placa { get; set; }

        public Transporte(string placa)
        {
            Placa = placa;
        }
    }
}
