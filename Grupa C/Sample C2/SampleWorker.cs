using System;
using System.Diagnostics;
using GeekOut2017.Sample.C2;
using Soneta.Business;
using Soneta.Business.UI;
using Soneta.Core;
using Soneta.Ksiega.Podzielniki;



[assembly: Worker(typeof(SampleWorker), typeof(DokEwidencja))]


namespace GeekOut2017.Sample.C2
{
	internal class SampleWorker
	{
		[Context]
		public SampleWorkerParams Pm { get; set; }


		[Action("Geek Out 2017/Sample C2", Target = ActionTarget.Menu, Mode = ActionMode.SingleSession)]
		public MessageBoxInformation GenerujOpisy()
		{
			Debug.Assert(Pm != null);
			Debug.Assert(Pm.Dok != null);
			Debug.Assert(Pm.Schemat != null);

			//
			// Chcemy sprawdzić czy wybrany schemat podziałowy (jeśli ma kalkulator schematu) pozwala na uruchomienie dla wybranego dokumentu ewidencji.
			// Do potencjalnie istniejącej statycznej metody IsVisible() musimy odwołać się z wykorzystaniem mechanizmu reflection.
			//

			var compiledSchemaCalc = Pm.Schemat.Compiler.CompiledAssembly.GetType(Pm.Schemat.SchematClassName);
			var methodIsVisible = compiledSchemaCalc?.GetMethod("IsVisible");

			if (methodIsVisible != null && !(bool) methodIsVisible.Invoke(null, new object[] {Pm.Dok, null}))
				throw new Exception($"Schemat '{Pm.Schemat}' nie może zostać uruchomiony dla dokumentu '{Pm.Dok}'.");

			// 
			// Uruchamiamy generowanie opisów analitycznych
			//

			var worker = new PodzielnikKosztowWorker(Pm.Schemat, Pm.Dok);
			worker.GenerujOpisAnalityczny();

			//
			// Jeśli podczas generowania opisów analitycznych nie został zgłoszony wyjątek to pole "PodzielnikWynikInfo" 
			// zawiera tekstową informację o wyniku działania czynności.
			//

			return new MessageBoxInformation
			{
				Type = MessageBoxInformationType.Information,
				Text = worker.PodzielnikWynikInfo,
				OKHandler = () => null
			};
		}
	}
}