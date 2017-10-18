using System.Collections.Generic;

namespace MyNetFramework.IDao
{
    public interface IDaoBase<T> where T : class
    {
        /// <summary>
        /// 增加        
        /// </summary>
        /// <param name="Domain">实体</param>
        /// <returns></returns>
        int Insert(T Domain);

        /// <summary>
        /// 通过ID删除
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        bool Delete(int ID);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Domain">实体</param>
        /// <returns></returns>
        bool Delete(T Domain);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="domain">实体</param>
        /// <returns></returns>
        bool Update(T domain);

        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="ID">Id</param>
        /// <returns></returns>
        T SelectByID(int ID);

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> SelectAll();

    }
}
