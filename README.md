API Back-end em .NET Core
Este repositório contém uma API Back-end construída em .NET Core para um projeto desenvolvido na disciplina de Projetos Integrados do curso de pós-graduação em Desenvolvimento Web Full-Stack da PUC Minas. A API utiliza o Entity Framework como ORM para se conectar ao banco de dados MySQL hospedado no RDS da Amazon. Além disso, integra a API do Google Maps para geocodificação e criação de rotas.

Pré-requisitos
.NET Core SDK
MySQL
Conta no Google Cloud Platform com acesso à API do Google Maps
Configuração
Clone este repositório em sua máquina local:

bash
git clone https://github.com/LeandroFSimeao/DMS-Back.git
No diretório raiz do projeto, crie um arquivo chamado appsettings.json e preencha-o com as informações de configuração necessárias:

json
"ConnectionStrings": {
    "DMSConnection": "server=awseb-e-ipc25jndxi-stack-awsebrdsdatabase-kcei9xodsrst.c2dzjgejuso2.us-east-1.rds.amazonaws.com;port=3306;database=ebdb;user=root;password=senhadobanco"
  },
  "apiKey": "AIzaSyBFgNRhNl4qILL5Bnabx67zweD_vU4Rso8",
  "origem": "-19.9592817,-44.0331177"

Abra o terminal e navegue até o diretório raiz do projeto. Execute os seguintes comandos para criar o banco de dados e executar as migrações:

bash
dotnet ef database update
Inicie a API executando o seguinte comando:

bash
dotnet run
A API será executada localmente em http://localhost:5342.

Uso
A API fornece endpoints para gerenciar entidades relacionadas ao projeto. Consulte a documentação detalhada da API para obter mais informações sobre os endpoints e as operações disponíveis.

Documentação da API
A documentação da API está disponível em http://dmsback-env.eba-dsmce2qe.us-east-1.elasticbeanstalk.com/swagger/index.html, após iniciar a API localmente. A documentação descreve os endpoints disponíveis, os parâmetros necessários e as respostas esperadas.
