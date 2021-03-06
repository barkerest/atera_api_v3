﻿using System;
using Newtonsoft.Json;

namespace AteraAPI.V3.Models.Internal
{
	internal class ConcreteConverter<T> : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
			=> serializer.Serialize(writer, value);

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
			=> serializer.Deserialize<T>(reader);
		
		public override bool CanConvert(Type objectType) => true;
	}
}
