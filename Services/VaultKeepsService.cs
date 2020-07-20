using System;
using keepr.Models;
using keepr.Repositories;
using Keepr.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _repo;
    public VaultKeepsService(VaultKeepsRepository repo)
    {
      _repo = repo;
    }
    internal VaultKeep Create(VaultKeep vaultKeep)
    {
      return _repo.Create(vaultKeep);
    }

    internal IEnumerable<VaultKeepViewModel> getKeepsByVaultId(int id, string userId)
    {
      return _repo.getKeepByVaultId(id, userId);
    }

    internal string Delete(int id, string userId)
    {
      return _repo.Delete(id, userId);
    }
  }
}