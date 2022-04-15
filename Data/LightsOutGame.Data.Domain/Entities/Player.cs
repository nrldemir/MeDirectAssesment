using LightsOutGame.Data.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightsOutGame.Data.Domain.Entities
{
    public class Player : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BoardSize { get; set; }
        public bool IsWinned { get; set; }
    }
}
