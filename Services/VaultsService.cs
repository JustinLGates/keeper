using System;
using System.Collections.Generic;
using System.Data;
using keepr.Models;
using keepr.Repositories;



namespace keepr.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _repo;
    public VaultsService(VaultsRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Vault> Get(string userId)
    {
      return _repo.Get(userId);
    }

    public Vault Create(Vault newVault)
    {
      return _repo.Create(newVault);
    }

    internal bool Delete(int id, string userId)
    {
      Vault found = GetById(id, userId);
      if (found == null)
      {
        throw new NullReferenceException("no vault by that id");
      }
      else if (found.UserId == userId)
      {
        return _repo.Delete(id);
      }
      else return false;
    }

    internal Vault GetById(int id, string userId)
    {
      return _repo.GetById(id, userId);
    }
  }
}
