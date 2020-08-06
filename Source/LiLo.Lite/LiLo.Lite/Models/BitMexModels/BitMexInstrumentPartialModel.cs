namespace LiLo.Lite.Models.BitMexModels
{
	using System.Text.Json.Serialization;
	public class BitMexInstrumentPartialModel
	{
		[JsonPropertyName("table")]
		public string Table { get; set; }

		[JsonPropertyName("action")]
		public string Action { get; set; }

		[JsonPropertyName("keys")]
		public object Keys { get; set; }

		[JsonPropertyName("types")]
		public object Types { get; set; }

		[JsonPropertyName("foreignKeys")]
		public object ForeignKeys { get; set; }

		[JsonPropertyName("attributes")]
		public object Attributes { get; set; }

		[JsonPropertyName("filter")]
		public object Filter { get; set; }

		[JsonPropertyName("data")]
#pragma warning disable CA1819 // Properties should not return arrays
		public BitMexDataModel[] Data { get; set; }
#pragma warning restore CA1819 // Properties should not return arrays
	}
}