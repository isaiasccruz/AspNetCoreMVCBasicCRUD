# AspNetCoreMVCBasicCRUD
Uma aplicação feita em asp.net core / .net core 2.2 usando o padrão MVC  com Razor, Injeção de Dependencia Unity

O projeto consiste em uma aplicação CRUD para gerenciamento de leiões onde o Existem 2 tipos de perfis de usuário:
1--> Admin
2-- Usuario

O Usuário do tipo Admin pode criar leilões, editar leilões e deletar leiões. Também pode criar usuários, editar usuários e deletar usuários.
O Usuário do tipo Usuario pode criar outros leiloes, editar mas nao pode deletar e não tem acesso ao menu de gerenciamento dos usuários do sistema.

A persistencia de dados da aplicação foi desenvolvida para MSSql e existe um script na pasta da solution **MSSQL_Template** onde em um MSSql server de testes voce poderá criar uma database com suas tabelas padrão além de inserts iniciais para existencia de usuário base adm e dados de perfil. O arquivo é o **dbLeilaoTesteInit.sql**

A validação de senha é construida na logica da Classe **Criptografia.cs** em **Infra.UtilsCore**

A senha inicial do script do banco de dados é uma string já criptografada para **"123456"**

Os dados de connection strings estão na classe: **DapperContexto.cs** no projeto: **Infra.ContextoCore** onde a classe retorna do arquivo de configuração **Infra.ContextoCore.dll.config** que fica na pasta **ConfigFile da solution**

Os dados da connectionstring devem ser devidamente configurados uma vez que o script de banco para o servidor destino for criado!

O deploy da aplicação foi feito em testes em um ambiente Docker em Ubuntu 18.04.

O Dockerfile já está preparado pela solution e a imagem é construida com sucesso:

~~~
Step 21/21 : ENTRYPOINT ["dotnet", "PageBasicCRUDAspNETMVCAuctionApp.dll"]
 ---> Using cache
 ---> 68a1fcf7175c
Successfully built 68a1fcf7175c
Successfully tagged pagetest:v1
~~~

O projeto todo foi desenvolvido no VisualStudio 2017.
