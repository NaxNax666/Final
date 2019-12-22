using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using game.BattleArmyClasses;
using game.MarchingArmy;
using game.Units;
using game;


namespace GAMEOFTHEYEAR
{
    public partial class Form3 : Form
    {
        public Form3(BattleArmy attackedArmy,bool wiz)
        {
            InitializeComponent();
            if (!wiz)
            {
                foreach (var stack in attackedArmy.StacksList)
                {
                    if (stack.IsAlive)
                        this.comboBox1.Items.Add(stack);
                }
            }
            else
            {
                foreach (var stack in attackedArmy.StacksList)
                {
                     this.comboBox1.Items.Add(stack);
                }
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Config.Target = comboBox1.SelectedIndex + 1;
            this.Close();
        }
    }
}
