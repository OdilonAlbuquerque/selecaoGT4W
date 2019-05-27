# PROCESSO SELETIVO GT4W

O projeto está publicado em: https://top-level-grip.000webhostapp.com/

# Front-end
Foi utilizado o framework Vue.JS e Bootstrap 4

Instalação:
Pré-requisito: Node.js

Navegar até a pasta (frontApi) do projeto e utilizar o NPM para rodar: npm run serve
Para preparar o pojeto para a publicação, que será gerado na pasta dist: npm run build

OBS: No arquivo ~\frontEnd\src\services\config.js, fica a configuração do endereço da API (IBGE e Back-end). 

OBS2: A seleção da UF é carregado dinamicamente da API do IBGE.

# Back-end
Desenvolvido em Asp.net C# e banco de dados SQL Server hospedado em nuvem (Azure), na pasta DB possui o script de criação do banco de dados.

OBS: No arquivo ~\backEnd\WebAPI\Web.config fica a <connectionStrings> com a configuração de conexão com o banco de dados.

A api está publicada no endereço: https://gtapiweb.azurewebsites.net/api/Clientes
