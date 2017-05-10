using System;
using System.Diagnostics;
using GeekOut2017.Sample.D1;
using Soneta.Business;
using Soneta.Core;
using Soneta.Ksiega.Podzielniki;



[assembly: Worker(typeof(SampleWorker), typeof(DokEwidencja))]


namespace GeekOut2017.Sample.D1
{
	internal class SampleWorker
	{
		[Context]
		public SampleWorkerParams Pm { get; set; }


		[Action("Geek Out 2017/Sample D1", Target = ActionTarget.Menu, Mode = ActionMode.ConfigSession)]
		public void UtworzSchematPodzialowy()
		{
			Debug.Assert(Pm != null);
			Debug.Assert(Pm.Zestaw != null);
			Debug.Assert(!string.IsNullOrEmpty(Pm.Nazwa));

			using (var t = Pm.Session.Logout(true))
			{
				UtworzSchematPodzialowyCore();
				t.CommitUI();
			}
		}


		private void UtworzSchematPodzialowyCore()
		{
			//
			// tworzymy nowy schemat podziałowy o nazwie wskazanej w parametrach
			// (warto zauważyć, że cały worker skonfigurowany jest do pracy w sesji konfiguracyjnej)
			//

			var schemat = Pm.Session.AddRow(new SchematPodz("DokEwidencja"));
			schemat.Nazwa = Pm.Nazwa;
			schemat.Opis = "Schemat wygenerowany z kodu c#";

			//
			// tworzymy pozycję schematu podziałowego
			//

			var pozycja = Pm.Session.AddRow(new SchematPodzElem {SchematPodz = schemat});
			pozycja.Nazwa = "Pozycja 1";
			pozycja.SchematPodzElemWg = SchematPodzElemWg.Proporcji;
			pozycja.ZaokraglanieKwoty = true;

			//
			// we wskazanym w parametrach workera zestawie podzielników
			// odszukujemy pierwszy podzielnik
			//

			var podzielnik = (PodzielnikKosztow) Pm.Zestaw.Podzielniki.GetNext();
			if (podzielnik == null)
				throw new Exception($"W zestawie podzielników '{Pm.Zestaw.Nazwa}' nie zdefiniowano żadnego podzielnika.");

			//
			// konfigurujemy kalkulator podzielnika
			// (odpowiednik wpisywania kodu na formularzu)
			//

			pozycja._IsEnable = "true";
			pozycja._GetKwota = "DokEwidencji.Wartosc";
			pozycja._GetKluczeList = $@"PodzielnikTool.ElementyPodzielnika(Session, ""{Pm.Zestaw.Nazwa}"", ""{podzielnik.Nazwa}"", PodzielnikTool.PodzielnikAktualnosc.WgDaty, Podstawa.Data)";

			//
			// konfigurujemy kalkulator klucza
			// (odpowiednik wpisywania kodu na formularzu)
			//

			pozycja.KluczTyp = "Soneta.Core.ElementPodzielnika"; 
			pozycja._GetProporcja = "ElementPodzielnika.Wspolczynnik";
			pozycja._GetWymiar = @"""P1"""; // zwracamy wartość w cudzysłowie
			pozycja._GetSymbol = @"""401-01"""; // zwracamy wartość w cudzysłowie
			pozycja._GetCentrumKosztow = "(CentrumKosztow) ElementPodzielnika.ElementPodzialowy";
		}
	}
}