# 1. Atividade 1:
## 1.1. Lista duplamente encadeada circular com nó cabeça

Este exercício tem o propósito de ser uma introdução para os fundamentos da linguagem C#

Uma lista simplesmente encadeada é aquela em que cada nó da lista é uma estrutura composta, que armazena o valor e aponta para o elemento seguinte.

Em uma lista duplamente encadeada, cada nó também aponta para o elemento anterior da lista.

Uma lista pode ou não ter um nó cabeça. Ele serve de elemento de referência para simplificar a inplementação da lista, pois esse nó sempre está presente, mesmo se a lista estiver vazia. O valor do nó cabeça é irrelevante, pois ele nunca é usado.

A função do nó cabeça é eliminar testes de nulidade, melhorando a eficiência da lista e deixando as operações mais seguras.

Algumas implementações também utilizam o nó calda, quando a lista não é circular.

## 1.2. Exercício 1:

Crie uma lista duplamente encadeada circular com nó cabeça, implemente os seguintes métodos:
- void Add(object value);
- void Clear();
- void List();
- bool Remove(object value);

O método ADD() deve adicionar um item no final da lista.

O método Clear() deve descartar todos os elementos da lista.

O método List() deve imprimir todos os elementos. Caso não existam elementos, ele deverá informar que a lista está vazia.

O método remove deve recomer a primeira ocorrência de um valor da lista.

### 1.2.1. Algoritmo de teste para aplicativo do tipo Console:

Utilize o seguinte algotitmo para testar sua classe:

```csharp
static void Main(string[] args)
{
    Console.WriteLine("Teste com a lista encadeada circular com nó cabeça:");
    Console.WriteLine("Adicionando os valores 1, 15, 3, 10, 350, 15 nessa exata ordem (o valor 15 está repetido propositalmente)");
    var list = new CircularList();

    list.Add(1);
    list.Add(15);
    list.Add(3);
    list.Add(10);
    list.Add(350);
    list.Add(15);

    Console.WriteLine("Listando conteúdo da lista:");
    list.List();

    Console.WriteLine("Removendo o valor 15 e listando novamente:");
    list.Remove(15);
    list.List();

    Console.WriteLine("Esvaziando a lista e listando novamente:");
    list.Clear();
    list.List();
    Console.Write("Pressione alguma tecla para encerrar...");
    Console.ReadKey();
}
```

Esse é um teste de mesa extremamente básico, mas cumpre o propósito para a atividade proposta.

Em atividades posteriores entenderemos como construir testes automatizados mais robbustos.

## 1.3. Exercício 3:
### Adicione a propriedade Count na sua lista.

A propriedade Count deve ser apenas para leitura e deve retornar o núymero de elementos da lista.

### 1.3.1. Guia de referência da linguagem para o uso de propriedades

Em C#, uma propriedade é usada de forma semelhante a um atributo (variável simples declarada como pública ou provada), onde voccê atribui ou lê o valor diretamente.

Exemplo:

```csharp
meuObjeto.MinhaPropriedade = Valor;
minhaVariavel = meuObjeto.MinhaPropriedade;
```

A diferença vásica é que um atributo é uma variável declarada como membro de uma classe. Uma propriedade é um método composto, que possui um getter e um setter. Exemplo:

```csharp
/* Clase com propriedades auto-declaradas */
public class MinhaClasse
{
    public int MinhaPropriedade{get;set;}
}
```

Neste exemplo, o compilador irá construir automaticamente as estruturas internas de getter, setter e variável de controle para a propriedade `MinhaPropriedade`.

```csharp
/* Clase com propriedades explícitas */
public class MinhaClasse
{
    private int _minhaPropriedade;

    public int MinhaPropriedade
    {
        get 
        {
            return _minhaPropriedade;
        }
        set
        {
            _minhaPropriedade = value;
        }
    }
}
```

Neste exemplo, a estrutura completa foi declarada explicitamente, observe que Get e Set são claramente métodos, a despeito da aparente simplicidade no uso da propriedade. Como tal, podem comportar lógicas complexas.

Uma propriedade pode ser somente para escrita ou somente para leitura;
- Declarando apenas o Get, ela será somente para leitura;
- Delcarando apenas o set, ela será somente para escrita;
- Declaranndo ambos, a propriedade será para leitura e escrita.

É possível alterar o escopo do Get e do Ser individualmente. Por exemplo:

```csharp
/* Clase com propriedades auto-declaradas */
public class MinhaClasse
{
    public int MinhaPropriedade{get;private set;}
}
```

Neste exemplo, Get é visível publicamente e pode ser acessado pelo usuário da classe.

Por outro lado, Set é privado e só pode ser acessado pela própria classe.

É importante observar que não é poissível atribuir tipos diferentes para Get e Set. Os tipos são declarados para a propriedade como um todo e não para os métodos de acesso individuais.


É possível usar uma expressão lambda para simplificar o código da declaração explícita, quando você não precisa que o get faça nenhum tipo de processamento adicional. Por exemplo:

```csharp
/* Clase com propriedades explícitas e lambda  */
public class MinhaClasse
{
    private int _minhaPropriedade;

    public int MinhaPropriedade
    {
        get => _minhaPropriedade;
        set
        {
            _minhaPropriedade = value;
        }
    }
}
```

O uso do operador `=>` indica que você está declarando uma expressão lambda que retorna automaticamente o valor da variável que vem depois da seta.

Essa simplificação vale apenas para o Get.
