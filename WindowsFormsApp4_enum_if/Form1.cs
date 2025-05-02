using System;
using System.Windows.Forms;

namespace WindowsFormsApp4_enum_if
{
    public partial class Form1 : Form
    {
        enum RPS { Scissors = 0, Rock = 1, Paper = 2 }

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
            user = (int)RPS.Scissors;
            textBox3.Text = "";
            textBox3.Text += "사용자: 가위\r\n";
            game(user);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            user = (int)RPS.Rock;
            textBox3.Text = "";
            textBox3.Text += "사용자: 바위\r\n";
            game(user);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            user = (int)RPS.Paper;
            textBox3.Text = "";
            textBox3.Text += "사용자: 보\r\n";
            game(user);
        }

        void game(int choice)
        {
            Random r = new Random();
            computer = r.Next(0, 3);

            if (check() == 1) return;

            ShowComputerChoice();

            int result = Judge((RPS)user, (RPS)computer);
            if (result == 1)
            {
                userScore++;
            }
            else if (result == -1)
            {
                comScore++;
            }

            PrintScores();
        }

        int Judge(RPS user, RPS computer)
        {
            if (user == computer) return 0;

            if ((user == RPS.Scissors && computer == RPS.Paper) ||
                (user == RPS.Rock && computer == RPS.Scissors) ||
                (user == RPS.Paper && computer == RPS.Rock))
            {
                return 1; // 사용자 승
            }

            return -1; // 컴퓨터 승
        }

        void ShowComputerChoice()
        {
            string comStr = computer switch
            {
                (int)RPS.Scissors => "가위",
                (int)RPS.Rock => "바위",
                (int)RPS.Paper => "보",
                _ => "?"
            };
            textBox3.Text += $"컴퓨터: {comStr}\r\n";
        }

        void PrintScores()
        {
            textBox1.Text = $"사용자 점수: {userScore}\r\n";
            textBox2.Text = $"컴퓨터 점수: {comScore}\r\n";
        }

        int check()
        {
            if (userScore >= 3 || comScore >= 3)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "3점 달성!\r\n점수 초기화됩니다.";

                userScore = 0;
                comScore = 0;
                return 1;
            }
            return 0;
        }

        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
    }
}
