using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestApp
{
    public partial class Form1 : Form
    {
        int page = 1;
        int quest = 1;
        int score = 0;
        StreamReader fs = new StreamReader(Directory.GetCurrentDirectory() + "\\test\\answers.txt", Encoding.GetEncoding(1251));

        public Form1()
        {
            InitializeComponent();
            repaint(page);
        }

        private void ll_1_1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String name = ((LinkLabel)sender).Name.Substring(3)+".rtf";
            rtb.Clear();
            rtb.LoadFile(Directory.GetCurrentDirectory()+"\\res\\"+name);
        }

        private void repaint(int page)
        {
            switch (page)
            {
                case 1:
                    p1.Visible = true;
                    p1.BringToFront();
                    break;
                /*case 2:
                    p2.Visible = true;
                    p2.BringToFront();
                    break;
                case 3:
                    p3.Visible = true;
                    p3.BringToFront();
                    break;
                case 4:
                    p4.Visible = true;
                    p4.BringToFront();
                    break;
                case 5:
                    p5.Visible = true;
                    p5.BringToFront();
                    break;*/
            }
            rtb.SelectionStart = 1;
            rtb.ScrollToCaret();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            repaint(page+1);
            if (page<5) page++;
            if (page>1)
            {
                //btnPrev.Enabled = true;
                //btnFirst.Enabled = true;
            }
            if (page==5)
            {
                //btnNext.Enabled = false;
                //btnLast.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            repaint(page-1);
            if (page>1) page--;
            if (page == 1)
            {
                //btnPrev.Enabled = false;
                //btnFirst.Enabled = false;
            }
            if (page<5)
            {
                //btnNext.Enabled = true;
                //btnLast.Enabled = true;
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            page = 5;
            repaint(page);
            /*btnNext.Enabled = false;
            btnLast.Enabled = false;
            btnPrev.Enabled = true;
            btnFirst.Enabled = true;*/
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            page = 1;
            repaint(page);
            /*btnPrev.Enabled = false;
            btnFirst.Enabled = false;
            btnNext.Enabled = true;
            btnLast.Enabled = true;*/
        }

        private void ll_test_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите начать тестирование? В режиме теста чтение теоретического материала невозможно!", "Предупреждение", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //p5.Enabled = false;
                //pPages.Enabled = false;
                rtb.Height = 524;
                score = 0;
                p_test.Visible = true;
                String name = quest.ToString() + ".rtf";
                rtb.Clear();
                rtb.LoadFile(Directory.GetCurrentDirectory() + "\\test\\" + name);
                rb1.Text = fs.ReadLine();
                rb2.Text = fs.ReadLine();
                rb3.Text = fs.ReadLine();
                rb4.Text = fs.ReadLine();
                rb1.Checked = true;  
            }          
        }

        private void btnNextTest_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(fs.ReadLine());
            switch (x)
            {
               case  1:
                    if (rb1.Checked) score++;
                    break;
                case 2:
                    if (rb2.Checked) score++;
                    break;
                case 3:
                    if (rb3.Checked) score++;
                    break;
                case 4:
                    if (rb4.Checked) score++;
                    break;
            }
            if (quest < 20)
            {
                quest++;
                String name = quest.ToString() + ".rtf";
                rtb.Clear();
                rtb.LoadFile(Directory.GetCurrentDirectory() + "\\test\\" + name);
                rb1.Text = fs.ReadLine();
                rb2.Text = fs.ReadLine();
                rb3.Text = fs.ReadLine();
                rb4.Text = fs.ReadLine();
                rb1.Checked = true;            
            }
            else
            {
                p_test.Visible = false;
                rtb.Clear();
                rtb.Text = "Тестирование завершено! Ваш результат: " + score.ToString() + " из 20.";
                //p5.Enabled = true;
                //pPages.Enabled = true;
            }
        }
    }
}
