namespace List
{
    public partial class CircularList
    {
        private class Node
        {
            //criar o no e os objetos que serão os proximos e anteriores
            public object? Value { get; set; }
            public Node? Previous { get; set; }
            public Node? Next { get; set; }
            public Node(object obj) // chamar o objeto
            {
                Value = obj;
            }
            public Node()
            {
                this.Previous = this;
                this.Next = this;
            } //chamar o objeto, o anterior e o proximo
        }
    }
}