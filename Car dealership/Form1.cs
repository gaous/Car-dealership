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

namespace Car_dealership
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        CarBuy customer = new CarBuy();
        string paintText = "";
        bool up = false;
        string upg = "";


        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            paintText = "";
            up = false;
            upg = "";
            customer.Upgrade.Clear();
            try
            {

                customer.Name = textBox1.Text.Trim();
                customer.Address = textBox2.Text.Trim();
                customer.Model = comboBox1.SelectedItem.ToString();
                if (radioButton4.Checked)
                {
                    customer.Paints = (int)paintjob.silver;
                    paintText = radioButton4.Text.Substring(0, 6);
                }
                else
                {
                    customer.Paints = radioButton5.Checked ? (int)paintjob.gold : (int)paintjob.diamond;
                    paintText = radioButton5.Checked ? radioButton5.Text.Substring(0, 4) : radioButton6.Text.Substring(0, 7);
                }

                CheckBox[] check = new CheckBox[] { checkBox1, checkBox2, checkBox3 };
                foreach (CheckBox item in check)
                {
                    if (item.Checked)
                    {
                        up = true;
                        if (item.Text == checkBox1.Text.Substring(0, 18))
                        {
                            customer.Upgrade.Add((int)upgrades.GTyres);
                            upg += checkBox1.Text.Substring(0, 13) + ",";
                        }
                        else if (item.Text == checkBox2.Text.Substring(0, 13))
                        {
                            customer.Upgrade.Add((int)upgrades.spoilers);
                            upg += checkBox2.Text.Substring(0, 8) + ",";
                        }
                        else if (item.Text == checkBox3.Text.Substring(0, 19))
                        {
                            customer.Upgrade.Add((int)upgrades.TCharging);
                            upg += checkBox3.Text.Substring(0, 14) + ",";
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                if(comboBox1.DisplayMember == "")
                {
                    MessageBox.Show("Please input value in all the required fields(*) and " +
                        "try again", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            finally
            {
                //writing down total price
                textBox3.Text = customer.TotalPrice().ToString();
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            File.Delete("customerFile.txt");
            FileStream file = new FileStream("customerFile.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(file);

            try
            {
                if(!(textBox4.Text == ""))
                {
                    sw.WriteLine(textBox4.Text);
                }
                else
                {
                    MessageBox.Show("No action procceded", "Error", MessageBoxButtons.OK);
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
            finally
            {
                sw.Close();
                file.Close();
            }      
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Do you actually want to buy?", "Buy our car", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            
            if(dr == DialogResult.Yes)
            {
                if (!up)
                {
                    textBox4.Text = ("Thank you, " + customer.Name + " for buying " + customer.Model + " car with " +
                        paintText + " paint.\nThe total price is " + customer.TotalPrice() +
                        "$.\nWe will ship you car to the address: " + customer.Address);
                }
                else if (up)
                {
                    textBox4.Text = ("Thank you, " + customer.Name + " for buying " + customer.Model + " car with " +
                        paintText + " paint.\nWe will upgrade your car with the following items:\n" +
                        upg +
                        "The total price is " + customer.TotalPrice() +
                        "$.\nWe will ship you car to the address: " + customer.Address);
                }
            }
            else
            {
                textBox4.Text = "";
            }
        }
    }
}
