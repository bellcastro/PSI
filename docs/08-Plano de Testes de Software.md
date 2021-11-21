# Plano de Testes de Software

## T-001 Plano de Testes RF-001

### Objetivo

O objetivo deste plano de testes é garantir que um usuario paciente consiga marcar uma consulta
com o seu nutricionista seguindo o fluxo correto dado pelo requisito RF-001.

### Resultados Esperados

Que o paciente consiga agendar uma consulta com o seu nutricionista aparecendo ela para ser confirmada para ele.

### Passos

1. Criar um usuario paciente;
2. Criar um usuario nutricionista;
3. Vincular usuario paciente ao usuario nutricionista;
4. Logar com usuario paciente;
5. Clicar em "Agendar Consulta" na pagina de consultas;
6. Verificar que no campo "Com" aparecer apenas seu nutricionista;
7. Preencher os campos de "Titulo", "Com", "Tipo" e "Descrição";
8. Selecionar uma data disponivel no calendario;
9. Submeter formulario;
10. Verificar se consulta se encontra em "A confirmar" na conta do paciente;
11. Logar com o usuario nutricionista;
12. Verificar se a consulta se encontra em "A confirmar" em sua conta e se é possivel que ele confirme essa consulta; 

----------

## T-002 Plano de Testes RF-002

### Objetivo

O objetivo deste plano de testes é garantir que ao usuario marcar uma consulta do tipo virtual quando esta mesma é confirmada pelo seu par o sistema crie um link do meet para que essa consulta esteja disponivel à ambos seguindo o fluxo correto dado pelo requisito RF-002.

### Resultados Esperados

Que quando tanto o paciente quanto o nutricionista confirmar uma consulta do tipo virtual seja disponibilizado o link no google meet em sua pagina de detalhes da consulta.

### Passos

1. Criar um usuario paciente;
2. Criar um usuario nutricionista;
3. Vincular usuario paciente ao usuario nutricionista;
4. Logar com usuario nutricionista;
5. Clicar em "Agendar Consulta" na pagina de consultas;
6. Preencher os campos de "Titulo", "Com", "Tipo" como virtual e "Descrição";
7. Selecionar uma data disponivel no calendario;
8. Submeter formulario;
9. Verificar se consulta se encontra em "A confirmar" na conta;
10. Logar com o usuario paciente;
11. Verificar se a consulta se encontra em "A confirmar" em sua conta;
12. Confirmar consulta;
13. Verificar se na pagina de detalhes da consulta esteja disponivel o link;
14. Logar com o nutricionista verificar se na pagina de detalhes desta mesma consulta mostra o mesmo link;

----------

## T-003 Plano de Testes RNF-002

### Objetivo 
Validar o tempo de processamento das requisições do usuário.

### Resultados Esperados
Espera-se que as requisições no site demore menos que 3s para serem atendidas.

### Passos
1. Acessar o site.
2. Acessar 3 páginas do site.
2. Executar 1 requisição por página.
3. Avaliar tempo para processamento das requisições.

## T-004 Plano de Testes RNF-007

### Objetivo

O objetivo deste plano de testes é garantir que um usuario paciente consiga logar com email e senha no sistema conforme o requisito RNF-007.

### Resultados Esperados

Que o paciente consiga logar com email e senha no sistema.

### Passos

Primeiro Acesso:

1. Clicar em registrar;
2. Digitar o nome Completo;
3. Digitar o email;
4. Digitar senha;
5. Confirmar senha;
6. Caso o usuário seja nutricionista, clicar em nutricionista;
7. Clicar em registrar;

Próximos acessos:

1. Clicar em Logar;
2. Digitar email;
3. Digitar Senha;
4. Clicar em Entrar;

## T-005 Plano de Testes RF-008

### Objetivo

O objetivo deste plano de testes é garantir que o nutricionista possa agendar uma consulta vinculada ao seu paciente.

### Resultados Esperados

Que o nutricionista consiga agendar uma consulta com todas as informações necessárias, relacionadas ao seu cliente, tipo de consulta e data e hora.

### Passos

1. Clicar em Agendar Consultas;
2. Digitar o Titulo;
3. Escolher o Tipo de consulta (Virtual ou Presencial);
4. Escolher o participante;
5. Descrever o motivo da consulta;
6. Escolher a data e horário no calendário ao lado;
7. Clicar em Agendar;
8. Ver o cadastro na tela de Consultas á Confirmar;
9. Esperar o paciente confirmar as Proximas Consultas, para ir para tabela de Proximas Consultas;

