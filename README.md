# 🧭 SIGO - Sistema Integrado de Gestão e Operação

O SIGO é um sistema web desenvolvido como parte do Trabalho de Conclusão de Curso da Pós-Graduação em Engenharia de Software pela PUC Minas.

O projeto tem como objetivo apresentar uma proposta de arquitetura tecnológica moderna para viabilizar a transformação digital e a mudança organizacional da empresa fictícia IndTexBR Indústria Têxtil do Brasil S.A., promovendo uma nova forma de atuação no setor têxtil.

---

## 🎯 Objetivo do Sistema

O SIGO visa fornecer uma plataforma integrada que centralize e otimize processos internos, abrangendo áreas como:

Vendas

Gestão de normas e processos

Importação e logística

O sistema foi projetado para melhorar a comunicação e a eficiência operacional entre os diferentes setores da organização, garantindo:

🔒 Segurança no tratamento de informações e dados sensíveis

⚡ Alto desempenho e disponibilidade

🌐 Acesso multiplataforma (desktops, notebooks, tablets e smartphones) via navegador web

🧩 Arquitetura modular e escalável, facilitando manutenção e evolução futura

---

## 🏗️ Arquitetura e Tecnologias Utilizadas

O projeto foi desenvolvido utilizando o padrão MVC (Model-View-Controller), com base no .NET Core 3.1, e segue boas práticas de separação de responsabilidades e persistência de dados.

Principais tecnologias e frameworks:

💻 Linguagem: C#

🧱 Framework: ASP.NET Core 3.1 (MVC)

🗄️ ORM: Entity Framework Core

🧬 Migrations: Controle de versão do banco de dados

🧰 Banco de Dados: SQL Server

🌐 Front-end: Razor Pages (HTML, CSS, JavaScript)

🚀 Arquitetura: MVC com camadas separadas de domínio, aplicação e infraestrutura

---

# 🚀 Como Executar o Projeto

1. Clonar o repositório:
  > git clone https://github.com/Emersonwlg/SIGO

2. Abrir o projeto no Visual Studio
3. Configurar a connection string no arquivo appsettings.json
4. Aplicar as migrations para criar o banco de dados:
  > dotnet ef database update

6. Executar o projeto:
  > dotnet run

---

## 🧩 Estrutura de Pastas (resumo)
SIGO/

│

├── Controllers/

│   ├── ConsultoriaAcessoriaController.cs

│   ├── GestaoNormaExternaController.cs

│   ├── GestaoNormaInternaController.cs

│   └── HomeController.cs

│

├── Models/

│   ├── Cliente.cs

│   ├── Produto.cs

│   └── Pedido.cs

│

├── Views/

│   ├── ArquivoViewModel/

│   ├── BaseViewModel/

│   ├── ConsultoriaAcessoriaViewModel/

│   ├── ErrorViewModel/

│   ├── NormaExternaViewModel/

│   ├── ErrorViewModel/

│   └── TokenViewModel/

│

├── Business/

│   ├── Interfaces/

│   ├── Models/

│   └── Services/

│

├── Data/

│   ├── Context/

│   ├── Mappings/

│   ├── Migrations/

│   └── Repository/



