using LightsOutGame.Data.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightsOutGame.Data.Domain.Entities
{
    public class GameSetting : Entity
    {
        public int BoardSizeX { get; set; }
        public int BoardSizeY { get; set; }
    }
}
