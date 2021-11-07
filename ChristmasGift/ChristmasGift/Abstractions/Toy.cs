using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ChristmasGift.Abstractions
{
    public abstract class Toy : Label
    {
        public Toy()
        {
            this.AutoSize = false;
            this.Width = 50;
            this.Height = this.Width;
            this.Paint += Toy_Paint;
        }

        private void Toy_Paint(object sender, PaintEventArgs e)
        {
            DrawImage(e.Graphics);
        }

        protected abstract void DrawImage(Graphics input);

        public virtual void MoveToy()
        {
            this.Left += 1;
        }
    }
}
