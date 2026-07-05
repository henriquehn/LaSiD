# 1. Treinamento básico de programação

Este treinamento tem como objetivo fazer o nivelamento dos tutorados, avaliando seus conhecimentos de programação e ensinando padrões, técnicas e práticas básicas para a construção de programas.

## 1.1. Ferramentas recomendadas
Para os projetos de treinamento, serão utilizados:
- Visual Studio [Visual Studio Community (preferencial)](https://visualstudio.microsoft.com/pt-br/downloads/) ou [Code (VSCode)](https://code.visualstudio.com/)
- [.Net SDK 10](https://dotnet.microsoft.com/pt-br/download/dotnet/10.0)
- [Git](https://git-scm.com/)
- Como linguagem padrão, utilizaremos o C#

O Visual Studio é o sugerido como preferencial, mas o tutorando pode utilizar o IDE de sua preferência.

Para efeito conveniência e diferenciação, chamaremos o Visual Studio Community de **Visual Studio Clásico** ou **VS Clássico**. A mesma nomenclatura também se aplica a outras variantes como Visual Studio Professional ou Visual Studio Enterprise. Eles compartilham um conjunto de funcionalidades e ferramentas que não estão presentes no Visual Studio Code, por isso, serão chamados de forma distinta.

O .Net SDK e o GIT podem ser instalados automaticamente ao instalar o Visual Studio Community, dependendo das opções de instalação escolhidas.

Para o Visual Studio Code e outros IDEs, essas ferramentas precisam ser instaladas manualmente.

## 1.2. Exercícios
Os exercícios estão numerados por ordem recomendada de execução.

Muitos exercícios são incrementais, de modo que o conhecimento aprendido em um serve de base para o exercício seguite, assim como o código, seja em parte ou na totalidade.

Cada exercício pode ser subdividido em variações que têm o propósito de exercitar habilidades e conhecimentos diferentes usando a mesma base de código.

Cada tutorando terá uma pasta com seu nome em cada exercício, onde deverá disponibilizar os seus projetos.

# 2. Padrões de implementação
## 2.1. Padrão de nomenclatura

O C# usa dois padrões de nomenclatura:

| <center>Padrão</center> | <center>Aplicação</center> | <center>Descrição</center> |
| :--- | :--- | :--- |
| PascalCase | Nomes de classes e outras entidades, métodos, propriedades e constantes | Todas as iniciais maiúsculas e demais letras minúsculas |
| CamelCase | Nomes de variáveis | Primeira inicial minúscula, demais iniciais maiúsculas e demais letras minúsculas |

## 2.2. Separação de classes

É uma boa prática separar classes diferentes em seus próprios arquivos.

Mesmo entidades como Enums e Structs podem ser declaradas em arquivos totalmente independentes se forem declarados como públicos.

Para entidades não públicas, que precisam estar aninhadas em uma classe mãe, ainda que não seja possível independência total, é possível deixá-las separadas em arquivos independentes usando classes parciais. Exemplo:

### 2.2.1. Exemplo de classe mãe
```csharp
/// <summary>
/// Classe principal pública, declarada no arquivo ClasseMae.cs
/// </summary>
namespace ExemploClasseAninhada
{
    public partial class ClasseMae
    {
        /* Ponha aqui o código que é exclusivo da classe mãe */
    }
}
```

A palavra-chave "partial" permite que você possa dividir partes da mesma classe ema arquivos diferentes.

###  2.2.2. Exemplo de classe aninhada privada em arquivo separado

```csharp
/// <summary>
/// Classe aninhada privada, declarada no arquivo ClasseMae.ClasseAninhada.cs
/// </summary>
namespace ExemploClasseAninhada
{
    public partial class ClasseMae
    {
        public class ClasseAninhada
        {
            /* Ponha aqui o código que é exclusivo da classe aninhada */
        }
    }
}
```

### 2.2.3 Observações:
- Assim como no arquivo principal, os demais arquivos usam a palavra-chave "partial".
- É importante garantir que todas todas as declarações da classe parcial tenham o mesmo nome e estejam no mewsmo namespace.
- Não faz diferença se a classe aninhada é pública ou privada, mas a classe raiz precisa ser pública.
- Como a classe aninhada está totalmente contida em um arquivo, ela não precisa ser uma classe parcial.
- O efeito prático disso é que, mesmo a classe mãe estando dividida em múltiplos arquivos, o compilçador entende que é uma entidade só.

## 3. Organização das pastas
Todo projeto .Net tem um namespace raiz, onde ficam os arquivos e pastas principais do projeto, conforme exemplo abaixo:

![Exemplo de pastas do projeto](/assets/png/exemplo_projeto.png "Exemplo de pastas do projeto")

### Neste exemplo temos:
- A Solution, que agrupa vários projetos em uma unidade coesa e integrada, chamada "PaperAnalyzer" que está no arquivo "./PaperAnalyzer.sln".
- Um projeto C# chamado "JsonDecoder", que está no arquivo "./JsonDecoder/JsonDecoder.csproj"
- As configurações de inicialização do projeto na pasta "./JsonDecoder/Properties"
- O Namespace Controls, na pasta "./JsonDecoder/Controls"
- O Namespace Enums, na pasta "./JsonDecoder/Enums"
- O Namespace Forms, na pasta "./JsonDecoder/Forms"
- A pasta de recursos embutidos do projeto (imagens, textos, etc.), na pasta "./JsonDecoder/Resources", vou explicar isso depois
- A classe de inicialização do projeto (específico para projetos do tipo console e outros), no arquivo "./JsonDecoder/Program.cs"

### 3.1. Orientações gerais sobre a solution
A solution é um agrupamento lógico de projetos. Ela pode, inclusive, comportar artefatos que não pertencem a um projeto, mas que são compartilhados por diversos projetos.

Para ter uma estrutura lógica, é importante seguir alguns padrões:

- A solution deve estar, preferencialmente, na pasta raiz onde todos os projetos dela estão;
- Cada projeto deve estar em sua própria subpastas, dentro da pasta raiz (onde está a Solution);
- Essa organização não é uma regra mandatória e o Visual Studio consegue identificar se a estrutura for diferente, pois cada projeto está declarado na solution. No entanto, é uma boa prática organizar desta forma.
- Também não é mandatório que a solution e a pasta que contém a solution tenham o mesmo nome, mas é altamente recomendável que seja assim;
- Do mesmo modo, a pastas pastas de cada projeto dentro desta solution devem ter, preferencialmente, os mesmos nomes dos arquivos principais de cada projeto (nome_do_projeto.csproj, nome_do_projeto.vbproj, etc.);
- A solutio e o projeto podem ser criados juntos ou separadamente dentro do Visual Studio e isso tem implicações na nomenclatura:
    - Criando os dois juntos, o Visual Studio costuma usar o mesmo nome para a solution e o projeto;
    - Para pprojetos simples como testes ou experimentos, isso não costuma ser um problema;
    - Para projetos maiores, isso pode ser problemático, pois o nome da solution nem sempre define o que o projeto deve fazer;
- Rececomenda-se que a solution (em branco) seja criada primeiro e os projetos depois;
- É possível renomear tudo depois, mas gera um trabalho descenessário;
- É possível ter projetos escritos em linguagens diferentes dentro da mesma solution. É perfeitamente possível ter um projeto em C#, outro em VB.net e outro em C++, todos funcionando de forma integrada:
    - Isso, por si só, não é uma prática boa nem ruim, podendo ser mais adeuqado para equipes heterogêneas com habilidades diferentes;
    - Sempre que possível, é ideal usar o menor número de linguagens possível para manter a uniformidade;
- Dependendo do tipo de projeto, é possível ter mais de uma linguagem no mesmo projeto, como C# e JavaScript:
    - Isso também não é, por si só, uma prática boa ou ruim, embora seja recomendável separar, sempre que for possível;
    - Nem sempre essa separação total é possível, mas é possível manter uma organização interna dentro do projeto em todos os casos.

### 3.1. Orientações importantes na estrutura do projeto:
- As pastas "Properties" e "Resources" possuem função especial, evite usar essas pastas para outras funções.
- A pasta "Properties" é criada automaticamente quando você cria um projeto novo usando o Visual Studio classico ou o a linha de comando do .Net Cli
- A pasta "Resources" é criada automaticamente quando voce adiciona algum recurso nas propriedades do projeto através do Visual Studio Clássico ou péla linha de comando do .net Cli
- Quando você usa o Visual Studio clássico, ele possui algumas funcionalidades automáticas:
    - Ao criar um novo projeto, o namespace raiz do projeto terá o mesmo nome do projeto;
    - Se for necessário mudar o nome do namespace raiz depois que o projeto for criado, recomenda-se fazer isso logo após criá-lo, no entanto, é fortemente recomendado que o nome do projeto seja igual ao nome do namespace raiz;
    - Qualquer classe criada na raiz do projeto usa o namespace raiz por padrão
    - Qualquer classe criada em uma subpasta do projeto assume o namespace igual à estrutura de diretório partindo do namespace raiz;
    - Ao mover uma classe de um diretório para outro, o Visual Studio oferece, automaticamente, a opção de refatoração automática do namespace. É recomendável aceitar essa sugestão;
    - No VS Code, essas facilidades não existem e você precisa cuidar disso manualmente.

Exceto pelas pastas dos namespaces, essa estrutura nãoprecisa ser criada manualmente. Tudo costuma ser criado automaticamente quando você usa o Visual Studio clássio ou o .Net cli para criar o projeto. No entanto, o .Net cli pode tomar algumas decisões automáticas, dependendo da sequência de comandos usada e os parâmetros passados em cada linha de comando.

## 4. Uso do operador de nullable (operador ?) e diretiva `<Nullable>enable</Nullable>`
Caso seu projeto tenha a tag `<Nullable>enable</Nullable>` dentro do bloco `<PropertyGroup>`, isso significa que o IDE fará verificação ativa de valores nulos e irá gerar muitos warnings sempre que houver possibilidade de alguma coisa ficar nula.

Removendo essa diretiva esse aviso desaparece e algumas coisas no código mudam:

### Com Nullable = enabled
- Argumentos de funções e variáveis do tipo Class ou Object precisam ser delcarados como:
```csharp
Tipo? minhaVariavel
Object? minhaVariavel
```

Isso não é obrigatório e não vai gerar erro de compilação, mas vais eliminar muitos warnings que poluem a lista de erros.

Esse formato de declaração é uma sinalização explícita para que o programador saiba que aque a variável pode assumir o valor null, visando previnir a nulidade acidental.

No entanto, é importante entender que a ausência do operador ? não impede a variável de assumir valor nulo, exceto se ela for de um tipo nativamente não anulável.

Deste modo, você receberá warnings sempre que existir a possibilidade da variável recber valor nulo sempre que o operador `?` não for usado.

### Com Nullable = disabled (ou quando essa diretiva não é declarada)
- Argumentos de funções e variáveis do tipo Class podem ser delcarados, sem gerar warnings, como:
```csharp
Tipo minhaVariavel
Object minhaVariavel
```

Deste modo, todos os warnings de verificação de nulidade desaparecem.

Alguns consideram isso como boa prática e outros como inconveniência. Não existe consenso sobre isso e a regra é seguir um padrão comum para todo o prjeto, qualquer que seja esse padrão adotado.

### Exceção a essa regra
Alguns tipos de dados não são capazes de receber valor nulo, mesmo se você fizer uma atribuição explícita. Esses tipos são chamados de "Não anuláveis". Isso inclui:
- Structs (incluindo tipos primitivos, que derivam de struct)
- Enums
- Tuplas

Quando você atribui null a um desses tipos, ele assume um valor padrão não nulo.

Se você realmente quiser que eles possam assumir valor nulo, você precisa declarar explicitamente. Por esse motivo, eles não geram Warning se você não usar o operador `?`.

Exemplos:
```csharp
int x; ///Essa variável não pode assumir valor nulo nem se você fizer uma atribuição explícita
int? x; /// Essa variável pode assumir valor nulo
```

Existe mais de uma forma de declarar uma variável do tipo nullable.

Exemplos:
```csharp
int? x; ///Esta é a forma mais limpa e menos verbosa.
nullable<int> x; /// A forma acima é uma simplificação para esta forma, que usa generics.
```

