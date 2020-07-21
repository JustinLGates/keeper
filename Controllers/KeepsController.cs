using System;
using System.Collections.Generic;
using System.Security.Claims;
using keepr.Models;
using keepr.Services;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class KeepsController : ControllerBase
  {
    private readonly KeepsService _ks;
    public KeepsController(KeepsService ks)
    {
      _ks = ks;

    }
    [HttpGet]
    public ActionResult<IEnumerable<Keep>> Get()
    {
      try
      {
        return Ok(_ks.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      };
    }
    [Authorize]
    [HttpGet("vault/{id}")]
    public ActionResult<IEnumerable<Keep>> GetByVaultId(int id)
    {
      try
      {
        string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_ks.GetByVaultId(id, userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      };
    }
    [Authorize]
    [HttpGet("user")]
    public ActionResult<IEnumerable<Keep>> GetByUserId(int id)
    {
      try
      {
        string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        if (userId == null)
        {
          throw new Exception("you need to be loged in to get keeps by userid");
        }
        return Ok(_ks.GetByUserId(userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      };
    }
    [HttpGet("{id}")]
    public ActionResult<Keep> get(int id)
    {
      try
      {
        string userId = "";
        var claim = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if (claim != null)
        {
          userId = claim.Value;
        }
        return Ok(_ks.Get(id, userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      };
    }
    [HttpPost]
    [Authorize]
    public ActionResult<Keep> post([FromBody] Keep newKeep)
    {
      try
      {
        newKeep.UserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_ks.Create(newKeep));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [Authorize]
    [HttpPut("{id}")]
    public ActionResult<Keep> Edit([FromBody] Keep editKeep, int id)
    {
      try
      {
        editKeep.UserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        editKeep.Id = id;
        if (editKeep.UserId == null)
        {
          throw new Exception("no user id provided");
        }
        return _ks.Edit(editKeep);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpDelete("{id}")]
    [Authorize]
    public ActionResult<Keep> Delete(int id)
    {
      string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
      if (userId == null)
      {
        throw new Exception("no id provided...");
      }
      try
      {
        return Ok(_ks.Delete(id, userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}