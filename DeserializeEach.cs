using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsoleApp6
{
	internal class DeserializeEach
	{
		public class DotnetRepos
		{
			[JsonPropertyName("name")]
			public string Name { get; set; }
		}

		public class Shakespeeare
		{
			[JsonPropertyName("success")]
			public bool Success { get; set; }

			public Data _Data { get; set; }

		}
		public class Persons
		{
			[JsonPropertyName("success")]
			public bool Success { get; set; }

			[JsonPropertyName("data")]
			public Data[] _Data { get; set; }
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

		public class URLJson
		{
			[JsonPropertyName("urls")]
			public URL Urls { get; set; }

		}

		public class URL
		{
			[JsonPropertyName("dotnetRepos")]
			public string Repos { get; set; }
			[JsonPropertyName("shakeseare")]
			public string shake { get; set; }
			[JsonPropertyName("persons")]
			public string persons { get; set; }
		}
	}
}
