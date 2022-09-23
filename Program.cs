using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text;
using System.Text.Json;
using System.Collections.Generic;

namespace ConsoleApp6
{
	class Program
	{
		private static readonly HttpClient client = new HttpClient();

		static async Task Main(string[] args)
		{
			//MSDNドキュメント
			//var repositories = await AsyncRequest.ProcessRepositories(client);
			//foreach (var repo in repositories)
			//	Console.WriteLine(repo.Name);

			//MSDNドキュメント
			//await AsyncRequest.ProcessRepositories2(client);

			//MSDNドキュメント→jsonデシリアイズ汎用化
			var pr = await AsyncRequest.PersonRepository(client);
			Console.WriteLine($"sucess:{pr.Success}\ndata:{pr._Data}");

			Console.ReadLine();
		}



	}
}
