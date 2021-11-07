using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ChristmasGift.Abstractions;

namespace ChristmasGift.Entities
{
    public class Ball : Toy
    {
        protected override void DrawImage(Graphics input)
        {
            input.FillEllipse(new SolidBrush(Color.Blue), 0, 0, Width, Height);
        }
    }
}
