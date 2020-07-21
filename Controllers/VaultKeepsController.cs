using System;
using System.Collections.Generic;
using System.Security.Claims;
using keepr.Models;
using keepr.Services;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{

  [Authorize]
  [ApiController]
  [Route("api/[controller]")]
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsService _vks;

    public VaultKeepsController(VaultKeepsService vks)
    {
      _vks = vks;
    }

    [HttpPost]
    public ActionResult<VaultKeep> create([FromBody] VaultKeep vaultKeep)
    {
      try
      {
        vaultKeep.UserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return _vks.Create(vaultKeep);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]

    public ActionResult<bool> Delete(int id)
    {
      try
      {
        string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        if (userId == null)
        {
          throw new Exception("no user id provided");
        }
        return _vks.Delete(id, userId);

      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}