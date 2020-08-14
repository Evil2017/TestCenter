using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using TestCenter.Util;

namespace TestCenter.Entity
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-08-14 09:26
    /// 描 述：浆站实体类
    /// </summary>
    [Table("sysbank")]
    public class BankEntity : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string AreaCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string BankCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string BankID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string BankName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string BankNameAll { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? BatchNums { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? ChooseNums { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string City { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? ExceedOneNums { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? InStockNums { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Leader { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string LedgerCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? Online { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string OrgId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? PassNums { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Province { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? QualifiedNums { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ServerUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Tel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? WaitNums { get; set; }
    }
}
