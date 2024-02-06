using Microsoft.AspNetCore.Mvc;
using TRWalksUI.Models.DTO;

namespace TRWalksUI.Controllers
{
	public class RegionsController : Controller
	{
		private readonly IHttpClientFactory httpClientFactory;

		public RegionsController(IHttpClientFactory httpClientFactory)
        {
			this.httpClientFactory = httpClientFactory;
		}
        public async Task<IActionResult> Index()
		{
			List<RegionDto>response = new List<RegionDto>();

			try
			{
				//Get All Regions from web api
				var client = httpClientFactory.CreateClient();

				var httpResponseMessage = await client.GetAsync("https://localhost:7163/api/regions");

				httpResponseMessage.EnsureSuccessStatusCode();
				 response.AddRange(await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<RegionDto>>());
				ViewBag.Response = response;
			}
			catch (Exception ex)
			{
				
			}
			return View(response);
		}
	}
}
