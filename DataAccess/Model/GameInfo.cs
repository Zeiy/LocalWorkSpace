using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccess.Model
{
    /// <summary>
    /// 游戏相关信息，大区，区服信息
    /// </summary>
    public class GameInfo
    {
        public int ID { get; set; }
        public string GameName { get; set; }
        public DateTime AddTime { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public string OperationName { get; set; }
    }
}