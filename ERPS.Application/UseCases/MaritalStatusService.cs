﻿using NetCore.Models;
using NetCore.Repositories.Interfaces;
using NetCore.Services.Interfaces;

namespace ERPS.Application.UseCases
{
    public class MaritalStatusService : IMaritalStatusService
    {
        private readonly IMaritalStatusRepository _repo;

        public MaritalStatusService(IMaritalStatusRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<MaritalStatus>> GetAllAsync(string[] includes)
        {
            return await _repo.GetAllAsync(includes);
        }

        public async Task<MaritalStatus> GetByIDAsync(int id)
        {
            return await _repo.GetByIDAsync(id);
        }

        public async Task<MaritalStatus> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }

        public async Task<MaritalStatus> UpdateAsync(int id, MaritalStatus data)
        {
            return await _repo.UpdateAsync(id, data);
        }

        public async Task<MaritalStatus> CreateAsync(MaritalStatus data)
        {
            data.ID = await _repo.GetMaxID();
            return await _repo.CreateAsync(data);
        }
    }
}