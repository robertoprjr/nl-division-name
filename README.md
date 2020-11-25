# NL Division Name API

## API com modelo para divisão de nomes

Entrada esperada: Nome Completo de uma Pessoa
Saída esperada: Nome da Pessoa dividido em:
- Primeiro Nome (*FirstName*)
- Nome do Meio (*MiddleName*)
- Primeiro Sobrenome (*FisrtLastName*)
- Segundo Sobrenome (*SecondLastName*)

Há diversas assinaturas intermediárias para demonstrar como foi feita a criação e separadação das informações
- **Particle List** : Lista de particulas de nomes configuradas 
- **Slice**: O nome recebido apenas fatiado
- **Part**: O nome particionado, já classificando as particulas dentro de cada parte do nome
- **Division**: O nome particionado e classificado conforme a saída esperada porém ainda em lista
- **Structured**: O nome já estruturado na saída esperada

## Boas práticas de codificação aplicadas no projeto

### Struct, ao invés de Class, para retorno de dados

O uso de Struct é indicado para quando temos objetos simples e de passagem de informação pois usa a memória de Stack, onde ao finalizar a execução, a memória é limpa.

É importante que a Struct não seja usada para objetos muito grandes ou complexos para não ganharmos um StackOverflow

Com isso, o uso do Struct em DTOs de retorno é bem interessante já que justamente se encaixam no perfil de bom uso da Struct

Mais detalhes:
https://pt.stackoverflow.com/questions/16181/qual-a-diferen%C3%A7a-entre-struct-e-class

### Domínios com regras de negócio, Serviços com regras de orquestração

Seguindo o DDD, as regras de negócio das Entidade estão dentro da própria entidade e não em uma camada de Serviço

As regras de orquestração estão separadas e implementadas na camada de Serviço

### Uso de Design Patterns aplicável para a solução de problemas

Os seguintes design patters foram aplicados nessa solução:

- **Factory** : O Factory é aplicado para encapsular as regras aplicadas para cada quantidade de nomes recebidos, fazendo com que isso não esteja apenas em uma condicional de ifs ou switch

*Vantagens*: 
- Cada classe é responsável por uma regra de definição dos nomes (principio SRP)
- Caso seja preciso adicionar uma regra, apenas temos que criar uma classe para a nova regra sem alterar as regras atuais (principio OCP)

Modelo: https://refactoring.guru/pt-br/design-patterns/factory-method

- **Cadeia de Responsabilidade** : A Cadeia de Responsabilidade aqui é usado para manter o funcionamento da orquestração passo por passo da tipificação de cada um dos nomes, ou seja, cada método da Factory citada acima é composto por uma Cadeia de Responsabilidade dentro de outros métodos

*Vantagens*:
- Cada passo dado é feito por um objeto específico (principio SRP)
- Caso seja preciso mudar uma regra apenas para uma das quantidades de nomes, apenas a regra especifica será impactada

Modelo: https://refactoring.guru/pt-br/design-patterns/chain-of-responsibility

Nesse ponto, a aplicação do design patterns nessa codificação torna os principios do **SOLID** devidamente cumpridos e houve uma criação inicial mas complexa porém que facilitará muito a manutenabilidade da codificação

### Código Limpo e Principios de Codificação

Segue aqui mais alguns principios de codificação que foram seguidos nesse projeto:
- Linguagem Ubiqua: Todos os métodos e classes evidenciam o que devem fazer seguindo sempre um padrão de nomenclatura para facilitar a leitura
```cs
private void Start()
{
    StartCounter();
    ClearPositionDictionary();
    ClearParts();
    ClearParticle();
}
```
- Métodos simples e objetivos: Os métodos fazem apenas uma tarefa e com poucas linhas para sempre facilitar o entendimento e manutenção. Metodos mais complexos são feitos da união de métodos simples 

*Obs: Muitos métodos inclusive com apenas uma linha... essa pratica é interessante pois esboça por um nome qual a intenção do método*

Ao invés de ter uma linha do tipo:
```cs
_particlePart = string.Empty;
```
Termos a codificação assim:
```cs
private void ClearParticle() =>
    _particlePart = string.Empty;
```

- **SRP** Responsabilidade única: Como já inclusive citado na definição dos patterns, foi tomado o cuidado para não quebrar o principio de responsabilidade única simplicando os objetos com apenas uma tarefa e focando na orquestração de objetos

```cs
public class SecondLastNameForAllPlusDivisionHandler: NameDivisionHandler
{
    protected override NameParts DefineDivision(NameParts nameParts)
    {
        nameParts.SetDefinitionForAllUndefined(NameDivisionTypeEnum.SecondLastName);
        return nameParts;
    }
}
```

- **OCP** Aberto para extensão, fechado para alteração: Como já inclusive citado na definição dos patterns, a separação das regras e a cadeia passo por passo da regra de definição de nomes faz com que qualquer regra nova criada não precisa alterar em nada a codificação das atuais ou, uma regra que precise ser alterada, somente impacta nela e em nenhuma outra

Obs: As outras questões de **SOLID** também foram seguidas mas essas merecem destaque
