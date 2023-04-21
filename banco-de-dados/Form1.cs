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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;user=root;database=viagem;password=;");
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM t_veiculo", conn);

            //DataTable = armazenar os resultados da consulta
            DataTable dt = new DataTable();
            conn.Open();

            // MySqlDataAdapter = preencher o DataTabel com os resultados da consulta
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();

            // Vincule o DataTable ao DataGridView para exibir os dados na grade
            dtGrdVw.DataSource = dt;
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            string pesquisa = txtPesquisa.Text;
            MySqlConnection conn = new MySqlConnection("server=localhost;user=root;database=viagem;password=;");
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM t_veiculo where modelo like '%" + pesquisa + "%'" , conn);

            //DataTable = armazenar os resultados da consulta
            DataTable dt = new DataTable();
            conn.Open();

            // MySqlDataAdapter = preencher o DataTabel com os resultados da consulta
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();

            // Vincule o DataTable ao DataGridView para exibir os dados na grade
            dtGrdVw.DataSource = dt;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Form fcadastro = new Form2();
            fcadastro.Show();
        }
    }
}
