using Microsoft.AspNetCore.Mvc;

namespace WWTApi.Controllers;

using Data;
using DataModels.WorkModels;
using DataModels.WorkModels.DTOs.ShopDtos;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route( "/api/[controller]/" )]
public class ShopController : ControllerBase
{
	private DataContext _context;

	public ShopController(DataContext context)
	{
		_context = context;
	}

	[HttpGet( "{id}" )]
	public async Task<ShopDto> GetShop(int id)
	{
		var shop = await _context.Shops.Select( s => new ShopDto()
				{
				ShopId = s.ShopId,
				Name = s.Name,
				Address1 = s.Address1,
				City = s.City,
				County = s.County,
				PostCode = s.PostCode,
				Notes = s.Notes,
				}
		).SingleAsync( s => s.ShopId == id );

		return shop;
	}
}