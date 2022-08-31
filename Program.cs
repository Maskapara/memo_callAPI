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
			//var repositories = await ProcessRepositories();
			//await ProcessRepositories2();
			var pr = await PersonRepository();


			//foreach (var repo in repositories)
			//	Console.WriteLine(repo.Name);

			Console.WriteLine($"sucess:{pr.Success}\ndata:{pr._Data}");

			Console.ReadLine();
		}

		private static async Task<List<Repository>> ProcessRepositories()
		{
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(
				new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
			client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");


			var streamTask = client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
			var repositories = await JsonSerializer.DeserializeAsync<List<Repository>>(await streamTask);

			return repositories;

		}

		//通常のWebAPIコール
		private static async Task ProcessRepositories2()
		{
			var stringTask = client.GetStringAsync("https://umayadia-apisample.azurewebsites.net/api/persons/Shakespeare");

			var msg = await stringTask;
			Console.Write(msg);
		}

		private static async Task<Person> PersonRepository()
		{
			var streamTask = client.GetStreamAsync("https://umayadia-apisample.azurewebsites.net/api/persons");
			var repository = await JsonSerializer.DeserializeAsync<Person>(await streamTask);

			return repository;
		}

	}
}
