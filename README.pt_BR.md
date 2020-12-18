![Take - Problema: Correios de San Andreas](https://i.imgur.com/ojkUyf9.png)



# TakeTest
Esta é uma solução para uma atividade de nivelamento técnico da empresa Take.net.

Desenvolvido em [dotnet](https://github.com/dotnet/sdk/) `v3.1.103`.



## Solução Implementada

Após a leitura do problema (Correios de San Andreas) e a compreensão de que se tratava de uma tarefa para calcular a menor rota entre pontos (cidades de San Andreas), decidi por utilizar grafo orientado (ou grafo dirigdo, ou grafo direcionado) juntamente com o algorítmo de Dijkstra para encontrar o menor caminho entre dois ponto.

![Grafo da solução](https://i.imgur.com/YM3IVEd.png)

Dividi a solução em 3 partes:

1. **Library**: é a biblioteca do sistema, onde se encontram as classes para a solução da atividade.
2. **Application**: é a interface com o usuário, onde é feita a importação dos arquivos de trechos e encomendas e a exportação do arquivo de rotas.
3. **Tests**: responsável por realizar todos os testes da biblioteca da solução.



## Instalação

**Utilizando o console:**

Clone o repositório e faça um restore:

```shell
$ git clone ...
$ dotnet restore
```

Faça uma publicação da aplicação:

```shell
$ cd TakeTest.Application
$ dotnet publish -c Release
```



## Utilização

Disponibilizei, na pasta `Resources` do projeto `TakeTest.Application`, dois arquivos para o teste da aplicação: `paths.txt` contendo os trechos entre cidades e `shipments.txt` contendo as encomendas.

A aplicação publicada estará na pasta `bin\Release\netcoreapp3.1\`.

Para rodar a aplicação:

### Windows

`> TakeTest.Application.exe paths.txt shipments.txt output.txt`

### Linux

`$ ./TakeTest.Application paths.txt shipments.txt output.txt`

### Comportamentos (output)

* Caso alguma linha do arquivo de encomendas contenha alguma cidade que não foi informada no arquivo de trechos, a saída para aquela linha (encomenda) será `ERROR: UNKNOWN [CITY_NAME]`, onde `[CITY_NAME]`  é a cidade informada incorretamente.
* Caso aconteça algum erro inesperado para o cálculo de uma rota de uma encomenda, a saída será `ERROR: INVALID REQUEST`.
* Caso a encomenda seja para uma rota inalcançável, a saída será uma constante chamada `UNREACHABLE` que, no código fonte, tem o valor de `-1`.



## Testes

Para rodar os testes do sistema:

```shell
$ cd TakeTest.Tests
$ dotnet test
```



## Considerações

* Caso tivesse um pouco mais de tempo para a execução da tarefa, Iria melhorar o tratamento da entrada de dados;
* Achei o exercício interessante e prazeroso de ser solucionado;
* Gostei do uso das cidades da franquia de GTA!



## Referências

* [Wikipedia: Dijkstra's Algorithm](https://en.wikipedia.org/wiki/Dijkstra's_algorithm)

* [Youtube: Graph Data Structure - Dijkstra's Shortest Path Algorithm](https://www.youtube.com/watch?v=pVfj6mxhdMw)