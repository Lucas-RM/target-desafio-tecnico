# 🎯 Target - Desafio Técnico

Desafio técnico desenvolvido para o processo seletivo de **Desenvolvedor(a) de Sistemas Jr.** da **Target Sistemas**. O objetivo é avaliar lógica, organização, criatividade e a estruturação de soluções.

## 📋 Sobre o Projeto

Este repositório contém a resolução de 3 desafios de programação propostos pela Target Sistemas, implementados em C# com .NET 6.0. Cada desafio aborda um cenário diferente do dia a dia de um desenvolvedor.

O projeto foi desenvolvido seguindo os princípios de **Clean Architecture** e **Clean Code**, garantindo código organizado, testável e manutenível.

---

## 🧩 Desafios

### Desafio 01 - Calculadora de Comissões

Sistema que calcula as comissões de um time comercial com base nas vendas realizadas.

**Regras de Comissão:**
- Vendas abaixo de R$ 100,00 → Sem comissão
- Vendas entre R$ 100,00 e R$ 499,99 → 1% de comissão
- Vendas a partir de R$ 500,00 → 5% de comissão

O sistema lê os dados de vendas de um arquivo JSON e gera um relatório detalhado com o total de vendas e comissões por vendedor.

---

### Desafio 02 - Controle de Movimentação de Estoque

Sistema interativo para gerenciar a movimentação de produtos em estoque.

**Funcionalidades:**
- Entrada de mercadoria
- Saída de mercadoria (com validação de estoque disponível)
- Consulta do estoque atual
- Histórico de movimentações

Os produtos são carregados de um arquivo JSON e o sistema mantém um registro de todas as operações realizadas durante a execução.

---

### Desafio 03 - Calculadora de Juros por Atraso

Sistema que calcula o valor de juros a ser pago em caso de atraso no pagamento.

**Regras:**
- Taxa de multa: 2,5% ao dia
- O usuário informa o valor original e a data de vencimento
- O sistema calcula os dias de atraso e o valor total a pagar

---

## 🛠️ Tecnologias e Ferramentas

- **Linguagem:** C#
- **Framework:** .NET 6.0
- **Arquitetura:** Clean Architecture
- **Padrões:** SOLID, Repository Pattern, Service Pattern
- **IDE:** Visual Studio / Visual Studio Code
- **Serialização:** System.Text.Json
- **Versionamento:** Git & GitHub

---

## 🚀 Como Executar

### Pré-requisitos

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) ou superior instalado

### Passos

1. **Clone o repositório:**
```bash
git clone https://github.com/Lucas-RM/target-desafio-tecnico.git
```

2. **Acesse a pasta do projeto:**
```bash
cd target-desafio-tecnico/DesafiosTarget
```

3. **Compile o projeto:**
```bash
dotnet build
```

4. **Execute o projeto:**
```bash
dotnet run
```

5. **Escolha o desafio** no menu interativo que será exibido.

---

## 📁 Estrutura do Projeto

O projeto segue a arquitetura em camadas (Clean Architecture), onde cada desafio possui sua própria estrutura organizada:

```
DesafiosTarget/
├── desafio-01/
│   ├── Domain/
│   │   ├── Entities/          # Entidades de negócio (Venda, ComissaoVendedor, DadosVendas)
│   │   └── ValueObjects/      # Objetos de valor (RegraComissao)
│   ├── Application/
│   │   ├── Interfaces/        # Contratos para inversão de dependência
│   │   └── Services/          # Serviços de aplicação (ComissaoService)
│   ├── Infrastructure/
│   │   └── Repositories/      # Implementação de acesso a dados (VendaRepository)
│   ├── Presentation/
│   │   └── Console/           # Interface do usuário (ComissaoConsoleView)
│   ├── DesafioUm.cs           # Ponto de entrada do desafio
│   └── registros-vendas.json
├── desafio-02/
│   ├── Domain/
│   │   └── Entities/          # Entidades (Produto, Movimentacao, DadosEstoque)
│   ├── Application/
│   │   ├── Interfaces/
│   │   └── Services/          # EstoqueService
│   ├── Infrastructure/
│   │   └── Repositories/      # ProdutoRepository, MovimentacaoRepository
│   ├── Presentation/
│   │   └── Console/           # EstoqueConsoleController, EstoqueConsoleView
│   ├── DesafioDois.cs
│   └── estoque-dos-produtos.json
├── desafio-03/
│   ├── Domain/
│   │   └── ValueObjects/      # CalculoJuros
│   ├── Application/
│   │   ├── Interfaces/
│   │   └── Services/          # JurosService
│   ├── Presentation/
│   │   └── Console/           # JurosConsoleController, JurosConsoleView
│   └── DesafioTres.cs
└── Program.cs                  # Menu principal da aplicação
```

### 🏗️ Arquitetura

Cada desafio segue a estrutura de **Clean Architecture** com as seguintes camadas:

- **Domain**: Contém as entidades e regras de negócio puras, sem dependências externas
- **Application**: Contém a lógica de aplicação, serviços e interfaces (contratos)
- **Infrastructure**: Implementa os detalhes técnicos (acesso a dados, arquivos, etc.)
- **Presentation**: Responsável pela interface com o usuário (Console)

---

## 📄 Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.
