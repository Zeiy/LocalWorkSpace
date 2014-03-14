using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccess.Model
{
    public class GameServer
    {
        public int ID { get; set; }
        public string ServerName { get; set; }
        public int AreaID { get; set; }
        public int GameID { get; set; }
        public string GameName { get; set; }
        public string AreaName { get; set; }
    }
}