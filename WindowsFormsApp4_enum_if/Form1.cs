using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp4_enum_if
{
    public partial class Form1 : Form
    {
        enum Choice { Scissors = 0, Rock = 1, Paper = 2 }

        int userScore = 0;
        int computerScore = 0;
        Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) => PlayRound(Choice.Scissors); // 가위
        private void button2_Click(object sender, EventArgs e) => PlayRound(Choice.Rock);     // 바위
        private void button3_Click(object sender, EventArgs e) => PlayRound(Choice.Paper);    // 보

        private void PlayRound(Choice userChoice)
        {
            Choice computerChoice = (Choice)rand.Next(0, 3);

            textBox3.Text = $"사용자: {GetKoreanName(userChoice)}\r\n컴퓨터: {GetKoreanName(computerChoice)}\r\n";

            int result = Compare(userChoice, computerChoice);

            if (result == 1)
            {
                userScore++;
            }
            else if (result == -1)
            {
                computerScore++;
            }

            UpdateScores();

            if (userScore >= 3 || computerScore >= 3)
            {
                string winner = userScore >= 3 ? "사용자 승리 🎉" : "컴퓨터 승리 🤖";
                textBox3.Text += $"\r\n{winner}\r\n점수를 초기화합니다.";


                ResetScores();
            }
        }

        private void UpdateScores()
        {
            textBox1.Text += $"사용자 점수: {userScore} \r\n";
            textBox2.Text += $"컴퓨터 점수: {computerScore} \r\n";
        }

        private void ResetScores()
        {
            userScore = 0;
            computerScore = 0;

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private int Compare(Choice user, Choice computer)
        {
            if (user == computer) return 0;

            return (user == Choice.Scissors && computer == Choice.Paper) ||
                   (user == Choice.Rock && computer == Choice.Scissors) ||
                   (user == Choice.Paper && computer == Choice.Rock) ? 1 : -1;
        }

        private string GetKoreanName(Choice choice)
        {
            switch (choice)
            {
                case Choice.Scissors: return "가위";
                case Choice.Rock: return "바위";
                case Choice.Paper: return "보";
                default: return "?";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }

    }
}
