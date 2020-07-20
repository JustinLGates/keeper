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

    internal object Delete(int id)
    {
      return _repo.Delete(id);
    }

    internal object GetById(int id, string userId)
    {
      return _repo.GetById(id, userId);
    }
  }
}
