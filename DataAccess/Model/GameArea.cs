using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccess.Model
{
    public class GameArea
    {
        public int ID { get; set; }
        public string AreaName { get; set; }
        /// <summary>
        /// 所属游戏ID
        /// </summary>
        public int GameID { get; set; }

    }
}