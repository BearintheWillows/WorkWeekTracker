namespace WWTClient.Interfaces;

using Microsoft.AspNetCore.Components;

public interface IHttpClient
{
	[Inject]
	protected HttpClient? Http { get; set; }
	

}