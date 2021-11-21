# Registro de Testes de Software

## Relatorio de Testes

### T-001 Teste de Agendar consulta como paciente;

### Artefatos

**1. Criar um usuario paciente**
![Criar um usuario paciente](img/testes/teste-01/1.png)

**2. Criar um usuario nutricionista**
![Criar um usuario nutricionista](img/testes/teste-01/2.jpg)

**3. Vincular usuario paciente ao usuario nutricionista**
![Vincular usuario paciente ao usuario nutricionista](img/testes/teste-01/3.png)

**4. Logar com usuario paciente**
![Logar com usuario paciente](img/testes/teste-01/4.png)

**5. Clicar em "Agendar Consulta" na pagina de consultas**
![Clicar em "Agendar Consulta" na pagina de consultas](img/testes/teste-01/5.png)

**6. Verificar que no campo "Com" aparecer apenas seu nutricionista**
![Verificar que no campo "Com" aparecer apenas seu nutricionista](img/testes/teste-01/6.png)

**7. Preencher os campos de "Titulo", "Com", "Tipo" e "Descrição"**

![Preencher os campos de "Titulo", "Com", "Tipo" e "Descrição](img/testes/teste-01/7.png)

**8. Selecionar uma data disponivel no calendario**

![Preencher os campos de "Titulo", "Com", "Tipo" e "Descrição](img/testes/teste-01/7.png)

**9. Submeter formulario**

![Preencher os campos de "Titulo", "Com", "Tipo" e "Descrição](img/testes/teste-01/7.png)

**10. Verificar se consulta se encontra em "A confirmar" na conta do paciente**

![Verificar se consulta se encontra em "A confirmar" na conta do paciente](img/testes/teste-01/10.png)

**11. Logar com o usuario nutricionista**

![Verificar se consulta se encontra em "A confirmar" na conta do paciente](img/testes/teste-01/11.png)

**12. Verificar se a consulta se encontra em "A confirmar" em sua conta e se é possivel que ele confirme essa consulta**

![Verificar se a consulta se encontra em "A confirmar" em sua conta e se é possivel que ele confirme essa consulta](img/testes/teste-01/12.png)

### Resultado

O teste foi um sucesso! Embora foi notado que o front-end não esta fazendo a mesma validação que o backend.

------

### T-002 Teste de Confimar que o sistema esta criando links do google meet;

### Artefatos

**1. Criar um usuario paciente**
![Criar um usuario paciente](img/testes/teste-01/1.png)

**2. Criar um usuario nutricionista**
![Criar um usuario nutricionista](img/testes/teste-01/2.jpg)

**3. Vincular usuario paciente ao usuario nutricionista**
![Vincular usuario paciente ao usuario nutricionista](img/testes/teste-01/3.png)

**4. Logar com usuario paciente**
![Logar com usuario paciente](img/testes/teste-01/11.png)

**5. Clicar em "Agendar Consulta" na pagina de consultas**
![Clicar em "Agendar Consulta" na pagina de consultas](img/testes/teste-01/5.png)

**6. Preencher os campos de "Titulo", "Com", "Tipo" e "Descrição"**

![Preencher os campos de "Titulo", "Com", "Tipo" e "Descrição](img/testes/teste-01/7.png)

**7. Selecionar uma data disponivel no calendario**

![Preencher os campos de "Titulo", "Com", "Tipo" e "Descrição](img/testes/teste-01/7.png)

**8. Submeter formulario**

![Preencher os campos de "Titulo", "Com", "Tipo" e "Descrição](img/testes/teste-01/7.png)

**9. Verificar se consulta se encontra em "A confirmar" na conta**

![Verificar se consulta se encontra em "A confirmar" na conta do paciente](img/testes/teste-01/10.png)

**10. Logar com o usuario paciente**

![Logar com o usuario paciente](img/testes/teste-01/4.png)

**11. Verificar se a consulta se encontra em "A confirmar" em sua conta e se é possivel que ele confirme essa consulta**

![Verificar se a consulta se encontra em "A confirmar" em sua conta e se é possivel que ele confirme essa consulta](img/testes/teste-01/12.png)

**12. Confirmar consulta**

![Confirmar consulta](img/testes/teste-02/12.png)

**13. Verificar se na pagina de detalhes da consulta esteja disponivel o link**

![Verificar se na pagina de detalhes da consulta esteja disponivel o link](img/testes/teste-02/13.png)

**14. Logar com o nutricionista verificar se na pagina de detalhes desta mesma consulta mostra o mesmo link**

![Logar com o nutricionista verificar se na pagina de detalhes desta mesma consulta mostra o mesmo link](img/testes/teste-02/13.png)

### Resultado

O teste foi um sucesso! O link apareceu devidamente para ambos, foi notado entretando que o sistema não comunica que esta realizando
uma ação quando esta confirmando uma consulta, uma melhoria para o futuro é talvez mostrar um pop up dizendo que está "Processando"

----------------------------

## Avaliação

Cada ponto forte e fraco de cada teste foi ressaltado em seu reespectivo teste na area de *Resultado*

### T-003 Teste para processar requisições do usuário em no máximo 3s

## Artefatos

**1. Acessar o site.**
Página: Consultas - NutriMais (nutri-mais.herokuapp.com)
![Carregamento da página Consultas](img/testes/teste-03/consultas003.jpg)
**2. Executar 1 requisição.**
(Create)
![Carregamento da Create Consultas](img/testes/teste-03/consultas002.jpg)
**3. Avaliar tempo para processamento das requisições.**


![Carregamento da página](img/testes/teste-03/consultas003.jpg)
Com esse relatório gerado através do Lighthouse 8.4.0 pode-se observar que o tempo para a página tornar-se iterativa é de 1.9s. Este tempo refere-se ao tempo de carregamento da página. 
![Carregamento da página](img/testes/teste-03/consultas004.jpg)
Tempo para o evento de Create de 153.60 ms.

**1. Acessar o site.**
Página: Fale Conosco - NutriMais (nutri-mais.herokuapp.com)
![Carregamento da página Fale Conosco](img/testes/teste-03/FaleCon001.jpg)
**2. Executar 1 requisição.**
**3. Avaliar tempo para processamento das requisições.**
![Carregamento inicial da página](img/testes/teste-03/FaleCon002.jpg)
Tempo para o evento de carregamento da página de 0.8s.


**1. Acessar o site.**
Página: Home Page - NutriMais (nutri-mais.herokuapp.com)
**2. Avaliar tempo para processamento das requisições.**

![Carregamento inicial da página](img/testes/teste-03/Home001.jpg)
Tempo para o evento de carregamento da página de 0.8s.
![Carregamento inicial da página](img/testes/teste-03/Home002.jpg)
Tempo para a renderização da imagem da página de Home em 2.92s.
![Carregamento inicial da página](img/testes/teste-03/Home003.jpg)
Mesma página no smartphone (teste realizado por meio da ferramenta thinkwithgoogle). 

### Resultado

O teste foi bem sucessido e o tempo para os testes foram inferiores a 3s.

### T-004 Teste do Usuário Logar no Sistema;

### Artefatos

**1. Pagina Inicial**

![Pagina Inicial](img/testes/teste-04/PaginaInicial.jpg)

**2. Criar um usuario paciente**

![Cadastro Paciente](img/testes/teste-04/CadastrarUsuario.jpg)

**3. Criar um usuario nutricionista**

![Cadastro Nutricionaista](img/testes/teste-04/CadastrarNutri.jpg)

**4. Logar**

![Logar Usuario](img/testes/teste-04/Login.jpg)

### Resultado

O teste foi bem sucessido e o usuário foi logado no sistema.


### T-005 Teste para cadastro de agendamento do Nutricionista;

### Artefatos

**1. Pagina Consultas**

![Pagina Consultas](img/testes/teste-05/consultas.jpg)

**2. Pagina Consultas**

![Botao Agendamento](img/testes/teste-05/botao-agendamento.jpg)

**3. Pagina Cadastro Agendamento**

![Tela Agendamento](img/testes/teste-05/tela-agendamento.jpg)

**4. Verificação tipo consulta**

![Tipo consulta](img/testes/teste-05/tipo-virtual.jpg)

**5. Verificação Paciente**

![Verificação Paciente](img/testes/teste-05/tipo-paciente.jpg)

**6. Escolha de horário Agendamento**

![Horario Agendamento](img/testes/teste-05/dia-agendamento.jpg)

**7. Envio dos dados**

![Envio dos dados](img/testes/teste-05/envio-dados.jpg)

### Resultado

Realizado o teste foi validado o bom funcionamento de todas as estruturas, de dados e calendário, além do funcionamento de relacionamento entre o cliente e o nutricionist, podendo ser concluído como bem sucessido e o consultada bem cadastrada no sistema.
