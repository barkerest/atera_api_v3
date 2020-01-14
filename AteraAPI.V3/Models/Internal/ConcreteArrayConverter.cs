using System;
using System.Linq;
using Newtonsoft.Json;

namespace AteraAPI.V3.Models.Internal
{
	internal class ConcreteArrayConverter<TInterface,TType> : JsonConverter
		where TType : TInterface
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
			=> serializer.Serialize(writer, value);

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
			=> serializer.Deserialize<TType[]>(reader).Cast<TInterface>().ToArray();
		
		public override bool CanConvert(Type objectType) => true;
	}
	
}
