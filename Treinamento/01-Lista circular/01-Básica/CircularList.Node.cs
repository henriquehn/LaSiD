namespace list
{
    public partial class CircularList
    {
        private class Node
    {
        //criar o no e os objetos que serão os proximos e anteriores
        public object value;
        public Node? previous;
        public Node? next;
        public Node(object? obj) // chamar o objeto
        {
            value = obj;
        }
    }
    }
}