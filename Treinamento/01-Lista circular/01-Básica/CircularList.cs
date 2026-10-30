namespace list
{
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