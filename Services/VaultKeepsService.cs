using keepr.Models;
using keepr.Repositories;

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
  }
}