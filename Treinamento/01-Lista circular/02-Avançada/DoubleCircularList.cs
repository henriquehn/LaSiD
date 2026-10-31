namespace List
{
    using System.Collections;
    public partial class DoubleCircularList<T> : IList<T>
    {
        //criar classe lista com head, tail e o ultimo(variavel temporaria para troca)
        private Node? head;
        public int Count { get; private set; } = 0;
        public DoubleCircularList()
        {
            head = new Node();
        }
        public void Add(T obj)
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
        public void List()
        {
            int index = 0;
            if (head!.Next == head) //se o Next do head for igual ao head/null, esta vazio a lista
            {
                Console.WriteLine("Lista Vazia");
                return;
            }
            Node? atual = head.Next;
            Console.WriteLine("Lista: Objeto");
            while (atual != head) //enquanto o atual for diferente de head/null, mostra
            {
                Console.WriteLine($"- \"{index} {atual!.Value}\"");
                atual = atual.Next;
                index++;
            }
            Console.WriteLine($"Total de objetos: {Count}");
        }
        public bool Remove(T obj)
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
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }
        public bool Contains(T params_value)
        {
            Node? atual = head?.Next;
          for (int i = 0; i < Count; i++)
          {
            if (Object.Equals(atual!.Value, params_value))
            {
                return true;
            }
            atual = atual.Next;
          }
          return false;
        }
        public int IndexOf(T params_value)
        {
            Node? atual = head?.Next;
            for (int i = 0; i < Count; i++)
          {
            if (Object.Equals(atual!.Value, params_value))
            {
                return i;
            }
            atual = atual.Next;
          }
            return -1;
        }
        public void RemoveAt(int params_index)
        {
            if (params_index < 0 || params_index > Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            Node? atual = head?.Next;
            for (int i = 0; i < Count; i++)
          {
            if (params_index == i)
            {
                Node? neighbef = atual!.Previous;
                    Node? neigh_next = atual.Next;

                    neighbef!.Next = neigh_next;// o proximo do deletado vira o proximo do anterior 
                    neigh_next!.Previous = neighbef; // o anterior que apontava para o deletado aponta para anterior do deletado 

                    Console.WriteLine($"O objeto; {params_index} foi encontrado deletado");
                    Count--;
                    break;
            }
            atual = atual!.Next;
          }
        }
        public void Insert(int params_index, T params_value )
        {
            if (params_index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (params_index >= Count)
            {
                Add(params_value);
                return;
            }
            Node? atual = head?.Next;
            for (int i = 0; i < Count; i++)
          {
            if (params_index == i)
            {
               Node? tails = atual!.Previous; //o tail recebe o anterior do head
                Node nNo = new Node(params_value);
                tails!.Next = nNo; //o proximo do tail recebe o novo no
                nNo.Previous = tails; //o anterior do novo no recebe o tail
                nNo.Next = atual; //o proximo do novo no recebe o head
                atual.Previous = nNo; //o anterior do head recebe o novo no
                Count++;
                break;
            }
            atual = atual!.Next;
          }
        }
        public T this[int params_index]
        {
            get
            {
                if (params_index < 0 || params_index >= Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                Node? atual = head?.Next;
                for (int i = 0; i < Count; i++)
                {
                    if (params_index == i)
                    {
                        return atual!.Value!;
                    }
                    atual = atual?.Next;
                }
                throw new ArgumentOutOfRangeException();
            }
            set
            {
                if (params_index < 0 || params_index >= Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                Node? atual = head?.Next;
                for (int i = 0; i < Count; i++)
                {
                    if (params_index == i)
                    {
                        atual!.Value = value;
                        break;
                    }
                    atual = atual?.Next;
                }
            }
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            Node? atual = head?.Next;
                for (int i = 0; i < Count; i++)
                {
                    array[arrayIndex+i] = atual!.Value!;
                    atual = atual?.Next;
                }
        }
        public IEnumerator<T> GetEnumerator()
        {
            Node? atual = head?.Next;
                for (int i = 0; i < Count; i++)
                {
                    yield return atual!.Value!;
                    atual = atual?.Next;
                }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}