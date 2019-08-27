

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

    [HttpGet]
    public ActionResult<IEnumerable<VaultKeep>> Get(int id)
    {
      var x = new User();
      return Ok(_service.FindKeepsById(id));
    }
    [HttpDelete]
    public ActionResult<bool> Delete(int id)
    {
      return Ok(_service.Delete(id));
    }

    [HttpPost]
    public ActionResult<VaultKeep> Create([FromBody]VaultKeep vaultKeep)
    {
      vaultKeep.UserId = HttpContext.User.FindFirstValue("Id");
      return Ok(_service.Create(vaultKeep));
    }
  }
}