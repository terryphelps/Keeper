using System.Collections.Generic;
using keepr.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using keepr.Services;
using System.Security.Claims;

namespace keepr.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]

  public class KeepsController : ControllerBase
  {
    private readonly KeepsService _service;

    [HttpGet]
    public ActionResult<IEnumerable<Keep>> Get()
    {
      var x = new User();
      return Ok(_service.Find());
    }
    [HttpGet("/user/{id}")]
    public ActionResult<Keep> GetUser(string id)
    {
      return Ok(_service.FindByUserId(id));
    }
    [HttpGet("{id}")]
    public ActionResult<Keep> GetKeep(int id)
    {
      return Ok(_service.FindKeepById(id));
    }
    [HttpPost]
    public ActionResult<Keep> Create([FromBody]Keep keep)
    {
      keep.UserId = HttpContext.User.FindFirstValue("Id");
      return Ok(_service.Create(keep));
    }

    [HttpPut("{id}")]
    public ActionResult<Keep> Update([FromBody]Keep keep)
    {
      return Ok(_service.Update(keep));
    }
    [HttpDelete("{id}")]
    public ActionResult<bool> Delete(int id)
    {
      return Ok(_service.Delete(id));
    }

    public KeepsController(KeepsService service)
    {
      _service = service;
    }
  }
}