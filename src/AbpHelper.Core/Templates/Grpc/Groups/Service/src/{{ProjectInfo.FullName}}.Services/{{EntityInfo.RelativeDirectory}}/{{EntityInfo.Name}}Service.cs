using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace {{ProjectInfo.FullName}}.{{EntityInfo.RelativeDirectory}}
{
    public class {{EntityInfo.Name }}Service:I{{EntityInfo.Name}}Service
    {
        private readonly IRepository<{{EntityInfo.Name }}> _{{EntityInfo.NameCamel}}Repository;

        public {{EntityInfo.Name }}Service(IRepository<{{EntityInfo.Name }}> {{EntityInfo.NameCamel}}Repository)
        {
            _{{EntityInfo.NameCamel}}Repository = {{EntityInfo.NameCamel}}Repository;
        }
        public async Task<{{EntityInfo.Name }}> InsertAsync({{EntityInfo.Name }} entity)
        {
            return await _{{EntityInfo.NameCamel}}Repository.InsertAsync(entity);
        }

        public async Task<{{EntityInfo.Name }}> UpdateAsync({{EntityInfo.Name }} entity)
        {
            return await _{{EntityInfo.NameCamel}}Repository.UpdateAsync(entity);
        }

        public async Task<{{EntityInfo.Name }}> GetByIdAsync(string id)
        {
            return await _{{EntityInfo.NameCamel}}Repository.GetAsync(x=>x.Id==id);
        }

        public async  Task DeleteAsync({{EntityInfo.Name }} entity)
        {
            await _{{EntityInfo.NameCamel}}Repository.DeleteAsync(entity);
        }

        public async Task InsertAsync(IList<{{EntityInfo.Name }}> entities)
        {
            await _{{EntityInfo.NameCamel}}Repository.InsertManyAsync(entities);
        }

        public Task<IQueryable<{{EntityInfo.Name }}>> GetQueryableAllAsync()
        {
            return _{{EntityInfo.NameCamel}}Repository.GetQueryableAsync();
        }

        public Task<long> GetCountAsync()
        {
            return _{{EntityInfo.NameCamel}}Repository.GetCountAsync();
        }

        public Task<bool> Exist(string id)
        {
            return _{{EntityInfo.NameCamel}}Repository.AnyAsync(x => x.Id == id);
        }
    }
    
}