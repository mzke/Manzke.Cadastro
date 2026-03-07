# CLAUDE.md

Este arquivo fornece orientações ao Claude Code (claude.ai/code) ao trabalhar com o código deste repositório.

## Visão Geral do Projeto

**Manzke.Cadastro** é uma biblioteca NuGet em C# que fornece utilitários de validação e formatação para documentos de cadastro brasileiros (CPF, CNPJ) e dados pessoais relacionados. Framework alvo: .NET 8.0.

## Comandos de Build

```bash
dotnet build
dotnet pack --configuration Release
```

Não existe projeto de testes neste repositório.

## Arquitetura

Todas as classes são `static` com métodos estáticos — sem instanciação, sem estado, sem DI. Os métodos removem a formatação antes de processar as strings de dígitos brutos.

### Módulos

- **`Cpf`** — Valida (algoritmo de dígitos verificadores) e formata CPF para `XXX.XXX.XXX-XX`
- **`Cnpj`** — Valida e formata CNPJ para `XX.XXX.XXX/XXXX-XX`; expõe os helpers `IsMatriz()` e `Raiz()`
- **`Telefone`** — Formata números de telefone brasileiros para `(XX)XXXXX-XXXX`
- **`Format`** — Fachada que combina os módulos acima:
  - `CpfOuCnpj()`: detecta automaticamente pela quantidade de dígitos (11 = CPF, 14 = CNPJ)
  - `Capitalizar()`: capitalização simples via `CultureInfo`
  - `Capitalizar2()`: capitalização com suporte ao português (preposições em minúsculo: de, do, da, dos, das, em, etc.)
  - `Truncar()`: limite fixo de caracteres
- **`Util`** — `IsNumeric()` e validação de e-mail conforme RFC 5322 via regex
- **`Cno`** — Placeholder vazio, ainda não implementado

### Convenções importantes

- Strings de entrada são aceitas com ou sem caracteres de formatação (`.`, `-`, `/`); os métodos os removem antes da validação.
- `Cpf.IsCPF()` chama `Util.IsNumeric()` primeiro; `Cpf.Format()` não valida, apenas formata pelo comprimento.
- `Format.Capitalizar2()` sempre capitaliza a primeira palavra independentemente das regras de preposição.
