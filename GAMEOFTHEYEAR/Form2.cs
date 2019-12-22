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
    public partial class Form2 : Form
    {
        private BattleArmy FirstBattleArmy;
        private BattleArmy SecondBattleArmy;
        private InitiativeScale ScaLe;
        private BattleArmy Winner;
        private Attacker Attacker;
        private Wizard Wizard;
        private string reason;
        private bool HasBattleEnded => !FirstBattleArmy.IsArmyAlive() || !SecondBattleArmy.IsArmyAlive() || Winner != null;


        private void Wait((BattleUnitsStack, TypeOfArmy) stackInScale)
        {
            ScaLe.WaitScale.Add(stackInScale);
            ComparerOfWaitInitiative comparerOfWaitInitiative = new ComparerOfWaitInitiative();
            ScaLe.WaitScale.Sort(comparerOfWaitInitiative);
        }

        private void Defend(BattleUnitsStack currentBattleUnitsStack)
        {
            currentBattleUnitsStack.Effects.Add((TypeOfEffect.IsDefends, 1));
        }

        private void GiveUp((BattleUnitsStack, TypeOfArmy) stackInScale)
        {
            Winner = stackInScale.Item2 == TypeOfArmy.Second ? FirstBattleArmy : SecondBattleArmy;
            WhoWin();
            
       
        }


        private void WhoWin()
        {
            if (Winner == null)
            {
                Winner = FirstBattleArmy.IsArmyAlive() ? FirstBattleArmy : SecondBattleArmy;
                string name = FirstBattleArmy.IsArmyAlive() ? SecondBattleArmy.ArmyName : FirstBattleArmy.ArmyName;
                string res = $"В армии не осталось живих отрядов {name}\r\n Победа ";
                MessageBox.Show(
             res+ (!FirstBattleArmy.IsArmyAlive() ? SecondBattleArmy.ArmyName : FirstBattleArmy.ArmyName),
            "Победа",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
                
            }
            else
            {
                string res = "Армия " + (Winner.ArmyName == FirstBattleArmy.ArmyName ? SecondBattleArmy.ArmyName : FirstBattleArmy.ArmyName);
                res += " сдалась\r\n Победила команда " + Winner.ArmyName;
                MessageBox.Show(
                 res,
                "Победа",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
            this.Close();
        }



        public (BattleUnitsStack, TypeOfArmy) currentBattleStack;
        public Form2(Army firstArmy, string firstArmyName, Army secondArmy, string secondArmyName)
        {
            InitializeComponent();
            this.FirstBattleArmy = new BattleArmy(firstArmy, firstArmyName);
            this.SecondBattleArmy = new BattleArmy(secondArmy, secondArmyName);
            ScaLe = new InitiativeScale();
            Attacker = new Attacker();
            Wizard = new Wizard();
            ScaLe.MakeInitiativeScale(FirstBattleArmy, SecondBattleArmy);
            currentBattleStack = ScaLe.Scale[0];
            richTextBox2.Text=ScaLe+"\r\n";
            string name = currentBattleStack.Item2 == TypeOfArmy.First ? FirstBattleArmy.ArmyName : SecondBattleArmy.ArmyName;
            richTextBox1.Text += $"Ходит: {currentBattleStack.Item1} из Армии {name}\n";
            richTextBox3.Text = FirstBattleArmy.ToString();
            richTextBox4.Text = SecondBattleArmy.ToString();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Text+="Вы выбрали \"Каст\"\r\n";
            if (currentBattleStack.Item1.AmountOfAvailableMagic() > 0)
            {
                Form4 form4 = new Form4(currentBattleStack);
                form4.ShowDialog();
                int i = Config.Magic;
                int j = 0;

                if (i > 0)
                {
                    ScaLe.Scale.RemoveAt(0);
                    TypeOfMagic chosenMagic = currentBattleStack.Item1.AvailableMagicAt(i);
                    richTextBox1.Text += $"Вы выбрали {chosenMagic}\r\n";
                    BattleArmy toWhatArmyUseMagic;
                    if (chosenMagic == TypeOfMagic.Curse || chosenMagic == TypeOfMagic.Attenuation)
                        toWhatArmyUseMagic = currentBattleStack.Item2 == TypeOfArmy.First ? SecondBattleArmy : FirstBattleArmy;
                    else
                        toWhatArmyUseMagic = currentBattleStack.Item2 == TypeOfArmy.First ? FirstBattleArmy : SecondBattleArmy;
                    if (chosenMagic == TypeOfMagic.Resurrection)
                    {
                        Form3 form3 = new Form3(toWhatArmyUseMagic, true);
                        form3.ShowDialog();
                        j = Config.Target;
                    }
                    else
                    {
                        Form3 form3 = new Form3(toWhatArmyUseMagic, false);
                        form3.ShowDialog();
                        j = Config.Target;
                    }

                    ScaLe.Scale.RemoveAt(0);
                    richTextBox1.Text += Wizard.Wiz(currentBattleStack, FirstBattleArmy, SecondBattleArmy, ScaLe.Scale, i, j, toWhatArmyUseMagic, chosenMagic);
                }
                else
                    richTextBox1.Text += "Вы отказались от Каста\r\n";
            }
            ScaLe.SortScales();
            if (ScaLe.Scale.Count == 0 && ScaLe.WaitScale.Count == 0)
            {
                ScaLe.MakeInitiativeScale(FirstBattleArmy, SecondBattleArmy);
            }
            else if (ScaLe.Scale.Count == 0)
            {
                foreach (var s in ScaLe.WaitScale)
                {
                    ScaLe.Scale.Add(s);
                }
                ScaLe.WaitScale.Clear();
            }
            richTextBox2.Text = ScaLe + "\r\n";
            string name = currentBattleStack.Item2 == TypeOfArmy.First ? FirstBattleArmy.ArmyName : SecondBattleArmy.ArmyName;
            richTextBox1.Text += $"Ходит: {currentBattleStack.Item1} из Армии {name}\n";
            richTextBox3.Text = FirstBattleArmy.ToString();
            richTextBox4.Text = SecondBattleArmy.ToString();
            if (!FirstBattleArmy.IsArmyAlive() || !SecondBattleArmy.IsArmyAlive())
            {
                WhoWin();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string res = "";
            ScaLe.Scale.RemoveAt(0);
            BattleArmy attackedArmy =
                currentBattleStack.Item2 == TypeOfArmy.First ? SecondBattleArmy : FirstBattleArmy;
            richTextBox1.Text+="Вы выбрали \"Атаку\"\r\n";
            
            Form3 form3 = new Form3(attackedArmy,false);
            form3.ShowDialog();
            int i = Config.Target;



            List<BattleUnitsStack> attackedStacks = Attacker.Attack(currentBattleStack, attackedArmy, i,ref res);
            richTextBox1.Text += res;
            richTextBox3.Text = FirstBattleArmy.ToString();
            richTextBox4.Text = SecondBattleArmy.ToString();
            foreach (var stack in attackedStacks)
            {
                ScaLe.CheckAttackedStack(stack);
            }
            if (ScaLe.Scale.Count == 0 && ScaLe.WaitScale.Count == 0)
            {
                ScaLe.MakeInitiativeScale(FirstBattleArmy, SecondBattleArmy);
            }
            else if (ScaLe.Scale.Count == 0)
            {
                foreach (var s in ScaLe.WaitScale)
                {
                    ScaLe.Scale.Add(s);
                }
                ScaLe.WaitScale.Clear();
            }
            currentBattleStack = ScaLe.Scale[0];
            richTextBox2.Text = ScaLe + "\r\n";
            string name = currentBattleStack.Item2 == TypeOfArmy.First ? FirstBattleArmy.ArmyName : SecondBattleArmy.ArmyName;
            richTextBox1.Text += $"Ходит: {currentBattleStack.Item1} из армии {name}\n";
            if (!FirstBattleArmy.IsArmyAlive() || !SecondBattleArmy.IsArmyAlive())
            {
                WhoWin();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ScaLe.Scale.RemoveAt(0);
            richTextBox1.Text+="Вы выбрали \"Защиту\"\r\n";
            Defend(currentBattleStack.Item1);
            if (ScaLe.Scale.Count == 0 && ScaLe.WaitScale.Count == 0)
            {
                ScaLe.MakeInitiativeScale(FirstBattleArmy, SecondBattleArmy);
            }
            else if (ScaLe.Scale.Count == 0)
            {
                foreach (var s in ScaLe.WaitScale)
                {
                    ScaLe.Scale.Add(s);
                }
                ScaLe.WaitScale.Clear();
            }
            currentBattleStack = ScaLe.Scale[0];
            richTextBox2.Text = ScaLe + "\r\n";
            richTextBox3.Text = FirstBattleArmy.ToString();
            richTextBox4.Text = SecondBattleArmy.ToString();
            string name = currentBattleStack.Item2 == TypeOfArmy.First ? FirstBattleArmy.ArmyName : SecondBattleArmy.ArmyName;
            richTextBox1.Text += $"Ходит: {currentBattleStack.Item1} из армии {name}\n";
            if (!FirstBattleArmy.IsArmyAlive() || !SecondBattleArmy.IsArmyAlive())
            {
                WhoWin();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ScaLe.Scale.RemoveAt(0);
            richTextBox1.Text+="Вы выбрали \"Пропуск\"\r\n";
            Wait(currentBattleStack);
            if (ScaLe.Scale.Count == 0 && ScaLe.WaitScale.Count == 0)
            {
                ScaLe.MakeInitiativeScale(FirstBattleArmy, SecondBattleArmy);
            }
            else if (ScaLe.Scale.Count == 0)
            {
                foreach (var s in ScaLe.WaitScale)
                {
                    ScaLe.Scale.Add(s);
                }
                ScaLe.WaitScale.Clear();
            }
            currentBattleStack = ScaLe.Scale[0];
            richTextBox2.Text = ScaLe + "\r\n";
            richTextBox3.Text = FirstBattleArmy.ToString();
            richTextBox4.Text = SecondBattleArmy.ToString();
            string name = currentBattleStack.Item2 == TypeOfArmy.First ? FirstBattleArmy.ArmyName : SecondBattleArmy.ArmyName;
            richTextBox1.Text += $"Ходит: {currentBattleStack.Item1} из армии {name}\n";
            if (!FirstBattleArmy.IsArmyAlive() || !SecondBattleArmy.IsArmyAlive())
            {
                WhoWin();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += "Вы выбрали \"Сдаться\"";
            GiveUp(currentBattleStack);
        }
    }
}
