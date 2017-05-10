## Schematy podziałowe w enova365 dla programistów
### Sample B2

Schemat podziałowy dla ewidencji z wykorzystaniem własnej klasy klucza podziałowego.
Proporcje podziałowe budowane wg ilości kontrahentów w województwach.

* włączona opcja: podział elementu wg proporcji
* ilość opisów analitycznych zgodna z ilością województw w adresach bazy kontrahentów
* proporcja wg ilości kontrahentów w województwie
* opis elementu to nazwa województwa
* symbol konta zbudowany wg wzoru 501-01-papier-NUMERWOJEWODZTWA
* pozostałe właściwości opisu arbitralnie wpisane w schemacie

Ten schemat wykorzystuje do obliczeń tabelę kontrahentów wraz z ich danymi adresowymi (województwami).
Wynik podziału kwoty będzie więc zależny od tych danych.

#### Rezultat

Dla PK o wartości 1000,00 PLN

![](Sample%20B2.png)

#### Komentarz

Wprowadzenie własnej klasy klucza podziałowego pozwala zawrzeć w kluczu wszystkie informacje niezbędne do stworzenia elementu opisu analitycznego.
Ciężar obliczeń skumulowany jest w jednym miejscu w kalkulatorze podzielnika. 
Sam kalkulator klucza pozostaje dzięki temu prosty. Są to wyłącznie odwołania do property klucza podziałowego.


