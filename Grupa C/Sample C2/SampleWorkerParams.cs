using Soneta.Business;
using Soneta.Core;
using Soneta.Ksiega;
using Soneta.Ksiega.Podzielniki;
using Soneta.Tools;
using Soneta.Types;



namespace GeekOut2017.Sample.C2
{
	public sealed class SampleWorkerParams : ContextBase
	{
		[Required]
		[Priority(10)]
		[DefaultWidth(25)]
		[Caption("Dokument ewidencji")]
		public DokEwidencji Dok { get; set; }


		[Required]
		[Priority(20)]
		[DefaultWidth(25)]
		[Caption("Schemat podziałowy")]
		public SchematPodz Schemat { get; set; }


		public object GetListSchemat()
		{
			// warunek: chcemy na liście pokazać tylko niezablokowane schematy dla dokumentów ewidencji 
			var condition = new FieldCondition.Equal("Blokada", false) & new FieldCondition.Equal("TableName", "DokEwidencja");
			return Session.Get<KsiegaModule>().SchematyPodz.WgNazwa[condition];
		}


		public SampleWorkerParams(Context context)
			: base(context)
		{ }
	}
}