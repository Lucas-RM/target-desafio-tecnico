# 🎯 Target - Desafio Técnico

Desafio técnico desenvolvido para o processo seletivo de **Desenvolvedor(a) de Sistemas Jr.** da **Target Sistemas**. O objetivo é avaliar lógica, organização, criatividade e a estruturação de soluções.

## 📋 Sobre o Projeto

Este repositório contém a resolução de 3 desafios de programação propostos pela Target Sistemas, implementados em C# com .NET 6.0. Cada desafio aborda um cenário diferente do dia a dia de um desenvolvedor.

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

```
DesafiosTarget/
├── desafio-01/
│   ├── DesafioUm.cs
│   ├── registros-vendas.json
│   └── Models/
├── desafio-02/
│   ├── DesafioDois.cs
│   ├── estoque-dos-produtos.json
│   └── Models/
├── desafio-03/
│   └── DesafioTres.cs
└── Program.cs
```

---

## 📄 Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.
