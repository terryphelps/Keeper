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

  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsService _service;

    public VaultKeepsController(VaultKeepsService service)
    {
      _service = service;
    }

    [HttpPost]
    public ActionResult<VaultKeep> Create([FromBody]VaultKeep vaultKeep)
    {
      vaultKeep.UserId = HttpContext.User.FindFirstValue("Id");
      return Ok(_service.Create(vaultKeep));
    }
    [HttpGet("{id}")]

    public ActionResult<IEnumerable<VaultKeep>> FindVaultKeepsById(int vkId)
    {
      var userId = HttpContext.User.FindFirstValue("Id");
      return Ok(_service.FindVaultKeepsById(vkId, userId));
    }
    // [HttpDelete("{id}")]
    // public ActionResult<bool> Delete(int id)
    // {
    //   return Ok(_service.Delete(id));
    // }
  }
}