using System.Collections.Generic;
using System.Security.Claims;
using keepr.Models;
using keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]

  public class VaultsController : ControllerBase
  {
    private readonly VaultsService _service;
    public VaultsController(VaultsService service)
    {
      _service = service;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Vault>> Get()
    {
      return Ok(_service.Find());
    }
    [HttpGet("user")]
    public ActionResult<Vault> GetUser(string userId)
    {
      userId = HttpContext.User.FindFirstValue("Id");
      return Ok(_service.FindByUserId(userId));
    }
    [HttpGet("{id}")]
    public ActionResult<Vault> GetVault(int id)
    {
      return Ok(_service.FindVaultById(id));
    }
    [HttpPost]
    public ActionResult<Vault> Create([FromBody]Vault vault)
    {
      vault.UserId = HttpContext.User.FindFirstValue("Id");
      return Ok(_service.Create(vault));
    }
    // [HttpPut("{id}")]
    // public ActionResult<Vault> Update([FromBody]Vault vault)
    // {
    //   return Ok(_service.Update(vault));
    // }
    [HttpDelete("{id}")]

    public ActionResult<bool> Delete(int id)
    {
      return Ok(_service.Delete(id));
    }
  }
}