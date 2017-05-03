using Soneta.Core;
using Soneta.Ksiega.Podzielniki;


namespace Soneta.Ksiega
{
	public class SampleC1
	{
		/// <summary>
		/// Minimalny kod do wygenerowania opisów analitycznych przez schemat podziałowy
		/// </summary>
		/// <param name="schemat">schemat podziałowy</param>
		/// <param name="podstawa">obiekt, dla którego zostaną wygenerowane opisy (np. dokument ewidencji)</param>
		public void GenerujOpisy(SchematPodz schemat, IPodstawaWymiaruOpisuAnalitycznego podstawa)
			=> new PodzielnikKosztowWorker(schemat, podstawa).GenerujOpisAnalityczny();
	}
}