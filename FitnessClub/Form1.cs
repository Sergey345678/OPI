using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;


namespace FitnessClub
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            manipulationDB.Select(manipulationDB.queryClients, dataGridViewCl);
            manipulationDB.Select(manipulationDB.queryCoach, dataGridViewCh);
        }


            public static string connStr = "Data Source=HOUSEMINI;Initial Catalog=FitnessClub;Integrated Security=True";

            SqlConnection myConnection = new SqlConnection(connStr);
            ManipulationDB manipulationDB = new ManipulationDB();


        class Coach
        {

        }

        class Client
        {

        }
        class ManipulationDB
        {
            SqlConnection connect = new SqlConnection(connStr);

            //запросы на отображение данных

            public string queryClients = "SELECT CL.[id],CL.[FIO] AS Клиент,CL.[Phone] AS Телефон,CL.[Adress] AS [Адрес проживания],CH.FIO AS Тренер " +
                "FROM [FitnessClub].[dbo].[Client] AS CL " +
                "INNER JOIN [FitnessClub].[dbo].[Coach] AS CH " +
                "ON CL.Coach=CH.Id";

            public string queryCoach = "SELECT [Id] AS ИД,[FIO] AS ФИО,[Phone] AS [Номер телефона] ,[WorkLevel] AS [Стаж работы]" +
                " FROM [FitnessClub].[dbo].[Coach]";



            public void Select(string query, DataGridView dGV)
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connect);
                    connect.Open();
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dGV.DataSource = dt;
                    connect.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка работы с БД");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка");
                }
            }

        }


            private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            if  (toolStripTextBoxCl.Text=="" || toolStripTextBoxCl.Text==null)
            {
                MessageBox.Show("Ввведите значение для поиска!!!!");
            }

                string query = "SELECT CL.[id] AS ИД, CL.[FIO] AS Клиент, CL.[Phone] AS Телефон, CL.[Adress] AS[Адрес проживания], CH.FIO AS Тренер FROM[FitnessClub].[dbo].[Client] AS CL " +
                "INNER JOIN [FitnessClub].[dbo].[Coach] AS CH " +
                "ON  CL.Coach = CH.Id" +
                " where CL.[FIO] like '%" + toolStripTextBoxCl.Text + "%'";
            try
            {
                SqlConnection connect = new SqlConnection(connStr);
                SqlDataAdapter adapter = new SqlDataAdapter(query, connect);
                connect.Open();
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewCl.DataSource = dt;
                connect.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка работы с БД");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {


            if (toolStripTextBoxCh.Text == "" || toolStripTextBoxCh.Text == null)
            {
                MessageBox.Show("Ввведите значение для поиска!!!!");
            }

            string query = "SELECT CL.[id] AS ИД, CL.[FIO] AS Клиент, CL.[Phone] AS Телефон, CL.[Adress] AS[Адрес проживания], CH.FIO AS Тренер FROM[FitnessClub].[dbo].[Client] AS CL " +
                            "INNER JOIN [FitnessClub].[dbo].[Coach] AS CH " +
                            "ON  CL.Coach = CH.Id" +
                            " where CH.FIO like '%" + toolStripTextBoxCh.Text + "%'";
            try
            {
                SqlConnection connect = new SqlConnection(connStr);
                SqlDataAdapter adapter = new SqlDataAdapter(query, connect);
                connect.Open();
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewCl.DataSource = dt;
                connect.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка работы с БД");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            manipulationDB.Select(manipulationDB.queryClients, dataGridViewCl);
        }
    }
}
