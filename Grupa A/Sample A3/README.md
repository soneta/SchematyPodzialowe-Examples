## Schematy podziałowe w enova365 dla programistów
### Sample A3

Schemat podziałowy dokumentu ewidencji.

* generowany jest 1 opis analityczny
* kwota równa kwocie dokumentu
* wymiar, opis, konto: wartości arbitralnie wpisane w schemacie

#### Komentarz

Ten schemat podziałowy jest modyfikacją schematu z przykładu A1.

Ilustruje działanie listy kluczy podziałowych. Kalkulator podzienika zwracana jednoelementową tabelę bez ustawionego obiektu (== null).
Oznacza to wygenerowanie jednego opisu analitycznego zgodnie z zasadą 1 element opisu analitycznego per klucz podziałowy.
Ale w kalkulatorze klucza nie możemy się odwołać do klucza ponieważ w tym przypadku `Row == null`.
Dlatego kwotę opisu analitycznego pobieramy bezpośrednio z property `Podstawa` (po odpowiednim rzutowaniu).