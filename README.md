# WinForm Assessment Application

Este repositório contém a aplicação Windows Forms com autenticaç]ao, consumo de API e gerenciamento de veículos. Siga as instruções abaixo para clonar, configurar e rodar o projeto.

## Pré-requisitos

- [Visual Studio 2022](https://visualstudio.microsoft.com/)
- [.NET 6](https://dotnet.microsoft.com/)
- [Git](https://git-scm.com/)

## Passos para Configuração

### 1. Clonar o Repositório

Primeiro, clone o repositório para o seu ambiente local:

```bash
git clone https://github.com/nicolaujoao1/WinFormAssissment.git 
```

## 2. Build do Projeto

Após clonar o repositório, siga os passos abaixo para realizar o build do projeto no Visual Studio:

1. **Abra o Visual Studio**.
2. No menu superior, selecione **Arquivo > Abrir > Projeto/Solução...** e localize o arquivo `.sln` dentro do diretório clonado.
3. No **Gerenciador de Soluções**, clique com o botão direito sobre a solução e selecione **Build Solution** ou pressione `Ctrl+Shift+B` para compilar o projeto.

## 3. Selecionar Projeto de Inicialização

Antes de executar a aplicação, defina `AssessmentApp.WinForm` como o projeto de inicialização:

1. No **Gerenciador de Soluções**, clique com o botão direito no projeto `AssessmentApp.WinForm`.
2. Selecione **Definir como Projeto de Inicialização**.

## 4. Configurar o Banco de Dados

Para configurar o banco de dados, siga os passos abaixo:

1. Navegue até o diretório do projeto `AssessmentApp.Data`.
2. No Visual Studio, vá para **Ferramentas > Gerenciador de Pacotes NuGet > Console do Gerenciador de Pacotes**.
3. No **Console do Gerenciador de Pacotes**, selecione `AssessmentApp.Data` como o projeto padrão.
-Antes de aplicar as migrações ao banco de dados, certifique-se de que a string de conexão está configurada corretamente. A string de conexão pode ser encontrada na classe `ConnectionString` conforme o exemplo abaixo:

```csharp
public static class ConnectionString
{
    public const string connectionString = @"Server=localhost;Database=Db_Task_App;User=root;Password='';";
}
```
4. Execute o seguinte comando:
   ```bash
   Update-Database
