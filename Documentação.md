# Especificações do Projeto

<span style="color:red">Pré-requisitos: <a href="1-Documentação de Contexto.md"> Documentação de Contexto</a></span>

Definição do problema e ideia de solução a partir da perspectiva do usuário. É composta pela definição do  diagrama de personas, histórias de usuários, requisitos funcionais e não funcionais além das restrições do projeto.

Apresente uma visão geral do que será abordado nesta parte do documento, enumerando as técnicas e/ou ferramentas utilizadas para realizar a especificações do projeto

## Personas

#### Persona 1:

   Guilherme tem 21 anos, trabalha na area de TI e esta cursando Sistemas de Informação. É 
praticante de musculação ha 5 anos, possui uma agenda apertada e gostaria de meter o 
shape divino e cansado da mesma dieta gostaria de diversificar a alimentação.   

#### Persona 2:

   Arthur com 22 anos, trabalha com marketing digital edevido a pandemia acabou tendo uma 
uma rotina de vida mais sedentaria e uma dieta não saudavel, procurando uma maneira mais 
simples de agendar e tratar com um nutricionista pois prefere agendar online do que 
agendar por telefone e afins.

#### Persona 3:

   Cristiane com 23 anos recem formada na universidade UNA, recem chegada no mercado de 
trabalho ainda não possui investimento/renda suficiente para abrir seu proprio 
consultorio, dessa forma esta buscando atender seus pacientes de uma forma simples e 
online trabalhando em home-office quando possivel.

#### Persona 4:

   Ana Julia com 21 anos possui Lupus e possui muitas muitas restrições alimentares devido a
seus medicamentos, isso acarreta em uma dificuldade em massa magra. Ela acha que a 
maneira atual de acompanhamento de seu nutricionista muito complicado e confuso alem do 
agendamento que é oneroso e lento. Portanto ela procura uma forma mais facil tanto de ser 
atendida quanto de agendar suas consultas.

#### Persona 5:

   Jennifer com 35 anos, nutricionista e gestante, devido a gravidez não esta fazendo 
atendimento presenciais e por isso busca pacientes que tenham um perfil para fazer 
atendimento online e remoto.

#### Persona 6:
   
  José com seus 64 anos, é tecnologicamente sabio e não possui problemas a utilizar sistemas
online. Possui dois problemas de saude principais: Dificuldade de locomoção e hipertensão.
Por conta disso precisa de acompanhamento semanal o que torna mais caro o atendimento à 
domicilio procura uma forma de se atendido sem precisar sair de casa.

## Histórias de Usuários

Com base na análise das personas forma identificadas as seguintes histórias de usuários:

|EU COMO... `PERSONA`| QUERO/PRECISO ... `FUNCIONALIDADE`                                                    |PARA ... `MOTIVO/VALOR`                    |CASO DE USO ... `CASO DE USO`                    |
|--------------------|---------------------------------------------------------------------------------------|-------------------------------------------|-------------------------------------------|
|Usuário do sistema  | Agendar uma consulta tanto presecial quanto online                                    | Realizar uma consulta                     | Gerenciamento de agendamento de consulta |
|Usuário do sistema  | Logar com email e senha no sistema                                                    | Acessar o sistema de maneira segura       | Gerenciamento de usuário | 
|Usuário do sistema  | Ser excluido ou anonimizado no sistema                                                | Exercer meu direito de ser esquecido | Gerenciamento de usuário |
|Usuário do sistema  | Ser lembrado de uma consulta que está por vir                                         | Não perder a consulta | Gerenciamento de comunicação |
|Usuário do sistema  | Enviar e receber mensagens                                                            | Manter uma conversa | Gerenciamento de comunicação |
|Administrador       | Associar e desassociar um paciente de nutricionistas                                  | Garantir que nenhum paciente esteja com um nutricionista não que | Gerenciamento de paciente |
|Paciente            | Preencher minha ficha de informação                                                   | Garantir que meu nutricionista tenha as informações necessarias para a consulta | Cadastro ficha médica |
|Paciente            | Ver historico de planos nutricionais e receitas                                       | Relembrar o que me foi passado       | Gerenciamento de paciente |
|Nutricionista       | Criar um plano nutricional para cada paciente                                         | Que tanto ele quanto eu possa acompanhar de maneira organizada seu desenvolvimento | Cadastro do plano nutricional |
|Nutricionista       | Aceitar ou não um agendamento de consulta                                             | Que consiga encaixar em minha agenda | Gerenciamento de agendamento de consultas |
|Nutricionista       | Escrever posts para a população em geral                                              | Que duvidas simples já sejam sanadas sem necessidade de consulta | Gerenciamento de conteúdo |
|Nutricionista       | Incluir meus pacientes a partir de um usuario                                         | Cadastrar meus pacientes | Gerenciamento de usuários |
|Nutricionista       | Fazer anotações na ficha de meu paciente que apenas ele podera ver.                   | Marcar anotações importantes sobre as consultas com meus pacientes | Gerenciamento de pacientes |
|Nutricionista       | Criar receitas para seu paciente.                                                     | Que meu paciente possa ser medicado | Gerenciamento do histórico do paciente |
|Nutricionista       | Pesquisar informações sobre determinado remedio acessando o banco de dados da anvisa. | Que me lembre as informações sobre um determinado remedio | Gerenciamento de conteúdo |
|Nutricionista       | Ver historico de planos nutricionais e receitas de meus pacientes                     | Para garantir que não estou passando algo que ele é alergico | Gerenciamento do histórico de pacientes |


## Requisitos

As tabelas que se seguem apresentam os requisitos funcionais e não funcionais que detalham o escopo do projeto.

### Requisitos Funcionais

|ID    | Descrição do Requisito  | Prioridade |
|------|-----------------------------------------|----|
|RF-001| Permitir que o usuário paciente agendar uma consulta com uma nutricionista.                                             | ALTA  | 
|RF-002| Permitir que ao agendar uma consulta o sistema ira criar uma sala no google meet.                                       | ALTA  |
|RF-003| Permitir que o paciente preencha sua ficha com suas preferencias e informações.                                         | ALTA  |
|RF-004| Permitir que o nutricionista crie um plano nutricional para cada paciente.                                              | ALTA  |
|RF-005| Permitir que o nutricionista aceite ou não um agendamento de consulta.                                                  | ALTA  |
|RF-006| Permitir que os usuarios possam logar com email e senha no sistema.                                                     | ALTA  |
|RF-007| Permitir que o nutricionista possa incluir seus pacientes a partir de um usuario.                                       | ALTA  |
|RF-008| Permitir que o nutricionista possa agendar uma consulta com seu paciente.                                               | ALTA  |
|RF-009| Enviar um email relembrando de uma consulta para todas as partes envolvidas.                                            | BAIXA |
|RF-010| Fornecer um canal de comunicação entre nutricionista e paciente.                                                        | MÉDIA |
|RF-011| Permitir que nutricionista faça anotações na ficha de seu paciente que apenas ele podera ver.                           | ALTA  |
|RF-012| Permitir um usuario administrador possa associar e desassociar um paciente de seu nutricionista.                        | MÉDIA |
|RF-013| Permitir um usuario possa ser excluido ou anonimizado no sistema                                                        | MÉDIA |



### Requisitos não Funcionais

|ID     | Descrição do Requisito  |Prioridade |
|-------|-------------------------|----|
|RNF-001| O sistema deve ser responsivo para rodar em um dispositivos móvel | MÉDIA | 
|RNF-002| Deve processar requisições do usuário em no máximo 3s |  BAIXA | 
|RNF-003| O sistema deve prover ao usuário as funcionalidades da maneira mais usual possível permitindo que sejam necessárias poucas interações para atingir o objetivo. |	ALTA |
|RNF-004| O usuário deve ser capaz de acessar o sistema através das plataformas e navagadores compatíveis de acordo com informações disponibilizadas no site.	| ALTA |
|RNF-005| O sistema deve usar os recursos disponibilizados pelos navegadores de forma exata as suas necessidades, não desperdiçando a utilização de nenhum destes recursos, evitando o desperdício de informações e com baixo tempo de resposta. | ALTA |
|RNF-006| O usuário deve ter um retorno visual quanto ao carregamento das informações durante o uso. | MÉDIA |
|RNF-007| As informações sensíveis dos dados dos usuários devem ser mantidos em sigilo e tratados de acordo com a LGPD (Lei de acessso e proteção de dados pessoais) permitindo o acesso apenas as informações necessáras inerentes as consultas. | ALTA |
|RNF-008| O sistema deverá possuir controle de acesso por usuário e senha. | ALTA |
|RNF-009| O sistema deverá registrar logs afim registrar eventos e tratar eventuais falhas. | BAIXA |
|RNF-010| O banco de dados utilizado deverá ser o SqLite. | BAIXA |

Com base nas Histórias de Usuário, enumere os requisitos da sua solução. Classifique esses requisitos em dois grupos:

- [Requisitos Funcionais
 (RF)](https://pt.wikipedia.org/wiki/Requisito_funcional):
 correspondem a uma funcionalidade que deve estar presente na
  plataforma (ex: cadastro de usuário).
- [Requisitos Não Funcionais
  (RNF)](https://pt.wikipedia.org/wiki/Requisito_n%C3%A3o_funcional):
  correspondem a uma característica técnica, seja de usabilidade,
  desempenho, confiabilidade, segurança ou outro (ex: suporte a
  dispositivos iOS e Android).
Lembre-se que cada requisito deve corresponder à uma e somente uma
característica alvo da sua solução. Além disso, certifique-se de que
todos os aspectos capturados nas Histórias de Usuário foram cobertos.

## Restrições

O projeto está restrito pelos itens apresentados na tabela a seguir.

|ID| Restrição                                             |
|--|-------------------------------------------------------|
|RT- 001| O projeto deve ser entregue e finalizado até o dia 29/11/2021|
|RT- 002| As definições e desenvolvimento deverão ser entregues a cada fase, como Template, Desenvolvimento e Testes.|
|RT- 003| Será necessário acompanhamento de uma profissional nutricionista para avaliações e apoio.|
|RT- 004|O projeto deverá ter no mínimo uma reunião semanal para acompanhamento do desenvolvimento geral.|
|RT- 005|Os desenvolvedores terão de sempre atualizar suas atividades no GitHub.|
|RT- 006|O trabalho deve ser entregue de forma funcional.|




> **Links Úteis**:
> - [O que são Requisitos Funcionais e Requisitos Não Funcionais?](https://codificar.com.br/requisitos-funcionais-nao-funcionais/)
> - [O que são requisitos funcionais e requisitos não funcionais?](https://analisederequisitos.com.br/requisitos-funcionais-e-requisitos-nao-funcionais-o-que-sao/)
