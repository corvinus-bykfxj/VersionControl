﻿using MicroSimulation.Entities;
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

namespace MicroSimulation
{
    public partial class Form1 : Form
    {
        List<Person> Population = new List<Person>();
        List<BirthProbability> BirthProbabilities = new List<BirthProbability>();
        List<DeathProbability> DeathProbabilities = new List<DeathProbability>();

        List<int> FemalePopulation = new List<int>();
        List<int> MalePopulation = new List<int>();

        Random rng = new Random(1234);
        public Form1()
        {
            InitializeComponent();
        }

        public List<Person> GetPopulation(string csvpath)
        {
            List<Person> population = new List<Person>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    population.Add(new Person()
                    {
                        BirthYear = int.Parse(line[0]),
                        Gender = (Gender)Enum.Parse(typeof(Gender), line[1]),
                        NbrOfChildren = int.Parse(line[2])
                    });
                }
            }

            return population;
        }

        public List<BirthProbability> GetBirthProbabilities(string csvpath)
        {
            List<BirthProbability> probabilities = new List<BirthProbability>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    probabilities.Add(new BirthProbability()
                    {
                        Age = int.Parse(line[0]),
                        NbrOfChildren = int.Parse(line[1]),
                        BProbability = double.Parse(line[2])
                    });
                }
            }

            return probabilities;
        }

        public List<DeathProbability> GetDeathProbabilities(string csvpath)
        {
            List<DeathProbability> probabilities = new List<DeathProbability>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine().Split(';');
                    probabilities.Add(new DeathProbability()
                    {
                        Age = int.Parse(line[0]),
                        Gender = (Gender)Enum.Parse(typeof(Gender), line[1]),
                        DProbability = double.Parse(line[2])
                    });
                }
            }

            return probabilities;
        }

        public void SimStep(int year, Person person)
        {
            //Ha meghalt, akkor kihagyjuk és tovább ugrunk a következő lépésre
            if (!person.IsAlive) return;

            //Az életkor tárolása helyben hogy ne kelljen mindig kiszámolni
            byte age = (byte)(year - person.BirthYear);

            //Halál lekezelése
            //Halálozási valószínűség lekérdezése
            double pDeath = (from x in DeathProbabilities
                             where x.Gender == person.Gender && x.Age == age
                             select x.DProbability).FirstOrDefault();

            //Meghal-e a személy
            if (rng.NextDouble() <= pDeath)
            {
                person.IsAlive = false;
            }

            //Születés lekezelése - csak az élő nők szülhetnek természetesen
            if (person.IsAlive && person.Gender == Gender.Female)
            {
                //Születési valószínűség kikeresése
                double pBirth = (from x in BirthProbabilities
                                 where x.Age == age
                                 select x.BProbability).FirstOrDefault();

                //Születik-e gyermeke
                if (rng.NextDouble() <= pBirth)
                {
                    Person newborn = new Person();
                    newborn.BirthYear = year;
                    newborn.NbrOfChildren = 0;
                    newborn.Gender = (Gender)(rng.Next(1, 3));
                    Population.Add(newborn);
                }
            }
        }

        public void Simulation()
        {
            Population = GetPopulation(@"D:\Letöltések\nép-teszt.csv");
            BirthProbabilities = GetBirthProbabilities(@"D:\Letöltések\születés.csv");
            DeathProbabilities = GetDeathProbabilities(@"D:\Letöltések\halál.csv");

            //Végigmegyünk a vizsgált éveken
            for (int year = 2005; year <= int.Parse(YearTextBox.Text); year++)
            {
                //Végigmegyünk az összes személyen
                for (int i = 0; i < Population.Count; i++)
                {
                    SimStep(year, Population[i]);
                }

                int nbrOfMales = (from x in Population
                                  where x.Gender == Gender.Male && x.IsAlive
                                  select x).Count();
                MalePopulation.Add(nbrOfMales);

                int nbrOfFemales = (from x in Population
                                    where x.Gender == Gender.Female && x.IsAlive
                                    select x).Count();
                FemalePopulation.Add(nbrOfFemales);
            }
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                PopulationFileNameTextBox.Text = ofd.FileName;
            }
            else
            {
                return;
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            Simulation();
            DisplayResults();
        }

        public void DisplayResults()
        {
            DisplayData_RichTextBox.Clear();
            int i = 0;
            for (int year = 2005; year <= int.Parse(YearTextBox.Text); year++)
            {
                DisplayData_RichTextBox.Text += string.Format($"Szimulációs év: {year}" +
                    $"\n\tFiúk: {MalePopulation[i]}" +
                    $"\n\tLányok: {FemalePopulation[i]}" +
                    "\n\n");
                i++;
            }
        }
    }
}
