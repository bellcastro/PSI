# Programação de Funcionalidades

<a href="2-Especificação do Projeto.md"> Especificação do Projeto</a>
<a href="3-Projeto de Interface.md"> Projeto de Interface</a>
<a href="4-Metodologia.md"> Metodologia</a>
<a href="3-Projeto de Interface.md"> Projeto de Interface</a>
<a href="5-Arquitetura da Solução.md"> Arquitetura da Solução</a>

## Home

![Home](img/modulo-consulta/home.png)

### Realizar cadastro
![tela cadastro](https://user-images.githubusercontent.com/58151252/140613568-216856d5-3652-47a8-98af-d4c615edc0b9.PNG)

Nesta tela você poderá realizar o cadastro no site, através do seu endereço de e-mail, nome e senha criada.

### Realizar login

![tela login](https://user-images.githubusercontent.com/58151252/140613584-9c4443dc-831b-419a-9b29-0340baafcbc4.PNG)

 Com o cadastro realizado, nessa tela é possível efetuar o login com as informações criadas. Satisfazendo o requesito:  **RF-007**

## Implementação Modulo Consultas

O modulo de consultas busca satisfazer os seguintes requisitos: **RF-001**, **RF-002**, **RF-005**, **RF-008**, **RF-009**.
e é implementado as seguites telas

### Consultas

![Consultas](img/modulo-consulta/consultas.png)

Neste tela mostra as consultas ativas do usuario logado em duas subdivisões "Proximas Consultas" que são as proximas consultas do usuario logado, aqui tendo um botão que irá redirecionar para tela de edição de um consulta e o botão de cancelar a consulta.

Na proxima subdivisão temos a consultas à confirmar, quando se cria uma nova consulta ela irá para essa area, aqui mode sugerir uma alteração, confirmar ou até mesmo cancelar essa nova consulta.

### Agendar Consulta

![Agendar Consulta](img/modulo-consulta/nova-consulta.png)

Aqui você podera agendar uma nova consulta, especificando seu titulo, tipo com quem vai ser sua consulta e seu motivo, no calendario especificar o inicio e seu fim. Quando criar ela precisará ser confirmada com seu par.

### Consulta

![Consulta](img/modulo-consulta/consulta.png)

Nesta tela se encontra mais informação sobre a consulta incluindo seu status e o link para a janela do meet caso seja uma consulta virtual.

### Editar Consulta

![Consulta](img/modulo-consulta/editar-consulta.png)

Nesta tela você poderá editar sua consulta, alterar seu nome, descrição e afins, caso altere seu tipo ou sua data será necessario de seu par confirmar novamente a consulta.


## Implementação Modulo de planos e receitas

O modulo de planos e receitas busca satisfazer os seguintes requisitos: **RF-004**, **RF-014**.
e é implementado as seguites telas


### Visualizar planos

![EditarDeletarPlanos](img/modulo-planosEReceitas/Visualizar_planos.jpg)

Nesta tela é possível visualizar todos os planos cadastrados para os usuários, além de navegar para a pagina de edição e/ou visualização e deletar um plano.

### Visualizar plano

![PlanosEReceitas](img/modulo-planosEReceitas/Visualizar_editarplano.jpg)

Nesta tela é possível editar, caso haja permissão e visualizar o plano nutricional selecionado.

### Adicionar plano

![VisualizarReceitas](img/modulo-planosEReceitas/adicionar_plano.jpg)

Nesta tela é possível adicionar um novo plano.

### Visualizar receitas

![VisualizarReceitas](img/modulo-planosEReceitas/Visualizar_receitas.jpg)

Nesta tela é possível visualizar todas receitas do paciente, visualizar os detalhes de uma receita em específico e deletá-las.


### Visualizar receita

![VisualizarReceitas](img/modulo-planosEReceitas/Visualizar_receita.jpg)

Nesta tela é possível visualizar a receita selecionada.

### Adicionar receita

![VisualizarReceitas](img/modulo-planosEReceitas/adicionar_receita.jpg)

Nesta tela é possível adicionar uma nova receita.

## Ficha
### Index
![Ficha](img/modulo-ficha/index.jpg)
Nesta tela voce poderá ver suas fichas já cadastrasdas, e pondendo escolher ser redirecionado para uma pagina para realizar o cadastro de outras fichas.
### Adicionar ficha
![Ficha](img/modulo-ficha/telacadastro.jpg)
Nesta tela você poderá ver os campos necessários para cadastro, com informações necessárias para sua ficha. Nela também após preenchimento de todos os campos você poderá cadastrar todos os dados no banco de dados. 

## Fale Conosco
### Index
![Fale Conosco](img/modulo-comunicacao/index.png)
Nesta tela voce poderá ser redirecionado para uma pagina afim de encaminhar um email. Voce tambem poderá clicar no icone do whatsapp para ser redirecionado para o chat neste aplicativo.
### Adicionar mensagem
![Fale Conosco](img/modulo-comunicacao/create.png)
Você poderá adicionar um texto, contendo seu telefone, descrição e seu nome, para receber um contato posterior. Voce tambem poderá clicar no icone do whatsapp para ser redirecionado para o chat neste aplicativo.

## Configurações
### Alterar Nome
![Configurações](img/modulo-configurações/AlterarCadastro.jpeg)
Nesta tela você poderá realizar a alteração do seu nome no site.
### Alterar Senha
![Configurações](img/modulo-configurações/AlterarSenha.jpeg)
Nesta tela você será possível realizar a alteração da senha, a partir da sua senha anterior.
### Desativar conta
![Configurações](img/modulo-configurações/DesativarConta.jpeg)
Nesta tela você poderá desativar sua conta permanentemente. 
### Usuário e Nutricionista
![Configurações](img/modulo-configurações/gerenciarPacientes.jpeg)
Nesta tela você poderá vincular um usuário ao nutricionista, atendendo o requisito funcional 7.
### Informações Pessoais
![Configurações](img/modulo-configurações/InformaçõesPessoais.jpeg)
Nesta tela é possível fazer o download dos seus dados pessoais antes de desativar a conta
### Informações Pessoais
![Configurações](img/modulo-configurações/excluirConta.jpeg)
Nesta tela você confirmará a exclusão da sua conta






