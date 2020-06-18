using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.DTO
{
    public class PartyDTO
    {
        public int ID { get; set; }
        public string Abbreviation { get; set; }
        public string Name { get; set; }
        public string Leader { get; set; }
        public List<PartyDTO> History { get; set; }
    }
}
