using System;
using keepr.Models;
using keepr.Repositories;
using Keepr.Models;
using System.Collections.Generic;

namespace keepr.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _repo;
    public VaultKeepsService(VaultKeepsRepository repo)
    {
      _repo = repo;
    }
    internal VaultKeeps Create(VaultKeeps newVaultKeeps)
    {
      return _repo.Create(newVaultKeeps);
    }

    internal IEnumerable<Keep> Get(Vault vault)
    {
      return _repo.getKeepByVaultId(vault);
    }

  }
}