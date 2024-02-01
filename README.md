# Google Sheets Console App

## Visão Geral
Este é um aplicativo desenvolvido em C# .NET 8.0 que interage com a API do Google Sheets. Ele permite avaliar e atualizar dados em uma planilha do Google Sheets. A aplicação é especialmente útil para monitorar o desempenho dos alunos.

## Funcionalidades
- Integração com a API do Google Sheets.
- Avaliação do desempenho dos alunos com base nos dados da planilha.
- Atualização automática dos dados na planilha.

## Como Usar
1. Clone o repositório para o seu ambiente local.
2. Navegue até a pasta `Tunts.Rocks`.
3. Execute o comando `dotnet run`.
4. Será solicitado que você insira o ID da planilha quando o programa iniciar.
5. Em seguida, o programa solicitará o caminho para o seu arquivo JSON de credenciais do Google (consulte a documentação do Google para obter instruções sobre como gerar este arquivo).
6. Após fornecer o ID da planilha e o caminho do arquivo JSON de credenciais, o aplicativo tentará estabelecer conexão com a planilha. Se for bem-sucedido, os dados serão avaliados e atualizados na planilha.

**Nota:** Ao colar as informações, lembre-se de remover as aspas ao redor delas.

## Requisitos
- .NET 8 SDK instalado.
- Conta do Google com acesso à API do Google Sheets e permissão para acessar a planilha desejada.
- Planilha pública para leitura e edição

## Documentação Adicional
Para obter mais informações sobre como gerar o arquivo JSON de credenciais do Google, consulte a [documentação oficial do Google](https://developers.google.com/workspace/guides/create-credentials).

