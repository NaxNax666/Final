using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GAMEOFTHEYEAR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int an = Convert.ToInt32(numericUpDown1.Value);
            int ar = Convert.ToInt32(numericUpDown2.Value);
            int bd = Convert.ToInt32(numericUpDown3.Value);
            int cy = Convert.ToInt32(numericUpDown4.Value);
            int de = Convert.ToInt32(numericUpDown5.Value);
            int fu = Convert.ToInt32(numericUpDown6.Value);
            int gr = Convert.ToInt32(numericUpDown7.Value);
            int hy = Convert.ToInt32(numericUpDown8.Value);
            int li = Convert.ToInt32(numericUpDown9.Value);
            int sh = Convert.ToInt32(numericUpDown10.Value);
            int sk = Convert.ToInt32(numericUpDown11.Value);

            game.Units.Angel angel = new game.Units.Angel();
            
            game.Units.Devil devil = new game.Units.Devil();
            game.Units.Arbalester arbalester = new game.Units.Arbalester();
            game.Units.BoneDragon boneDragon = new game.Units.BoneDragon();
            game.Units.Cyclops cyclops = new game.Units.Cyclops();
            game.Units.Fury fury = new game.Units.Fury();
            game.Units.Griffin griffin = new game.Units.Griffin();
            game.Units.Shaman shaman = new game.Units.Shaman();
            game.Units.Skeleton skeleton = new game.Units.Skeleton();
            game.Units.Lich lich = new game.Units.Lich();
            game.Units.Hydra hydra = new game.Units.Hydra();

            game.MarchingArmy.UnitsStack stack1= null;
            game.MarchingArmy.UnitsStack stack2 = null;
            game.MarchingArmy.UnitsStack stack3 = null;
            game.MarchingArmy.UnitsStack stack4 = null;
            game.MarchingArmy.UnitsStack stack5 = null;
            game.MarchingArmy.UnitsStack stack6 = null;
            game.MarchingArmy.UnitsStack stack7 = null;
            game.MarchingArmy.UnitsStack stack8 = null;
            game.MarchingArmy.UnitsStack stack9 = null;
            game.MarchingArmy.UnitsStack stack10 = null;
            game.MarchingArmy.UnitsStack stack11 = null;
            if (an!=0)
                stack1 = new game.MarchingArmy.UnitsStack(angel, an);
            if (ar != 0)
                stack2 = new game.MarchingArmy.UnitsStack(arbalester, ar);
            if (bd != 0)
                stack3 = new game.MarchingArmy.UnitsStack(boneDragon, bd);
            if (cy != 0)
                stack4 = new game.MarchingArmy.UnitsStack(cyclops, cy);
            if (de != 0)
                stack5 = new game.MarchingArmy.UnitsStack(devil, de);
            if (fu != 0)
                stack6 = new game.MarchingArmy.UnitsStack(fury, fu);
            if (gr != 0)
                stack7 = new game.MarchingArmy.UnitsStack(griffin, gr);
            if (hy != 0)
                stack8 = new game.MarchingArmy.UnitsStack(hydra, hy);
            if (li != 0)
                stack9 = new game.MarchingArmy.UnitsStack(lich, li);
            if (sh != 0)
                stack10 = new game.MarchingArmy.UnitsStack(shaman, sh);
            if (sk != 0)
                stack11 = new game.MarchingArmy.UnitsStack(skeleton, sk);
            List<game.MarchingArmy.UnitsStack> unitsStacks = new List<game.MarchingArmy.UnitsStack>() { stack1, stack2, stack3, stack4, stack5,stack6,stack7,stack8,stack9,stack10,stack11 };
            unitsStacks.RemoveAll(item => item == null);
            game.MarchingArmy.Army usArmy1 = null;
            game.MarchingArmy.Army usArmy2 = null;
            try
            {
                usArmy1 = new game.MarchingArmy.Army(unitsStacks);
            }
            catch (ArgumentException)
            {
                MessageBox.Show(
            "Игрок 1 Неверное количество отрядов! Исправьте на число из отрезка[1,6]",
           "Ошибка",
           MessageBoxButtons.OK,
           MessageBoxIcon.Error);

            }

            stack1 = null;
            stack2 = null;
            stack3 = null;
            stack4 = null;
            stack5 = null;
            stack6 = null;
            stack7 = null;
            stack8 = null;
            stack9 = null;
            stack10 = null;
            stack11 = null;
            an = Convert.ToInt32(numericUpDown12.Value);
            ar = Convert.ToInt32(numericUpDown13.Value);
            bd = Convert.ToInt32(numericUpDown14.Value);
            cy = Convert.ToInt32(numericUpDown15.Value);
            de = Convert.ToInt32(numericUpDown16.Value);
            fu = Convert.ToInt32(numericUpDown17.Value);
            gr = Convert.ToInt32(numericUpDown18.Value);
            hy = Convert.ToInt32(numericUpDown19.Value);
            li = Convert.ToInt32(numericUpDown20.Value);
            sh = Convert.ToInt32(numericUpDown21.Value);
            sk = Convert.ToInt32(numericUpDown22.Value);
            if (an != 0)
                stack1 = new game.MarchingArmy.UnitsStack(angel, an);
            if (ar != 0)
                stack2 = new game.MarchingArmy.UnitsStack(arbalester, ar);
            if (bd != 0)
                stack3 = new game.MarchingArmy.UnitsStack(boneDragon, bd);
            if (cy != 0)
                stack4 = new game.MarchingArmy.UnitsStack(cyclops, cy);
            if (de != 0)
                stack5 = new game.MarchingArmy.UnitsStack(devil, de);
            if (fu != 0)
                stack6 = new game.MarchingArmy.UnitsStack(fury, fu);
            if (gr != 0)
                stack7 = new game.MarchingArmy.UnitsStack(griffin, gr);
            if (hy != 0)
                stack8 = new game.MarchingArmy.UnitsStack(hydra, hy);
            if (li != 0)
                stack9 = new game.MarchingArmy.UnitsStack(lich, li);
            if (sh != 0)
                stack10 = new game.MarchingArmy.UnitsStack(shaman, sh);
            if (sk != 0)
                stack11 = new game.MarchingArmy.UnitsStack(skeleton, sk);
            unitsStacks = new List<game.MarchingArmy.UnitsStack>() { stack1, stack2, stack3, stack4, stack5, stack6, stack7, stack8, stack9, stack10, stack11 };
            unitsStacks.RemoveAll(item => item == null);
            bool f = true;
            try
            {
                usArmy2 = new game.MarchingArmy.Army(unitsStacks);

                
            }
            catch (ArgumentException)
            {
                f = false;
                MessageBox.Show(
            "Игрок 2 Неверное количество отрядов! Исправьте на число из отрезка[1,6]",
           "Ошибка",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);

            }
            if (f) { 
                Form2 form2 = new Form2(usArmy1, "Игрок 1", usArmy2, "Игрок 2");
                form2.ShowDialog();
            }


        }

        private void numericUpDown10_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
