using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValueAtRisk.Entities;

namespace ValueAtRisk
{
    public partial class Form1 : Form
    {
        List<Tick> ticks;
        List<PortfolioItem> Portfolio = new List<PortfolioItem>();
        PortfolioEntities context = new PortfolioEntities();
        List<decimal> roi;
        
        public Form1()
        {
            InitializeComponent();
            ticks = context.Ticks.ToList();
            dataGridView1.DataSource = ticks;
            CreatePortfolio();

            roi = new List<decimal>();
            int interval = 30;
            DateTime startDate = (from x in ticks select x.TradingDay).Min();
            DateTime endDate = new DateTime(2016, 12, 30);
            TimeSpan z = endDate - startDate;

            for (int i = 0; i < z.Days - interval; i++)
            {
                decimal ny = GetPortfolioValue(startDate.AddDays(i + interval)) - GetPortfolioValue(startDate.AddDays(i));
                roi.Add(ny);
                Console.WriteLine(i + " " + ny);
            }

            var orderedRoi = (from x in roi
                              orderby x
                              select x).ToList();

            MessageBox.Show(orderedRoi[orderedRoi.Count() / 5].ToString());
        }

        private void CreatePortfolio()
        {
            Portfolio.Add(new PortfolioItem() { Index = "OTP", Volume = 10 });
            Portfolio.Add(new PortfolioItem() { Index = "ZWACK", Volume = 10 });
            Portfolio.Add(new PortfolioItem() { Index = "ELMU", Volume = 10 });

            dataGridView2.DataSource = Portfolio;
        }

        private decimal GetPortfolioValue(DateTime date)
        {
            decimal value = 0;
            foreach (var item in Portfolio)
            {
                var last = (from x in ticks
                            where item.Index == x.Index.Trim()
                            && date <= x.TradingDay
                            select x).First();
                value += (decimal)last.Price * item.Volume;
            }
            return value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "csv";
            if (sfd.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.Default))
                {
                    sw.WriteLine("Időszak" + "," + "Nyereség");

                    var orderedRoi = (from x in roi
                                      orderby x
                                      select x).ToList();

                    int counter = 1;
                    foreach (var item in roi)
                    {
                        sw.WriteLine($"{counter},{roi[counter-1]}");
                        counter++;
                    }
                }
            }
        }
    }
}
