## Schematy podziałowe w enova365 dla programistów
### Sample B1

Schemat podziałowy dla ewidencji z wykorzystaniem własnej klasy klucza podziałowego.  

* włączona opcja: podział elementu wg proporcji
* ilość opisów analitycznych stała ukryta w kodzie
* proporcje, symbole kont, opisy elementów ukryte w kodzie (konfigurowalne)
* pozostałe właściwości opisu arbitralnie wpisane w schemacie

[Schemat wymaga dodatkowej konfiguracji](CONFIG.md).

#### Rezultat

Dla PK o wartości 1000,00 PLN

![](Sample%20B1.png)

#### Komentarz

Wprowadzenie własnej klasy klucza podziałowego pozwala zawrzeć w kluczu wszystkie informacje niezbędne do stworzenia elementu opisu analitycznego.
Ciężar obliczeń skumulowany jest w jednym miejscu w kalkulatorze podzielnika. 
Sam kalkulator klucza pozostaje dzięki temu prosty. Są to wyłącznie odwołania do property klucza podziałowego.


