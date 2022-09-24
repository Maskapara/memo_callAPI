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
		internal static async Task<List<DeserializeEach.DotnetRepos>> ProcessRepositories(HttpClient client, DeserializeEach.URLJson urls)
		{
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(
				new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
			client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");


			//dotnetRepos例
			var streamTask = client.GetStreamAsync(urls.Urls.Repos);
			var repositories = await JsonSerializer.DeserializeAsync<List<DeserializeEach.DotnetRepos>>(await streamTask);

			return repositories;

		}

		internal static async Task ProcessRepositories2(HttpClient client, DeserializeEach.URLJson urls)
		{
			//shakeseare例
			var stringTask = client.GetStringAsync(urls.Urls.shake);

			var msg = await stringTask;
			Console.Write(msg);
		}

		internal static async Task<DeserializeEach.Persons> PersonRepository(HttpClient client,DeserializeEach.URLJson urls)
		{
			//Persons例
			var streamTask = client.GetStreamAsync(urls.Urls.persons);
			var repository = await JsonSerializer.DeserializeAsync<DeserializeEach.Persons>(await streamTask);

			return repository;
		}


	}
}
