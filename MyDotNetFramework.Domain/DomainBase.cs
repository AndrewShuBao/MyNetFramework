using System;

namespace MyDotNetFramework.Domain
{
    /// <summary>
    /// 基础实体类
    /// </summary>
    public class DomainBase
    {
        /// <summary>
        /// 主键/编号
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
