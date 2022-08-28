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
			await ProcessRepositories();
			//await pr2();
			Console.ReadLine();
		}

		private static async Task ProcessRepositories()
		{
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(
				new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
			client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");


			var streamTask = client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
			var repositories = await JsonSerializer.DeserializeAsync<List<Repository>>(await streamTask);

			foreach(var repo in repositories)
			{
				Console.WriteLine(repo.Name);
			}

		}

		//通常のWebAPIコール
		private static async Task pr2()
		{
			var stringTask = client.GetStringAsync("https://umayadia-apisample.azurewebsites.net/api/persons/Shakespeare");

			var msg = await stringTask;
			Console.Write(msg);
		}
	}
}
