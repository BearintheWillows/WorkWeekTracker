using Microsoft.AspNetCore.Mvc;

namespace WWTApi.Controllers;

using Data;
using DataModels.WorkModels;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class ShopController : ControllerBase
{
	private DataContext _context;

	public ShopController(DataContext context)
	{
		_context = context;
	}
	

}