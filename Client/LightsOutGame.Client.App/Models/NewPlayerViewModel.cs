using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightsOutGame.Client.App.Models
{
    public class NewPlayerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BoardSize { get; set; }
        public bool IsWinned { get; set; }
    }

}
