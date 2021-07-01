using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace {{ProjectInfo.FullName}}.{{EntityInfo.RelativeDirectory}}
{
    public interface I{{ EntityInfo.Name }}Service 
    {
        Task<{{ EntityInfo.Name }}> InsertAsync({{ EntityInfo.Name }} entity);

        Task<{{ EntityInfo.Name }}> UpdateAsync({{ EntityInfo.Name }} entity);

        Task<{{ EntityInfo.Name }}> GetByIdAsync({{EntityInfo.PrimaryKey}} id);

        Task InsertAsync(IList<{{ EntityInfo.Name }}> entities);

        Task DeleteAsync({{ EntityInfo.Name }} entity);

        Task<IQueryable<{{ EntityInfo.Name }}>> GetQueryableAllAsync();

        Task<long> GetCountAsync();

        Task<bool> Exist({{EntityInfo.PrimaryKey}} id);
    }
    
}