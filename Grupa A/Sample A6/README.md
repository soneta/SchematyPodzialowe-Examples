## Schematy podziałowe w enova365 dla programistów
### Sample A6

Schemat podziałowy dla ewidencji.

* włączona opcja: Podział elementu wg proporcji
* 3 opisy analityczne w tym samym wymiarze
* kwoty opisu generowane wg proporcji 1-1-1
* symbole kont zadane przez klucze podziałowe
* pozostałe właściwości opisu arbitralnie wpisane w schemacie

#### Komentarz

Schemat pokazuje generowanie opisów analitycznych wg proporcji. W tym wypadku proporcje są stałe, arbitralnie zadane.
Widać, że w kalkulatorze kluczy istotne jest podanie proporcji zamiast kwot, jak w poprzednich przykładach. 
Wymagane za to jest podanie kwoty sumarycznej w kalkulatorze podzielnika.

Warto zobserwować działanie schematu dla wartości ewidencji 1000,00 PLN

* jeśli nie jest włączone zaokrąglanie otrzymujemy 3 opisy z kwotą 333,33 PLN
* po włączeniu opcji "Zaokrąglanie kwoty" jeden z opisów ma kwotę 333,34 PLN, aby sumaryczna kwota dała wyjściową kwotę użytą do proporcjonalnego dzielenia