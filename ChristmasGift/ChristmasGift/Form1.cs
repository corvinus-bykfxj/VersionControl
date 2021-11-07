using ChristmasGift.Abstractions;
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
        List<Toy> _toys = new List<Toy>();
        private IToyFactory _factory;
        public IToyFactory Factory
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
            foreach (Ball item in _toys)
            {
                item.MoveToy();
                if (item.Left > rightPosition)
                {
                    rightPosition = item.Left;
                }
            }

            if (rightPosition >= 1000)
            {
                Toy oldestToy = new Ball();
                oldestToy = _toys.First();
                _toys.Remove(oldestToy);
                Controls.Remove(oldestToy);
            }
        }

        private void createTimer_Tick(object sender, EventArgs e)
        {
            Toy toy = new Ball();
            toy = Factory.CreateNew();

            _toys.Add(toy);
            mainPanel.Controls.Add(toy);
            toy.Left = -toy.Width;
        }
    }
}
