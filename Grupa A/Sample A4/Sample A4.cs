

/// <summary>
/// Kalkulator schematu 
/// Pokazujemy schemat tylko dla ewidencji z VAT
/// </summary>
public static class Schemat_Sample_A4
{
	public static bool IsVisible(DokEwidencji DokEwidencji, IParentZrodlaOpisuAnalitycznego Parent)
	{
		return DokEwidencji is VATEwidencja && ((VATEwidencja)DokEwidencji).PodlegaVAT;
	}
}



public class Podzielnik_Pozycja_Netto_Sample_A4
{
	/// <summary>
	/// Kalkulator podzielnika pozycji "Netto"
	/// </summary>
	public class PodzielnikKalkulator_DokEwidencja : PodzielnikKalkulator
	{
		public PodzielnikKalkulator_DokEwidencja(IPodstawaWymiaruOpisuAnalitycznego Podstawa)
			: base(Podstawa)
		{ }

		public Soneta.Core.DokEwidencji DokEwidencji
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

		public override IEnumerable GetKluczeList()
		{
			return new DokEwidencji[] { DokEwidencji };
		}
	}


	/// <summary>
	/// Kalkulator klucza pozycji "Netto"
	/// </summary>
	public class KluczKalkulator_DokEwidencja : KluczKalkulator
	{
		public KluczKalkulator_DokEwidencja(Object Row, IPodstawaWymiaruOpisuAnalitycznego Podstawa)
			: base(Row, Podstawa)
		{ }

		public DokEwidencji DokEwidencji
		{
			get { return (DokEwidencji)Row; }
		}

		/// <summary>
		/// Wiemy, że mamy do czynienia w ewidencją VAT, możemy więc pobrać kwotę netto z nagłówka VAT
		/// </summary>
		public override Currency GetKwotaKlucza()
		{
			return ((VATEwidencja)DokEwidencji).NagEwidencjiVAT.Netto;
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
			return "Netto";
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
			return "Wartość netto dokumentu";
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


public class Podzielnik_Pozycja_VAT_Sample_A4
{
	/// <summary>
	/// Kalkulator podzielnika pozycji "Netto"
	/// </summary>
	public class PodzielnikKalkulator_DokEwidencja : PodzielnikKalkulator
	{
		public PodzielnikKalkulator_DokEwidencja(IPodstawaWymiaruOpisuAnalitycznego Podstawa)
			: base(Podstawa)
		{ }

		public Soneta.Core.DokEwidencji DokEwidencji
		{
			get { return (Soneta.Core.DokEwidencji)Row; }
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

		public override IEnumerable GetKluczeList()
		{
			return new DokEwidencji[] { DokEwidencji };
		}
	}


	/// <summary>
	/// Kalkulator klucza pozycji "Netto"
	/// </summary>
	public class KluczKalkulator_DokEwidencja : KluczKalkulator
	{
		public KluczKalkulator_DokEwidencja(Object Row, IPodstawaWymiaruOpisuAnalitycznego Podstawa)
			: base(Row, Podstawa)
		{ }

		public DokEwidencji DokEwidencji
		{
			get { return (DokEwidencji)Row; }
		}

		/// <summary>
		/// Wiemy, że mamy do czynienia w ewidencją VAT, możemy więc pobrać kwotę VAT z nagłówka VAT
		/// </summary>
		public override Currency GetKwotaKlucza()
		{
			return ((VATEwidencja)DokEwidencji).NagEwidencjiVAT.VAT;
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
			return "VAT";
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
			return "Wartość VAT dokumentu";
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