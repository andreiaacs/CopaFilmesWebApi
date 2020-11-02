# Copa Filmes Web API

API para campeonato de filmes de acordo com 8 filmes selecionados e suas respectivas notas para ser consumida por aplicações web e mobile.

## 🚀 Começando

Essas instruções permitirão que você obtenha uma cópia do projeto em operação na sua máquina local para fins de desenvolvimento e teste.

### 📋 Pré-requisitos

1. VS Code ou Visual Studio com suporte para .Net Core
2. Postman

### 🔧 Instalação

Após clonar o projeto, entrar na pasta do mesmo pelo CMD e executar os seguintes comandos:

1. dotnet restore
2. dotnet build
3. dotnet run

Abrir o postman e fazer as seguintes requisições:

* Para buscar a lista com todos os filmes, fazer uma requisição GET para o link: https://localhost:5001/api/Movies
* Para iniciar um campeonato enviar um POST com 8 dos filmes retornados no passo anterior para o mesmo link.


## 📦 Desenvolvimento

Está API encontra-se deployada no azure (https://copafilmesapi.azurewebsites.net/api/Movies),
e um exemplo de aplicação utilizando ela, encontra-se em (https://github.com/andreiaacs/copa-filmes-front).


## ✒️ Autores

Mencione todos aqueles que ajudaram a levantar o projeto desde o seu início

* **Andréia Alencar** - *Trabalho Inicial* - [andreiaacs](https://github.com/andreiaacs)






