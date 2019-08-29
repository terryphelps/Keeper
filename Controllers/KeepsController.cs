using System.Collections.Generic;
using keepr.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using keepr.Services;
using System.Security.Claims;

namespace keepr.Controllers
{

  [Route("api/[controller]")]
  [ApiController]

  public class KeepsController : ControllerBase
  {
    private readonly KeepsService _service;

    [HttpGet]
    public ActionResult<IEnumerable<Keep>> Get()
    {
      return Ok(_service.Find());
    }
    [Authorize]
    [HttpGet("user")]
    public ActionResult<Keep> GetUserKeeps(string userId)
    {
      userId = HttpContext.User.FindFirstValue("Id");
      return Ok(_service.FindByUserId(userId));
    }
    [HttpGet("{id}")]
    public ActionResult<Keep> GetKeep(int id)
    {
      return Ok(_service.FindKeepById(id));
    }
    [Authorize]
    [HttpPost]
    public ActionResult<Keep> Create([FromBody]Keep keep)
    {
      keep.UserId = HttpContext.User.FindFirstValue("Id");
      return Ok(_service.Create(keep));
    }
    [Authorize]
    [HttpDelete("{id}")]
    public ActionResult<bool> Delete(int id)
    {
      return Ok(_service.Delete(id));
    }

    public KeepsController(KeepsService service)
    {
      _service = service;
    }
    // [HttpPut("{id}")]
    // public ActionResult<Keep> Update([FromBody]Keep keep)
    // {
    //   return Ok(_service.Update(keep));
    // }
  }
}