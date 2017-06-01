

/// <summary>
/// Kod generowany na poziomie pozycji schematu podziałowego
/// </summary>
public class Podzielnik_Pozycja_1_Sample_A1
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
			get { return (DokEwidencji)Row; }
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
		/// Jednoelementowa lista kluczy podziałowych; kluczem jest sam dokument ewidencji
		/// (taki kod generuje czynność "Generuj kod kluczy/Wg bieżacego")
		/// </summary>
		/// <returns></returns>
		public override IEnumerable GetKluczeList()
		{
			return new[] { DokEwidencji };
		}
	}


	/// <summary>
	/// Kalkulator klucza
	/// </summary>
	public class KluczKalkulator_DokEwidencja : KluczKalkulator
	{
		public KluczKalkulator_DokEwidencja(object Row, IPodstawaWymiaruOpisuAnalitycznego Podstawa)
			: base(Row, Podstawa)
		{ }


		/// <summary>
		/// Property automatycznie generowane ponieważ zostało zadeklarowane, że zwracane klucze podziałowe są obiektami biznesowymi DokEwidencji
		/// </summary>
		public DokEwidencji DokEwidencji
		{
			get { return (DokEwidencji)Row; }
		}

		/// <summary>
		/// Kwotę dla opisu analitycznego pobieramy z dokumentu ewidencji
		/// </summary>
		public override Currency GetKwotaKlucza()
		{
			return DokEwidencji.KwotaPodstawy("");
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

		public override string GetSymbol()
		{
			return "401-01";
		}

		public override string GetOpis()
		{
			return "Wartość dokumentu";
		}

		public override IBudzetProjektu GetBudzet()
		{
			return null;
		}

		public override string GetSymbolPozycjiBudzetu()
		{
			return string.Empty;
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