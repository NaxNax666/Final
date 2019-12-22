using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using game;
using game.BattleArmyClasses;
using game.MarchingArmy;
using game.Units;

namespace GAMEOFTHEYEAR
{
    public partial class Form4 : Form
    {
        public Form4((BattleUnitsStack, TypeOfArmy) currentBattleStack)
        {
            InitializeComponent();
            foreach (var stack in currentBattleStack.Item1.Magic)
            {
                this.comboBox1.Items.Add(stack);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Config.Magic = comboBox1.SelectedIndex + 1;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Config.Magic = -1;
            this.Close();
        }
    }
}
