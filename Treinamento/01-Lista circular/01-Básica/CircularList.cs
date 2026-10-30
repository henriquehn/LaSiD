namespace List
{
    public partial class CircularList
    {
        //criar classe lista com head, tail e o ultimo(variavel temporaria para troca)
        private Node? head;
        public int Count { get; private set; } = 0;
        public CircularList()
        {
            head = new Node();
        }
        public void Add(object obj)
        {
            if (obj != null)
            {
                Node? tails = head!.Previous; //o tail recebe o anterior do head
                Node nNo = new Node(obj);
                tails!.Next = nNo; //o proximo do tail recebe o novo no
                nNo.Previous = tails; //o anterior do novo no recebe o tail
                nNo.Next = head; //o proximo do novo no recebe o head
                head.Previous = nNo; //o anterior do head recebe o novo no
                Count++;
            }
        }
        public void list()
        {
            if (head!.Next == head) //se o Next do head for igual ao head/null, esta vazio a lista
            {
                Console.WriteLine("Lista Vazia");
                return;
            }
            Node? atual = head.Next;
            Console.WriteLine("Lista: Objeto");
            while (atual != head) //enquanto o atual for diferente de head/null, mostra
            {
                Console.WriteLine($"- \"{atual!.Value}\"");
                atual = atual.Next;
            }
            Console.WriteLine($"Total de objetos: {Count}");
        }
        public bool Remove(object obj)
        {
            Node? atual = head!.Next;
            while (atual != head)
            {
                if (Object.Equals(atual!.Value, obj))
                {
                    Node? neighbef = atual.Previous;
                    Node? neigh_next = atual.Next;

                    neighbef!.Next = neigh_next;// o proximo do deletado vira o proximo do anterior 
                    neigh_next!.Previous = neighbef; // o anterior que apontava para o deletado aponta para anterior do deletado 

                    Console.WriteLine($"O objeto; {obj} foi encontrado deletado");
                    Count--;
                    return true;
                }
                atual = atual.Next;
            }
            Console.WriteLine($"- {obj} não encontrado!");
            return false;
        }

        public void Clear()
        {
            head?.Previous = head;
            head?.Next = head;
            Count = 0;
        }
    }
}