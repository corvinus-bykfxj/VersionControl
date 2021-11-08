using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ChristmasGift.Abstractions;

namespace ChristmasGift.Entities
{
    public class Present : Toy
    {
        public Pen PresentRibbon { get; private set; }
        public SolidBrush PresentBox { get; private set; }

        public Present(Color ribbon, Color box)
        {
            PresentRibbon = new Pen(ribbon, Width/5);
            PresentBox = new SolidBrush(box);

        }
        protected override void DrawImage(Graphics input)
        {
            input.FillRectangle(PresentBox, 0, 0, Width, Height);
            input.DrawLine(PresentRibbon, Width / 2, 0, Width / 2, Height);
            input.DrawLine(PresentRibbon, 0, Height / 2, Width, Height / 2);
        }
    }
}
