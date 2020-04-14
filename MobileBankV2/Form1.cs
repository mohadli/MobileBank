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

namespace MobileBankV2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           
                DialogResult result =openFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    pictureBox2.Image = Image.FromFile(openFileDialog1.FileName);
                    File.Copy(openFileDialog1.FileName, "data\\" + openFileDialog1.SafeFileName);

                }
                else
                    MessageBox.Show("!شما باید حتما یک عکس انتخاب کنید در غیر این صورت برنامه دچار مشکل میشود ");
     
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            // TODO: This line of code loads data into the 'dataSet11.m' table. You can move, or remove it, as needed.
            this.mTableAdapter.Fill(this.dataSet11.m);
            // TODO: This line of code loads data into the 'dataSet1.mp' table. You can move, or remove it, as needed.
            this.mpTableAdapter.Fill(this.dataSet1.mp);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text.Length <= 15) && (textBox2.Text.Length <= 20) && (textBox3.Text.Length <= 20) && (textBox4.Text.Length<=4) && (textBox5.Text.Length<=50) && (textBox6.Text.Length<=4))
            {
                mpTableAdapter.Insert(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, "data\\" + openFileDialog1.SafeFileName);
                this.mpTableAdapter.Fill(this.dataSet1.mp);
            }
            else
                MessageBox.Show(" تعداد کارکتر های یکی از مغادیر ورودی شما بیش از تعداد مجاز بود!\rحداکثر کارکتر مجاز در مدل 15 ، برند 20 ، نام 20 ، اندازه 4 ، سی پی یو 50 و دوربین 4 کارکتر میباشد ");
            
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            pictureBox2.Image = Image.FromFile(dataGridView1.SelectedRows[0].Cells[6].Value.ToString());
            oldid = textBox1.Text;
            mTableAdapter.FillByid2(dataSet11.m,oldid);

        }
        string oldid;
        private void button3_Click(object sender, EventArgs e)
        {
            mpTableAdapter.Delete(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
            this.mpTableAdapter.Fill(this.dataSet1.mp);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mpTableAdapter.UpdateQ(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, "data\\" + openFileDialog1.SafeFileName, oldid);
            this.mpTableAdapter.Fill(this.dataSet1.mp);

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            mpTableAdapter.FillByname(dataSet1.mp, textBox7.Text);
        }


        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox8.Text.Length == 0)
            {
                MessageBox.Show("شما باید کارکتر وارد کنید");
            }
            if (textBox8.Text.Length <= 15)
            {
                mTableAdapter.Insert(textBox1.Text, textBox8.Text);
                mTableAdapter.Fill(dataSet1.m);
                this.mTableAdapter.Fill(this.dataSet1.m);
                this.mTableAdapter.Fill(this.dataSet11.m);
            }
            else
                MessageBox.Show("شما میتوانید حداکثر 15 کارکتر وارد کنید");

        }

        private void button5_Click(object sender, EventArgs e)
        {
            mTableAdapter.DeleteQuery4();
           
            this.mTableAdapter.Fill(this.dataSet11.m);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            mpTableAdapter.DeleteQuery5();
            this.mpTableAdapter.Fill(this.dataSet1.mp);
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
               
        }

    }
}
