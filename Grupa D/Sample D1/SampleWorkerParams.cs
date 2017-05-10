using Soneta.Business;
using Soneta.Core;
using Soneta.Tools;
using Soneta.Types;



namespace GeekOut2017.Sample.D1
{
	public sealed class SampleWorkerParams : ContextBase
	{
		[Required]
		[Priority(10)]
		[DefaultWidth(25)]
		[Caption("Nazwa schematu")]
		public string Nazwa { get; set; }


		[Required]
		[Priority(20)]
		[DefaultWidth(25)]
		[Caption("Zestaw podzielników")]
		public ZestawPodzielnikowKosztow Zestaw { get; set; }


		public SampleWorkerParams(Context context)
			: base(context)
		{ }
	}
}