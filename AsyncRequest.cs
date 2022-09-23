using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp6
{
	internal class AsyncRequest
	{
		internal static async Task<List<Repository>> ProcessRepositories(HttpClient client)
		{
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(
				new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
			client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");


			var streamTask = client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
			var repositories = await JsonSerializer.DeserializeAsync<List<Repository>>(await streamTask);

			return repositories;

		}

		internal static async Task ProcessRepositories2(HttpClient client)
		{
			var stringTask = client.GetStringAsync("https://umayadia-apisample.azurewebsites.net/api/persons/Shakespeare");

			var msg = await stringTask;
			Console.Write(msg);
		}

		//通常のWebAPIコール
		internal static async Task<Person> PersonRepository(HttpClient client)
		{
			var streamTask = client.GetStreamAsync("https://umayadia-apisample.azurewebsites.net/api/persons");
			var repository = await JsonSerializer.DeserializeAsync<Person>(await streamTask);

			return repository;
		}


	}
}
