using ChristmasGift.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChristmasGift
{
    public partial class Form1 : Form
    {
        List<Ball> _balls = new List<Ball>();
        private BallFactory _factory;
        public BallFactory Factory
        {
            get { return _factory; }
            set { _factory = value; }
        }


        public Form1()
        {
            InitializeComponent();
            Factory = new BallFactory();
        }

        private void conveyorTimer_Tick(object sender, EventArgs e)
        {
            int rightPosition = 0;
            foreach (Ball item in _balls)
            {
                item.MoveBall();
                if (item.Left > rightPosition)
                {
                    rightPosition = item.Left;
                }
            }

            if (rightPosition >= 1000)
            {
                Ball oldestBall = new Ball();
                oldestBall = _balls.First();
                _balls.Remove(oldestBall);
                Controls.Remove(oldestBall);
            }
        }

        private void createTimer_Tick(object sender, EventArgs e)
        {
            Ball ball = new Ball();
            ball = Factory.CreateNew();

            _balls.Add(ball);
            mainPanel.Controls.Add(ball);
            ball.Left = -ball.Width;
        }
    }
}
