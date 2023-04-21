using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace banco_de_dados
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;user=root;database=viagem;password=;");
            MySqlCommand cmd = new MySqlCommand("INSERT INTO t_veiculo(modelo, marca, ano, cor) VALUES (@Modelo, @Marca, @Ano, @Cor)", conn);

            //Inserção no Banco de Dados
            cmd.Parameters.AddWithValue("@Modelo", txtNome.Text);
            cmd.Parameters.AddWithValue("@Marca", txtCidade.Text);
            cmd.Parameters.AddWithValue("@Ano", txtEstado.Text);
            cmd.Parameters.AddWithValue("@Cor", txtData.Text);
     

            //Abrindo Conexão
            conn.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();

            //Validade a Inserção de Dados
            if (rowsAffected > 0)
            {
                MessageBox.Show("Dados inseridos com sucesso!");
            }
            else
            {
                MessageBox.Show("Falha ao inserir dados.");
            }
        }
    }
}
