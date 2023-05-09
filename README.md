# **PAY PROJECT**

Este é um projeto desenvolvido em C# para a disciplina de Programação Orientada a Objetos. O objetivo é implementar um sistema de pagamento para uma loja virtual, utilizando as classes definidas no diagrama de classes UML disponibilizado.

## Equipe
* [Gabriel Marchetti](https://github.com/Jabriel122)
* [Guilherme Cézar](https://github.com/G648)
* [Guilherme Sousa](https://github.com/GSolivier)
* [Maurício](https://github.com/Marqzzs)
* [Pedro Henrique](https://github.com/LeonKene-hub)
* [Wender de Castro](https://github.com/wenderdecastro)

## Diagrama de classes UML
![Diagrama UML](https://lh6.googleusercontent.com/fL_JtS8IWFST_pU2pqDl3FeR-kSXudc_Dl5IPAwzH0mUiCO5B720r8DxjlO9LulVcgqEF775SPnJ--o=w1903-h961)

## Funcionalidades
O programa tem um menu com as seguintes opções:

* Pagamento em boleto
* Pagamento em cartão de crédito
* Pagamento em cartão de débito
* Cancelar operação
* Sair do sistema

O usuário deve informar o valor da compra e o sistema deverá calcular e exibir o valor á ser pago de acordo com as regras de negócio descritas abaixo:

* Boleto  
Desconto de 12%  
Deverá exibir o código de barras do boleto junto com o valor a ser pago  

* Cartão de crédito  
Limite estabelecido no cartão de crédito deve ser pré-definido  
Máximo de parcelamento 12x  
Até 6x - acrescentar juros de 5% no valor da compra  
Entre 7x e 12x acrescentar juros de 8% no valor da compra  

* Cartão de débito  
Valor à vista sem desconto  
Valor do saldo em conta deve ser pré-definido  

## Cronograma

27/04 - Planejamento e divisão de tarefas - criar Trello  
28/04 - Codificação  
02/05 - Codificação e elaboração da apresentação  
03/05 - Apresentação para a sala  
