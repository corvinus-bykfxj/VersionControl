using ChristmasGift.Abstractions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristmasGift.Entities
{
    class Car : Toy
    {
        protected override void DrawImage(Graphics input)
        {
            Image imageFile = Image.FromFile("Images/car.png");
            input.DrawImage(imageFile, new Rectangle(0, 0, Width, Height));
        }
    }
}
