namespace JogoDaVelha
{
    public partial class Form1 : Form
    {
        private int numeroJogada = 0;
        private int empate = 0;
        private int vitoriaUm = 0;
        private int vitoriaDois = 0;
        private const string JOGADOR_UM = "X";
        private const string JOGADOR_DOIS = "O";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MarcarOpcao(this.button1);            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MarcarOpcao(this.button2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MarcarOpcao(this.button3);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MarcarOpcao(this.button4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MarcarOpcao(this.button5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MarcarOpcao(this.button6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MarcarOpcao(this.button7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MarcarOpcao(this.button8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MarcarOpcao(this.button9);
        }

        private void MarcarOpcao(Button botao)
        {
            if (string.IsNullOrEmpty(botao.Text))
            {
                if (EhJogadorUm())
                {
                    botao.Text = JOGADOR_UM;
                }
                else
                {
                    botao.Text = JOGADOR_DOIS;
                }
                numeroJogada++;

                if (VerificarVencedor(botao.Text))
                    FinalizarPartida(botao.Text);
            }          
        }

        private bool EhJogadorUm()
        {
            return (numeroJogada % 2) == 0;
        }           
        
        private bool VerificarVencedor(string jogador)
        {
            bool finalizar = false;

            if (button1.Text.Equals(jogador) && button2.Text.Equals(jogador) && button3.Text.Equals(jogador) ||
                button4.Text.Equals(jogador) && button5.Text.Equals(jogador) && button6.Text.Equals(jogador) ||
                button7.Text.Equals(jogador) && button8.Text.Equals(jogador) && button9.Text.Equals(jogador) ||
                button1.Text.Equals(jogador) && button4.Text.Equals(jogador) && button7.Text.Equals(jogador) ||
                button2.Text.Equals(jogador) && button5.Text.Equals(jogador) && button8.Text.Equals(jogador) ||
                button3.Text.Equals(jogador) && button6.Text.Equals(jogador) && button9.Text.Equals(jogador) ||
                button1.Text.Equals(jogador) && button5.Text.Equals(jogador) && button9.Text.Equals(jogador))
            {
                MessageBox.Show($"Parabéns! {(jogadorOne.Equals(JOGADOR_UM) ? "jogador um" : "jogador dois")} venceu!");
                finalizar = true;
            }
            else if (numeroJogada == 9)
            {
                MessageBox.Show("Empate!");
                finalizar = true;
            }
            else
            {
                finalizar = false;
            }

            return finalizar;            
        }

        private void FinalizarPartida(string jogador)
        {
            if (numeroJogada == 9)
                empate++;
            else
            {
                if (jogador.Equals(JOGADOR_UM))
                    vitoriaUm++;

                else
                    vitoriaDois++;
            }
         
            LbPontuacaoOne.Text = vitoriaUm.ToString();
            LbPontuacaoTwo.Text = vitoriaDois.ToString();
            LbEmpate.Text = empate.ToString();
            LimparCampos(this.groupBox1);
        }

        private void LimparCampos(GroupBox group)
        {            
            foreach (var c in group.Controls)
            {
                if (c is Button)
                {
                    ((Button)c).Text = string.Empty;
                }
            }

            numeroJogada = 0;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LimparCampos(this.groupBox1);
            vitoriaUm = 0;
            vitoriaDois = 0;
            empate = 0;
            LbPontuacaoOne.Text = "0";
            LbPontuacaoTwo.Text = "0";
            LbEmpate.Text = "0";
        }
    }
}