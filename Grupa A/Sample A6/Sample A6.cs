

public class Podzielnik_Pozycja_1_Sample_A6
{
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
			get { return (DokEwidencji) Row; }
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
		/// Jako klucze podziałowe wykorzystujemy tablicę 3 stringów.
		/// Każdą z wartości potraktujemy jako symbol konta na opisie analitycznym.
		/// (liczba powstałych opisów analitycznych będzie równa ilości płatności)
		/// </summary>
		public override IEnumerable GetKluczeList()
		{
			return new[] { "401-01", "401-02", "401-03" };
		}
	}


	public class KluczKalkulator_DokEwidencja : KluczKalkulator
	{
		public KluczKalkulator_DokEwidencja(Object Row, IPodstawaWymiaruOpisuAnalitycznego Podstawa)
			: base(Row, Podstawa)
		{ }

		
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
		/// W tym przykładzie jest to arbitralnie wartość 1
		/// </summary>
		public override double GetProporcja()
		{
			return 1;
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
		/// Symbolem konta jest klucz podziałowy typu 'string'. Wymagane jest jedynie rzutowanie ponieważ właściwość 'Row' reprezentująca klucz jest typu 'object'.
		/// </summary>
		public override string GetSymbol()
		{
			return (string)Row;
		}

		public override string GetOpis()
		{
			return String.Empty;
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