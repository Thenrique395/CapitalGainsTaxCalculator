# Capital Gains Tax Calculator

## Descrição
O **Capital Gains Tax Calculator** é uma ferramenta que calcula o imposto sobre os ganhos de capital (venda de ativos). O projeto segue o padrão de design *Strategy*, permitindo a flexibilidade no cálculo dos impostos sobre compra e venda de ativos financeiros.

## Por que usar o padrão *Strategy*?
O padrão *Strategy* foi escolhido para permitir que diferentes estratégias de cálculo de imposto fossem encapsuladas em classes distintas e facilmente intercambiáveis. Com isso, o código de cálculo de imposto é desacoplado do código que executa as operações. Quando novos tipos de impostos ou cálculos precisam ser adicionados, basta criar uma nova estratégia, sem alterar a lógica central de processamento das operações.

### Benefícios do padrão *Strategy*:
- **Flexibilidade**: Novas regras de cálculo de imposto podem ser facilmente adicionadas sem modificar o código existente.
- **Desacoplamento**: A lógica de cálculo do imposto fica separada da lógica de processamento das operações.
- **Facilidade de manutenção**: Mudanças em uma estratégia específica não afetam as demais, facilitando a manutenção e evolução do sistema.

## Estrutura do Projeto
O projeto é composto por varias partes:

### Descrição das Pastas e Arquivos

1. **CapitalGainsTaxCalculator**: A aplicação principal, responsável por calcular o imposto sobre ganhos de capital com base nas operações de compra e venda.
    - **Models/**: Contém as classes que representam os conceitos principais do domínio, como a operação de compra e venda (`Operation`) e o resultado do cálculo do imposto (`TaxCalculationResult`).
    - **Strategies/**: Contém as implementações das estratégias de cálculo de imposto. O padrão *Strategy* é utilizado aqui para permitir que diferentes algoritmos de cálculo sejam usados dependendo do tipo de operação (compra ou venda). As classes `BuyTaxStrategy` e `SellTaxStrategy` implementam as estratégias de cálculo de imposto para cada tipo de operação.
    - **Services/**: Contém a lógica de orquestração do processo de cálculo de imposto. A classe `CapitalGainsTaxCalculator` gerencia o fluxo de execução e aplica as estratégias de cálculo de imposto para cada operação.
    - **Util/**:: Contém utilitários gerais para o projeto, como a leitura de arquivos JSON e o mapeamento de DTOs para objetos de operação.
    - **src/DataJson/**: Esta pasta contém o arquivo JSON operations.json, que é utilizado para carregar as operações de compra e venda e calcular os impostos sobre elas.

2.**CapitalGainsTaxCalculatorTest**: Contém os testes unitários e integrado do projeto, garantindo que a lógica de cálculo de impostos esteja correta e validando as diferentes estratégias aplicadas.

3. **Program.cs**: O ponto de entrada do aplicativo, onde o fluxo principal é orquestrado. Aqui, as operações de compra e venda são definidas e processadas utilizando as estratégias de imposto.

## Como Funciona
- As operações são representadas pela classe `Operation`, que contém informações sobre o custo unitário, a quantidade de ativos e a estratégia de imposto aplicável.
- A classe `CapitalGainsTaxCalculator` processa as operações e calcula o imposto devido com base na estratégia apropriada (compra ou venda).
- A estratégia de cálculo de imposto é determinada por meio do padrão *Strategy*, onde diferentes comportamentos (cálculos de imposto) são definidos nas classes `BuyTaxStrategy` e `SellTaxStrategy`.

## Como Usar

### 1. Clonando o Repositório
Clone o repositório para o seu ambiente local utilizando o comando Git:

```bash
  git clone https://github.com/seu-usuario/CapitalGainsTaxCalculator.git
```

### 2. Compilando o Projeto
Após clonar o repositório, navegue até a pasta raiz do projeto e compile o projeto utilizando o comando dotnet build:
```bash
  cd CapitalGainsTaxCalculator
  dotnet build

#Este comando irá compilar o projeto e preparar todos os binários necessários para a execução.
```
### 3. Executando a Aplicação
Para rodar a aplicação principal e calcular o imposto sobre ganhos de capital, execute o seguinte comando:
```bash
  dotnet run --project CapitalGainsTaxCalculator
# O comando irá rodar o programa e imprimir o cálculo do imposto de vendas no console.
```
### 4. Executando os Testes Unitários
O projeto inclui testes unitários para validar a lógica de cálculo. Para executar os testes, navegue até a pasta de testes e rode o seguinte comando:
```bash
  cd CapitalGainsTaxCalculatorTest
  dotnet test
# Isso irá rodar todos os testes configurados no projeto de testes, fornecendo um relatório sobre o sucesso ou falha dos testes.
```
### Testes
 Os testes unitários estão localizados no projeto CapitalGainsTaxCalculatorTest. Eles validam o comportamento das funções principais de cálculo de impostos, garantindo que a lógica implementada no projeto principal funcione corretamente.

Para rodar os testes:
```bash
  dotnet test
  Para rodar testes específicos, use o nome do teste:

  dotnet test --filter "NomeDoTeste"
```
#### Detalhes dos Testes
Os testes incluem casos para verificar o cálculo correto de impostos nas operações de compra e venda, bem como a verificação de diferentes cenários de lucros e perdas.

## Licença
#### Este projeto é de código aberto e está disponível sob a licença MIT. Você pode usar, modificar e distribuir o código conforme os termos dessa licença.











