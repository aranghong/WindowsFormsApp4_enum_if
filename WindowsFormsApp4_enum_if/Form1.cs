using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp4_enum_if
{

    public partial class Form1 : Form
    {

        int user = -1;
        int computer = -1;
        int userScore = 0;
        int comScore = 0;

        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //가위
            textBox3.Text = "";
            textBox3.Text += "사용자: " + "가위 \r\n";
            user = 0;
            game(user);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            //바위
            textBox3.Text = "";
            textBox3.Text += "사용자: " + "바위 \r\n";
            user = 1;
            game(user);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //보
            textBox3.Text = "";
            textBox3.Text += "사용자: " + "보 \r\n";
            user = 2;
            game(user);
        }

        int check()
        {
            if (userScore >= 3 || comScore >= 3)
            {
                textBox3.Text += "사용자: " + user + " \r\n";
                textBox3.Text += "컴퓨터: " + computer + " \r\n";

                textBox1.Text += "사용자 점수: " + userScore + " \r\n";
                textBox2.Text += "컴퓨터 점수: " + comScore + " \r\n";

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "3점 달성!";

                userScore = 0;
                comScore = 0;

                return 1;
            }
            else
            {
                return 0;
            }
        }

        void game(int choice)
        {
            Random r = new Random();
            computer = (int)r.Next(0, 3);

            int chk = check();

            if (chk == 0)
            {
                if (computer == 0)
                {
                    textBox3.Text += "컴퓨터: " + "가위 \r\n";
                    if (user == 0)
                    {
                        textBox1.Text += "사용자 점수: " + userScore + " \r\n";
                        textBox2.Text += "컴퓨터 점수: " + comScore + " \r\n";

                    }
                    if (user == 1)
                    {
                        userScore++;
                        textBox1.Text += "사용자 점수: " + userScore + " \r\n";
                        textBox2.Text += "컴퓨터 점수: " + comScore + " \r\n";

                    }
                    if (user == 2)
                    {
                        comScore++;
                        textBox1.Text += "사용자 점수: " + userScore + " \r\n";
                        textBox2.Text += "컴퓨터 점수: " + comScore + " \r\n";

                    }


                }
                else if (computer == 1)
                {
                    textBox3.Text += "컴퓨터: " + "바위 \r\n";
                    if (user == 0)
                    {
                        comScore++;
                        textBox1.Text += "사용자 점수: " + userScore + " \r\n";
                        textBox2.Text += "컴퓨터 점수: " + comScore + " \r\n";

                    }
                    if (user == 1)
                    {
                        textBox1.Text += "사용자 점수: " + userScore + " \r\n";
                        textBox2.Text += "컴퓨터 점수: " + comScore + " \r\n";

                    }
                    if (user == 2)
                    {
                        userScore++;
                        textBox1.Text += "사용자 점수: " + userScore + " \r\n";
                        textBox2.Text += "컴퓨터 점수: " + comScore + " \r\n";

                    }
                }
                if (computer == 2)
                {
                    textBox3.Text += "컴퓨터: " + "보 \r\n";
                    if (user == 0)
                    {
                        userScore++;
                        textBox1.Text += "사용자 점수: " + userScore + " \r\n";
                        textBox2.Text += "컴퓨터 점수: " + comScore + " \r\n";

                    }
                    if (user == 1)
                    {
                        comScore++;
                        textBox1.Text += "사용자 점수: " + userScore + " \r\n";
                        textBox2.Text += "컴퓨터 점수: " + comScore + " \r\n";

                    }
                    if (user == 2)
                    {
                        textBox1.Text += "사용자 점수: " + userScore + " \r\n";
                        textBox2.Text += "컴퓨터 점수: " + comScore + " \r\n";

                    }
                }
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
