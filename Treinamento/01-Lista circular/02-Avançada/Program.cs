using System;
using System.Collections;
using System.Collections.Generic;

namespace List
{
    class Program
    {
        static void Main()
        {
            List.DoubleCircularList<object> mylist = new List.DoubleCircularList<object>();
            string[] options = { "0.Exit", "1.List", "2.Add", "3.Remove", "4.Clear", "5.Insert", "6.RemoveAt", "7.IndexOf", "8.Contains", "9.Get/Set Index" };
            int select = 0;
            Console.CursorVisible = false;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Selecione a função que você quer, use as setas cima/baixo e dê enter\n");
                for (int i = 0; i < options.Length; i++)
                {
                    if (i == select)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.WriteLine($"> {options[i]}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"  {options[i]}");
                    }
                }
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    select--;
                    if (select < 0)
                    {
                        select = options.Length - 1;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    select++;
                    if (select >= options.Length)
                    {
                        select = 0;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    switch (select)
                    {
                        case 0:
                            Console.WriteLine("Pressione <Enter> para confirmar");
                            break;

                        case 1:
                            mylist.List();
                            Console.WriteLine("Pressione <Enter> para sair");
                            Console.ReadKey();
                            continue;
                        case 2:
                            Console.WriteLine("Digite:");
                            string? entry = Console.ReadLine();
                            while (string.IsNullOrWhiteSpace(entry))
                            {
                                Console.WriteLine("Entrada invalida, Digite qualquer coisa:");
                                entry = Console.ReadLine();
                            }
                            mylist.Add(entry!);
                            Console.WriteLine("Pressione <Enter> para confirmar");
                            Console.ReadKey();
                            continue;
                        case 3:
                            Console.WriteLine("Digite o objeto a ser deletado:");
                            string? delete = Console.ReadLine();
                            while (string.IsNullOrWhiteSpace(delete))
                            {
                                Console.WriteLine("Entrada invalida, Digite uma entrada valida:");
                                delete = Console.ReadLine();
                            }
                            Console.WriteLine("Pressione <Enter> para confirmar");
                            Console.ReadKey();
                            if (mylist.Remove(delete!))
                            {
                                Console.WriteLine("Objeto deletado com sucesso!");
                            } else
                            {
                                Console.WriteLine("Objeto não encontrado!");
                            }
                            Console.ReadKey();
                            continue;
                        case 4:
                            mylist.Clear();
                            Console.WriteLine("Lista esvaziada, Aperte <Enter> para sair");
                            Console.ReadKey();
                            continue;
                        case 5:
                            Console.WriteLine("Digite o índice onde deseja inserir:");
                            int insertIndex;
                            while (!int.TryParse(Console.ReadLine(), out insertIndex) || insertIndex < 0)
                            {
                                Console.WriteLine("Índice inválido, digite um número inteiro >= 0:");
                            }
                            Console.WriteLine("Digite o valor a ser inserido:");
                            string? insertValue = Console.ReadLine();
                            while (string.IsNullOrWhiteSpace(insertValue))
                            {
                                Console.WriteLine("Entrada inválida, digite um valor válido:");
                                insertValue = Console.ReadLine();
                            }
                            mylist.Insert(insertIndex, insertValue!);
                            Console.WriteLine("Objeto inserido! Pressione <Enter> para sair");
                            Console.ReadKey();
                            continue;
                        case 6:
                            if (mylist.Count == 0)
                            {
                                Console.WriteLine("A lista está vazia! Pressione <Enter> para sair");
                                Console.ReadKey();
                                continue;
                            }
                            Console.WriteLine($"Digite o índice a ser removido (0 até {mylist.Count - 1}):");
                            int removeIndex;
                            while (!int.TryParse(Console.ReadLine(), out removeIndex) || removeIndex < 0 || removeIndex >= mylist.Count)
                            {
                                Console.WriteLine($"Índice inválido! Digite um número entre 0 e {mylist.Count - 1}:");
                            }
                            mylist.RemoveAt(removeIndex);
                            Console.WriteLine("Pressione <Enter> para sair");
                            Console.ReadKey();
                            continue;
                        case 7:
                            Console.WriteLine("Digite o valor para buscar o índice:");
                            string? searchValue = Console.ReadLine();
                            while (string.IsNullOrWhiteSpace(searchValue))
                            {
                                Console.WriteLine("Entrada inválida, digite um valor válido:");
                                searchValue = Console.ReadLine();
                            }
                            int foundIndex = mylist.IndexOf(searchValue!);
                            if (foundIndex != -1)
                            {
                                Console.WriteLine($"O objeto \"{searchValue}\" está no índice: {foundIndex}");
                            }
                            else
                            {
                                Console.WriteLine($"O objeto \"{searchValue}\" não foi encontrado (-1)!");
                            }
                            Console.WriteLine("Pressione <Enter> para sair");
                            Console.ReadKey();
                            continue;
                        case 8:
                            Console.WriteLine("Digite o valor para verificar se existe na lista:");
                            string? containsValue = Console.ReadLine();
                            while (string.IsNullOrWhiteSpace(containsValue))
                            {
                                Console.WriteLine("Entrada inválida, digite um valor válido:");
                                containsValue = Console.ReadLine();
                            }
                            if (mylist.Contains(containsValue!))
                            {
                                Console.WriteLine($"Sim! O objeto \"{containsValue}\" existe na lista.");
                            }
                            else
                            {
                                Console.WriteLine($"Não! O objeto \"{containsValue}\" não está na lista.");
                            }
                            Console.WriteLine("Pressione <Enter> para sair");
                            Console.ReadKey();
                            continue;
                        case 9:
                            if (mylist.Count == 0)
                            {
                                Console.WriteLine("A lista está vazia! Pressione <Enter> para sair");
                                Console.ReadKey();
                                continue;
                            }
                            Console.WriteLine($"Digite o índice que deseja consultar/alterar (0 até {mylist.Count - 1}):");
                            int targetIndex;
                            while (!int.TryParse(Console.ReadLine(), out targetIndex) || targetIndex < 0 || targetIndex >= mylist.Count)
                            {
                                Console.WriteLine($"Índice inválido! Digite um número entre 0 e {mylist.Count - 1}:");
                            }
                            Console.WriteLine($"Valor atual na posição [{targetIndex}]: \"{mylist[targetIndex]}\"");
                            Console.WriteLine("Digite o novo valor (ou deixe em branco para manter o atual):");
                            string? newValue = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(newValue))
                            {
                                mylist[targetIndex] = newValue;
                                Console.WriteLine($"Valor na posição [{targetIndex}] atualizado para \"{mylist[targetIndex]}\"!");
                            }
                            Console.WriteLine("Pressione <Enter> para sair");
                            Console.ReadKey();
                            continue;
                    }
                    Console.ReadKey();
                    break;
                }
            }
            Console.CursorVisible = true;
            Console.Clear();
        }
    }
}
