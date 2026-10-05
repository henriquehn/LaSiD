using System;

namespace list
{
    public class Node
    {
        //criar o no e os objetos que serão os proximos e anteriores
        public object? value;
        public Node? previous;
        public Node? next;
        public Node(object? obj) // chamar o objeto
        {
            value = obj;
        }
    }
    public class CircularList
    {
        //criar classe lista com head, tail e o ultimo(variavel temporaria para troca)
        private Node? head;
        Node tails = head.previous; //o tail recebe o anterior do head
        public int Count = 0;
        public CircularList()
        {
            head = new Node(null);
            head.previous = head;
            head.next = head;
        }
        public void Add(object obj)
        {
            if (obj != null)
            {
                Node nNo = new Node(obj);
                tails!.next = nNo; //o proximo do tail recebe o novo no
                nNo.previous = tails; //o anterior do novo no recebe o tail
                nNo.next = head; //o proximo do novo no recebe o head
                head.previous = nNo; //o anterior do head recebe o novo no
                Count++;
            }
        }
        public void List()
        {
            if (head!.next == head) //se o next do head for igual ao head/null, esta vazio a lista
            {
                Console.WriteLine("Lista Vazia");
                return;
            }
            Node? atual = head.next;
            Console.WriteLine("Lista: Objeto");
            while (atual != head) //enquanto o atual for diferente de head/null, mostra
            {
                Console.WriteLine($"- \"{atual!.value}\"");
                atual = atual.next;
            }
            Console.WriteLine($"Total de objetos: {Count}");
        }
        public bool Remove(object obj)
        {
            Node? atual = head!.next;
            while (atual != head)
            {
                if (Object.Equals(atual!.value, obj))
                {
                    Node? neighbef = atual.previous;
                    Node? neighnext = atual.next;

                    neighbef!.next = neighnext;// o proximo do deletado vira o proximo do anterior 
                    neighnext!.previous = neighbef; // o anterior que apontava para o deletado aponta para anterior do deletado 

                    Console.WriteLine($"O objeto; {obj} foi encontrado deletado");
                    Count--;
                    return true;
                }
                atual = atual.next;
            }
            Console.WriteLine($"- {obj} não encontrado!");
            return false;
        }

        public void Clear()
        {
            head?.previous = head;
            head?.next = head;
            Count = 0;
        }
    }
}

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
