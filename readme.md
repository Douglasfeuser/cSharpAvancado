## Concorrência e Paralelismo

**Concorrência** representa a capacidade de um sistema lidar com múltiplas tarefas de forma aparentemente simultânea. Isso não significa que as tarefas estão sendo executadas em diferentes núcleos do processador, mas sim que o sistema está alternando entre elas rapidamente, dando a ilusão de execução simultânea.

**Paralelismo** refere-se à execução real de múltiplas tarefas simultaneamente em diferentes núcleos de um processador ou em múltiplos processadores.

| Característica | Concorrência | Paralelismo |
|---|---|---|
| Execução | Aparentemente simultânea | Realmente simultânea |
| Hardware | Não requer hardware específico | Requer hardware multi-core ou multiprocessador |
| Mecanismos | Threads, processos, corrotinas | Threads em diferentes núcleos |
| Benefícios | Melhor responsividade, melhor utilização de recursos | Maior desempenho para tarefas intensivas em CPU |

### Exemplos

* **Concorrência:** Um grupo de pessoas usando e revesando uma mesa seria concorrência, enquanto um usa o próximo tem que esperar sua vez para utilizar a mesa.
* **Paralelismo:** O mesmo grupo se cada um tiver sua própria mesa seria considerado paralelismo, pois não precisam esperar um pelo outro e estão trabalhando ao mesmo tempo.

## Mutex

**Mutex** é um acrônimo para Mutual Exclusion (Exclusão Mútua) e representa um mecanismo de sincronização utilizado para garantir que apenas uma thread tenha acesso a um recurso compartilhado em um determinado momento. É como um semáforo que controla o acesso a uma área crítica de código.

## CancellationToken

É um objeto utilizado para propagar a notificação de cancelamento de uma operação. Ele serve como um mecanismo para cancelar de forma cooperativa tarefas assíncronas ou síncronas de longa duração.

## .AsEnumerable() vs .AsQueryable()

* **.AsEnumerable()** executa as consultas localmente. Transforma a sequência em um IEnumerable<T>, permitindo que você aplique operações LINQ que serão executadas no cliente (no seu código).
* **.AsQueryable()** pode traduzir as consultas para uma linguagem de consulta (como SQL). Transforma a sequência em um IQueryable<T>, permitindo que você construa consultas que podem ser traduzidas para uma linguagem de consulta (como SQL), especialmente quando você está trabalhando com um provedor de consultas (como Entity Framework).