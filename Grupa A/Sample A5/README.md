## Schematy podziałowe w enova365 dla programistów
### Sample A5

Schemat podziałowy dla ewidencji z płatnościami.

* generujemy opis analityczny dla każdej płatności
* kwota opisu będzie równa kwocie płatności
* opis oraz symbol konta zbudowany z wykorzystaniem kodu podmiotu z płatności
* pozostałe właściwości opisu arbitralnie wpisane w schemacie

#### Rezultat

Dla PK z płatnościami dla różnych kontrahentów:

* Abc; 80,00 PLN
* Zefir; 82,00 PLN

![](Sample%20A5.png)

#### Komentarz

W tym schemacie podziałowym wykorzystujemy obiekty biznesowe jakimi są płatności jako klucze zwracane przez kalkulator podzielnika.
