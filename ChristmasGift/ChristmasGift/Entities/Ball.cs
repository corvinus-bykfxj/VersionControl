using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ChristmasGift.Entities
{
    class Ball : Label
    {
        public Ball()
        {
            this.AutoSize = false;
            this.Width = 50;
            this.Height = this.Width;
            this.Paint += Ball_Paint;
        }

        private void Ball_Paint(object sender, PaintEventArgs e)
        {
            DrawImage(e.Graphics);
        }

        protected void DrawImage(Graphics input)
        {
            input.FillEllipse(new SolidBrush(Color.Blue), 0, 0, Width, Height);
        }

        public void MoveBall()
        {
            this.Left += 1;
        }
    }
}
