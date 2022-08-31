using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ConsoleApp6
{
	public class Repository
	{
		[JsonPropertyName("name")]
		public string Name { get; set; }
	}

	public class Person
	{
		[JsonPropertyName("success")]
		public bool Success { get; set; }

		public Data _Data { get; set; }

	}

	public class Data
	{
		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("note")]
		public string Note { get; set; }

		[JsonPropertyName("age")]
		public int Age { get; set; }

		[JsonPropertyName("registerDate")]
		public DateTime Date;
	}

}
