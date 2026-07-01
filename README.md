# 📦 API de Gerenciamento de Estoque e Preços com Alertas

Esta é uma Web API robusta desenvolvida em **.NET** para o gerenciamento inteligente de estoque de produtos, monitoramento de flutuação de preços e disparo de alertas em tempo real. O projeto foi estruturado seguindo princípios de **Arquitetura Limpa (Clean Architecture)** e **Domain-Driven Design (DDD)** adaptado, garantindo alta manutenibilidade, isolamento de regras de negócio e testabilidade.

---

## 🚀 Tecnologias Utilizadas

* **Runtime:** .NET 10.0 (C#)
* **Framework Web:** ASP.NET Core Web API com Controllers
* **ORM / Persistência:** Entity Framework Core (Provedor In-Memory)
* **Documentação:** Swagger (Swashbuckle)
* **Testes:** xUnit

---

## 🏛️ Arquitetura e Boas Práticas Aplicadas

O projeto adota uma divisão clara de responsabilidades, distribuída nas seguintes camadas:

* **Core (Domínio):** Contém as entidades de negócio (`Produto`, `HistoricoPreco`), exceções customizadas e os contratos (interfaces) dos repositórios e serviços. As entidades utilizam **encapsulamento rígido** (`private set`), protegendo o estado interno e forçando alterações apenas através de métodos de negócio válidos.
* **Application (Aplicação):** Gerencia os fluxos de caso de uso e orquestração, como o `EstoqueServico`, além de centralizar os DTOs (Data Transfer Objects).
* **Infrastructure (Infraestrutura):** Implementa o acesso a dados via Entity Framework Core (`AppDbContext`), repositórios e serviços de notificação externa (como alertas visuais em console).
* **API:** Camada de entrada que expõe os endpoints HTTP e centraliza o **Tratamento Global de Erros** através de um Middleware customizado, convertendo exceções de negócio em respostas limpas com código `400 Bad Request`.

---

## 🔧 Funcionalidades Principais

1.  **Cadastro de Produtos:** Inicialização de itens com validação de consistência (valores negativos, campos obrigatórios).
2.  **Baixa de Estoque Inteligente:** Redução de estoque blindada contra valores negativos.
3.  **Sistema de Alertas Visuais:** Monitoramento do nível do estoque comparado ao estoque mínimo configurado, disparando avisos em tempo real quando o nível se torna crítico.
4.  **Auditoria de Preços (1:N):** Rastreamento automático e imutável de todas as alterações de preços sofridas por um produto ao longo do tempo.

---

## 🛠️ Como Executar o Projeto Localmente

### Pré-requisitos
* [.NET SDK](https://dotnet.microsoft.com/download) instalado na máquina.

### Passo a Passo

1. Clone o repositório para a sua máquina local:
   ```bash
   git clone [https://github.com/Mennz/Gerenciamento-de-Estoque.git]
