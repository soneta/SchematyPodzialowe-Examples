

public class Podzielnik_Pozycja_1_Sample_A5
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

		public override Currency GetKwota()
		{
			return Currency.Zero;
		}

		public override Amount GetIlosc()
		{
			return Amount.Zero;
		}

		/// <summary>
		/// Jako klucze podziałowe wykorzystujemy obiekty płatności z danej ewidencji
		/// (liczba powstałych opisów analitycznych będzie równa ilości płatności)
		/// </summary>
		public override IEnumerable GetKluczeList()
		{
			return DokEwidencji.Platnosci;
		}
	}


	public class KluczKalkulator_DokEwidencja : KluczKalkulator
	{
		public KluczKalkulator_DokEwidencja(Object Row, IPodstawaWymiaruOpisuAnalitycznego Podstawa)
			: base(Row, Podstawa)
		{ }


		/// <summary>
		/// Generowany automatycznie ponieważ zadeklarowaliśmy,
		/// że kluczem podziałowym jest obiekt biznesowy płatność
		/// </summary>
		public Platnosc Platnosc
		{
			get { return (Platnosc) Row; }
		}

		/// <summary>
		/// Kwota opisu analitycznego będzie równa kwocie płatności 
		/// </summary>
		public override Currency GetKwotaKlucza()
		{
			return Platnosc.Kwota;
		}

		public override Amount GetIloscKlucza()
		{
			return Amount.Zero;
		}

		public override double GetProporcja()
		{
			return 0;
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
		/// Symbol konta z kodem podmiotu w formacie 200-KOD
		/// </summary>
		public override string GetSymbol()
		{
			return "200-" + Platnosc.Podmiot.Kod;
		}

		/// <summary>
		/// Do opisu elementu opisu analitycznego kopiujemy pełną nazwę podmiotu z płatności 
		/// </summary>
		public override string GetOpis()
		{
			return Platnosc.Podmiot.Nazwa;
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