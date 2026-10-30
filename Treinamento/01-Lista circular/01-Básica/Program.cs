using System;


namespace mainProgram
{
    class Program
    {
        static void Main()
        {
            list.CircularList mylist = new list.CircularList();
            string[] options = { "0.Exit", "1.List", "2.Add", "3.Remove", "4.Clear" };
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
                            object? entry = Console.ReadLine();
                            while (entry == null || entry == (object)"")
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
                            object? delete = Console.ReadLine();
                            while (delete == null || delete == (object)"")
                            {
                                Console.WriteLine("Entrada invalida, Digite uma entrada valida:");
                                delete = Console.ReadLine();
                            }
                            mylist.Remove(delete!);
                            Console.WriteLine("Pressione <Enter> para confirmar");
                            Console.ReadKey();
                            continue;
                        case 4:
                            mylist.Clear();
                            Console.WriteLine("Lista esvaziada, Aperte <Enter> para sair");
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
