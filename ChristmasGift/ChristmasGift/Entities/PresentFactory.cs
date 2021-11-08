using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChristmasGift.Abstractions;

namespace ChristmasGift.Entities
{
    public class PresentFactory : IToyFactory
    {
        public Color PresentRibbon { get; set; }

        public Color PresentBox { get; set; }

        public Toy CreateNew()
        {
            return new Present(PresentRibbon, PresentBox);
        }
    }
}
