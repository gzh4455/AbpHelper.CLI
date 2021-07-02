using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.DependencyInjection;

namespace {{ProjectInfo.FullName}}.{{EntityInfo.RelativeDirectory}}
{
    public class {{EntityInfo.Name }}Service:I{{EntityInfo.Name}}Service,ITransientDependency
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

        public async Task<{{EntityInfo.Name }}> GetByIdAsync(string id,bool includeDetail)
        {
            return await _{{EntityInfo.NameCamel}}Repository.FindAsync(x=>x.Id==id,includeDetail);
        }

        public async  Task DeleteAsync({{EntityInfo.Name }} entity)
        {
            await _{{EntityInfo.NameCamel}}Repository.DeleteAsync(entity);
        }

        public async Task InsertAsync(IList<{{EntityInfo.Name }}> entities)
        {
            var db = await _{{EntityInfo.NameCamel}}Repository.GetDbContextAsync();
            await db.BulkInsertAsync(typeof({{EntityInfo.Name }}), entities);
        }

        public Task<IQueryable<{{EntityInfo.Name }}>> GetQueryableAllAsync()
        {
            return _{{EntityInfo.NameCamel}}Repository.GetQueryableAsync();
        }

        public Task<long> GetCountAsync()
        {
            return _{{EntityInfo.NameCamel}}Repository.GetCountAsync();
        }

        public Task<bool> ExistAsync(string id)
        {
            return _{{EntityInfo.NameCamel}}Repository.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> BulkInsertOrUpdateAsync(IList<{{EntityInfo.Name }}> entities)
        {
            var db= await _{{EntityInfo.NameCamel}}Repository.GetDbContextAsync();
            await db.BulkMergeAsync(typeof({{EntityInfo.Name }}), entities);
            return true;
        }

        public async Task MergeAsync(Project entity)
        {
            var db= await _{{EntityInfo.NameCamel}}Repository.GetDbContextAsync();
            await db.SingleMergeAsync(entity);
        }
    }
    
}