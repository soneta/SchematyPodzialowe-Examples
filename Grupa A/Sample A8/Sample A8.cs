using System;
using System.Collections;
using Soneta.Core;
using Soneta.Kasa;
using Soneta.Ksiega.Podzielniki;
using Soneta.Types;



public class Podzielnik_Pozycja_1_Sample_A8
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
		/// Jako klucze podziałowe wykorzystujemy podzielnik kosztów.
		/// Poniższy kod wygenerowany jest automatycznie przez czynność "Generuj kod kluczy/Wg Podzielnika".
		/// Nazwy "Sample 7" odnoszą się odpowiednio do nazwy zestawu podzielników oraz podzienika w zestawie.
		/// </summary>
		public override IEnumerable GetKluczeList()
		{
			return PodzielnikTool.ElementyPodzielnika(Session, "Sample 7", "Sample 7", 
				PodzielnikTool.PodzielnikAktualnosc.WgDaty, Podstawa.Data);
		}
	}


	public class KluczKalkulator_DokEwidencja : KluczKalkulator
	{
		public KluczKalkulator_DokEwidencja(Object Row, IPodstawaWymiaruOpisuAnalitycznego Podstawa)
			: base(Row, Podstawa)
		{ }


		/// <summary>
		/// Property generowane automatycznie jeśli znany jest typ klucza podziałowego.
		/// W przypadku korzystania z podzielnika kosztów typem tym jest "ElementPodzielnika"
		/// </summary>
		public ElementPodzielnika ElementPodzielnika
		{
			get { return (ElementPodzielnika)Row; }
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
		/// W tym przykładzie wartość proporcji zwracana jest bezpośrednio przez element podzielnika.
		/// </summary>
		public override double GetProporcja()
		{
			return ElementPodzielnika.Wspolczynnik;
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
		/// Symbol konta na opis analitycznym na pochodzić z cechy na centrum kosztów.
		/// 'ElementPodzielnika.ElementPodzialowy' reprezentuje centrum kosztów stąd odwołanie do cechy 'Konto' jak w kodzie.
		/// </summary>
		public override string GetSymbol()
		{
			return (string)ElementPodzielnika.ElementPodzialowy.Features["Konto"];
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

		/// <summary>
		/// Ponieważ podzielnik kosztu oparty jest o tabelę centrów kosztów to element podziałowy elementu podzielnika
		/// jest w tym wypadku bezpośrednio centrum, które możemy przypisać do elementu opisu analitycznego. 
		/// </summary>
		public override CentrumKosztow GetCentrumKosztow()
		{
			return (CentrumKosztow)ElementPodzielnika.ElementPodzialowy;
		}
	}
}