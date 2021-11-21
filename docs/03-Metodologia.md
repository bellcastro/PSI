
# Metodologia

<span style="color:red">Pré-requisitos: <a href="2-Especificação do Projeto.md"> Documentação de Especificação</a></span>

Descreva aqui a metodologia de trabalho do grupo para atacar o problema. Definições sobre os ambiente de trabalho utilizados pela  equipe para desenvolver o projeto. Abrange a relação de ambientes utilizados, a estrutura para gestão do código fonte, além da definição do processo e ferramenta através dos quais a equipe se organiza (Gestão de Times).

## Controle de Versão

A ferramenta de controle de versão adotada no projeto foi o
[Git](https://git-scm.com/), sendo que o [Github](https://github.com)
foi utilizado para hospedagem do repositório.

O projeto segue a seguinte convenção para o nome de branches:

- `master`: versão estável já testada do software
- `testing`: versão em testes do software

Quanto à gerência de issues, o projeto adota a seguinte convenção para
etiquetas:

- `documentation`: melhorias ou acréscimos à documentação
- `bug`: uma funcionalidade encontra-se com problemas
- `enhancement`: uma funcionalidade precisa ser melhorada
- `feature`: uma nova funcionalidade precisa ser introduzida

### Git Flow

Para cada issue, ou seja, cada tarefa é criada uma branch nova, com o nome padrão de:

`{tipo_da_etiqueta}/ISSUE-{numero_da_issue}_Nome`

Ex: `feature/ISSUE-24_AdicioandoTelas`

Teje terminado sua codificação você vai abrir um pull request para a branch devcom um nome qualquer, lembre-se de associar a sprint em milestone.

Deve sempre colocar no comentario close #{numero_da_issue} para que o processo seja automatizado. A PR deve ter pelo menos uma aprovação para que seja mergida na testing.

### Fluxo da tarefa

Temos 4 status para cada tarefa,

- `A Fazer`: Tarefa não está sendo realizada.
- `Fazendo`: Tarefa está sendo realizada por um dos integrantes da equipe.
- `Revisão`: Tarefa está sendo revisada por n integrantes sendo o mínimo 1.
- `Feito`:   Tarefa se encontra mergida na testing


## Gerenciamento de Projeto

### Divisão de Papéis

- Arthur Fernandes - Scrum Master/Dev Fullstack
- Guilherme Ventura - Dev Backend
- Isabella Pimenta - Product Manager/Dev Frontend
- Maria Fernanda - Product Owner/Dev Frontend
- Rafael Siqueira - Dev Backend 
- Reinaldo Ruggiere - Dev Fullstack

### Processo

Estamos utilizando o Github Projects para fazermos o gerenciamento do projeto. Para defirnirmos nossas sprints utilizamos milestones.

### Ferramentas

As ferramentas empregadas no projeto são:

- Editor de Código: Visual Studio/Visual Code
- Ferramentas de comunicação: WhatsApp
- Ferramentas de desenho de tela: Figma

O editor de código foi escolhido porque ele possui uma integração com o
sistema de versão. As ferramentas de comunicação foram selecionadas devido a facilidade e experiência de uso. Por fim, para criar diagramas utilizamos essa ferramenta por melhor captar as necessidades da nossa solução.

> **Ferramentas que auxiliarão no gerenciamento**: 
> - [WhatsApp](https://whastapp.com/)
> - [Github](https://github.com/)
> - [Figma](https://figma.com/)
> - [Visual Studio](https://visualstudio.microsoft.com/)