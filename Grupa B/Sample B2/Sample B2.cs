

public class Podzielnik_Pozycja_1_Sample_B1
{
	/// <summary>
	/// Dedykowana klasa klucza podziałowego.
	/// 
	/// Zgromadzenie w kluczu podziłowym wszystkich informacji dotyczyących generowego opisu jest dobrą praktyką
	/// i pozwala utrzymywać kalkulator klucza maksymalnie prosty.
	/// 
	/// W naszym przypadku klucz dostarcza proporcji, symbolu konta oraz opisu.
	/// Pozostałe własności są na stałe zapisane w kalkulatorze klucza.
	/// 
	/// Ważne jest aby klasa klucza została zdefiniowana na zewnątrz klasy kalkulatorów podzielnika i klucza
	/// ponieważ musi być dostępna w obu tych kalkulatorach.
	/// </summary>
	public class KluczType
	{
		public double Proporcja;
		public string Symbol;
		public string Opis;
	}


	/// <summary>
	/// Kalkulator podzielnika
	/// </summary>
	public class PodzielnikKalkulator_DokEwidencja : PodzielnikKalkulator
	{
		public PodzielnikKalkulator_DokEwidencja(IPodstawaWymiaruOpisuAnalitycznego Podstawa)
			: base(Podstawa)
		{ }

		public DokEwidencji DokEwidencji
		{
			get { return (DokEwidencji)Row; }
		}

		public override bool IsEnable()
		{
			return true;
		}

		/// <summary>
		/// Kalkulator podzienika zwraca sumaryczną kwotę. 
		/// Jest ona wymagana ponieważ schemat ma włączoną opcję generowania kwot na opisach wg proporcji.
		/// </summary>
		public override Currency GetKwota()
		{
			return DokEwidencji.Wartosc;
		}

		public override Amount GetIlosc()
		{
			return Amount.Zero;
		}

		/// <summary>
		/// Jako klucze podziałowe wykorzystujemy obiekty dedykowanej klasy 'KluczType'.
		/// Proporcje w tym podzielniku będą wyznaczone przez ilość kontrahentów przypisaną do województw.
		/// </summary>
		public override IEnumerable GetKluczeList()
		{
			// słownik ze statystyką województwo/ilość kontrahentów
			var stats = new Dictionary<Wojewodztwa, int>();

			// dane kontrahentów
			var kontrahenci = Row.Session.Get<CRMModule>().Kontrahenci.WgKodu;

			// budujemy statystyke
			foreach (var kontrahent in kontrahenci)
			{
				int count;
				var woj = kontrahent.Adres.Wojewodztwo;

				stats.TryGetValue(woj, out count);
				stats[woj] = ++count;
			}

			// dla każdego zarejestrowanego województwa tworzymy klucz podziałowy
			foreach (var key in stats)
				yield return new KluczType
				{
					// proporcja to ilość kontrahentów w województwie
					Proporcja = key.Value,
					// opis elementu: nazwa województwa
					Opis = CaptionAttribute.EnumToString(key.Key),
					// symbol zbudowany z wykorzystaniem numeru wojewodztwa
					Symbol = string.Format("501-01-papier-{0:00}", (int)key.Key)
				};
		}
	}


	public class KluczKalkulator_DokEwidencja : KluczKalkulator
	{
		public KluczKalkulator_DokEwidencja(Object Row, IPodstawaWymiaruOpisuAnalitycznego Podstawa)
			: base(Row, Podstawa)
		{ }


		/// <summary>
		/// Ponieważ typ klucza nie jest obiektem biznesowym enova automat nie wygeneruje nam property do szybkiego dostępu.
		/// To property tworzymi sami żeby móc odwoływać się w kodzie przez 'Klucz' a nie '(KluczType)Row'.
		/// </summary>
		public KluczType Klucz
		{
			get { return (KluczType)Row; }
		}

		/// <summary>
		/// Kwota podawana przez kalkulator klucza jest ignorowana.
		/// Kwota docelowa będzie liczona z proporcji. 
		/// </summary>
		public override Currency GetKwotaKlucza()
		{
			return 0;
		}

		public override Amount GetIloscKlucza()
		{
			return Amount.Zero;
		}

		/// <summary>
		/// Ponieważ włączone jest generowanie kwot wg proporcji kalkulator klucza zwraca proporcję.
		/// W tym przykładzie wartość proporcji została już obliczona na etapie kalkulatora podzielnika.
		/// </summary>
		public override double GetProporcja()
		{
			return Klucz.Proporcja;
		}

		public override string GetWymiar()
		{
			return "P1";
		}

		public override Date GetData()
		{
			return Date.Today;
		}

		/// <summary>
		/// Symbol konta został obliczony na etapie kalkulatora podzielnika i przekazany jest w kluczu.
		/// </summary>
		public override string GetSymbol()
		{
			return Klucz.Symbol;
		}

		/// <summary>
		/// Opis elementu opis analitycznego został obliczony na etapie kalkulatora podzielnika i przekazany jest w kluczu.
		/// </summary>
		public override string GetOpis()
		{
			return Klucz.Opis;
		}

		public override IBudzetProjektu GetBudzet()
		{
			return null;
		}

		public override string GetSymbolPozycjiBudzetu()
		{
			return String.Empty;
		}

		public override Currency? GetKwotaDodatkowaKlucza()
		{
			return null;
		}

		public override CentrumKosztow GetCentrumKosztow()
		{
			return null;
		}
	}
}