using MyDotNetFramework.Domain;
using MyDotNetFramework.IDao;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MyDotNetFramework.Dao
{
    /// <summary>
    /// 数据访问层基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DaoBase<T> : IDisposable, IDaoBase<T> where T : DomainBase
    {
        protected readonly DbContext DbContext;

        /// <summary>
        /// 增加        
        /// </summary>
        /// <param name="Domain"></param>
        /// <returns></returns>
        public int Insert(T Domain)
        {
            Domain.CreateTime = DateTime.Now;
            DbContext.Entry(Domain);
            DbContext.Set<T>().Add(Domain);
            return SaveChanges();
        }

        /// <summary>
        /// 通过ID删除
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool Delete(int ID)
        {
            T domain = DbContext.Set<T>().FirstOrDefault(_ => _.ID == ID);
            if (domain == null)
                return false;
            DbContext.Set<T>().Attach(domain);
            DbContext.Set<T>().Remove(domain);
            return SaveChanges() > 0;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Domain"></param>
        /// <returns></returns>
        public bool Delete(T Domain)
        {
            DbContext.Set<T>().Attach(Domain);
            DbContext.Set<T>().Remove(Domain);
            return SaveChanges() > 0;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="Domain"></param>
        /// <returns></returns>
        public bool Update(T Domain)
        {
            DbContext.Set<T>().Attach(Domain);
            DbContext.Entry(Domain).State = EntityState.Modified;
            return SaveChanges() > 0;
        }

        /// <summary>
        /// 通过ID查询
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public T SelectByID(int ID)
        {
            return DbContext.Set<T>().FirstOrDefault(_ => _.ID == _.ID);
        }

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> SelectAll()
        {
            return DbContext.Set<T>();
        }

        /// <summary>
        /// 提交数据库操作进行异常捕捉
        /// </summary>
        /// <returns></returns>
        private int SaveChanges()
        {
            try
            {
                int result = DbContext.SaveChanges();
                return result;
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                string message = "error:";
                if (ex.InnerException == null)
                    message += ex.Message + ",";
                else if (ex.InnerException.InnerException == null)
                    message += ex.InnerException.Message + ",";
                else if (ex.InnerException.InnerException.InnerException == null)
                    message += ex.InnerException.InnerException.Message + ",";
                throw new Exception(message);
            }
        }

        /// <summary>
        /// 释放
        /// </summary>
        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
