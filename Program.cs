using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text;
using System.Text.Json;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp6
{
	class Program
	{
		private static readonly HttpClient client = new HttpClient();

		static async Task Main(string[] args)
		{
			//jsonデシリアライズ
			var filePath = "./../../../URL.json";
			var jsonString = File.ReadAllText(filePath);
			DeserializeEach.URLJson urls = JsonSerializer.Deserialize<DeserializeEach.URLJson>(jsonString);


			//MSDNドキュメントパターン
			var repositories = await AsyncRequest.ProcessRepositories(client,urls);
			foreach (var repo in repositories)
				Console.WriteLine(repo.Name);

			//MSDNドキュメントパターン
			await AsyncRequest.ProcessRepositories2(client,urls);

			//MSDNドキュメント→jsonデシリアイズ汎用化
			var pr = await AsyncRequest.PersonRepository(client, urls);
			Console.WriteLine($"sucess:{pr.Success}\ndata:{pr._Data[0].Name}");

			Console.ReadLine();
		}



	}
}
