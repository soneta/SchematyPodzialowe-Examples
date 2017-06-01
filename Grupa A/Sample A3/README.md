## Schematy podziałowe w enova365 dla programistów
### Sample A3

Schemat podziałowy dokumentu ewidencji.

* generowany jest 1 opis analityczny
* kwota równa kwocie podstawy dokumentu
* wymiar, opis, konto: wartości arbitralnie wpisane w schemacie

#### Rezultat

Dla ZR o wartości 123,00 PLN

![](Sample%20A3.png)

#### Komentarz

Ten schemat podziałowy jest modyfikacją schematu z przykładu A1.

Ilustruje działanie listy kluczy podziałowych. Kalkulator podzielnika zwraca jednoelementową tabelę bez obiektu.
Oznacza to wygenerowanie jednego opisu analitycznego zgodnie z zasadą "1 element opisu analitycznego per klucz podziałowy".

Ale w kalkulatorze klucza nie możemy się odwołać do klucza ponieważ w tym przypadku `Row == null`.
Dlatego kwotę opisu analitycznego pobieramy bezpośrednio z property `Podstawa`.