﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Net.Http.Headers;

namespace sql_form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static string insertQuery;
        public static MySqlConnection connection = new MySqlConnection("Server=localhost;Database=data1;Uid=root;Pwd=1exonhappy1234;");

        private void Form1_Load(object sender, EventArgs e)
        {
            connection.Open();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void start_Click_1(object sender, EventArgs e)
        {


            MySqlCommand query = connection.CreateCommand();
            query.CommandText = "SELECT *";
            query.CommandText += "FROM data1.new_table";

            try
            {
                MySqlDataReader reader = query.ExecuteReader();
                dataGridView1.Rows.Clear();

                for (int i = 0; reader.Read(); i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["name"].Value = reader["name"].ToString();
                    dataGridView1.Rows[i].Cells["age"].Value = reader["age"].ToString();
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
                return;
            }
        }

        private void but_delete_Click(object sender, EventArgs e)
        {
            insertQuery = $"DELETE FROM data1.new_table WHERE name = {txt_name.Text} AND age = {txt_age.Text};";
            MySqlCommand command = new MySqlCommand(insertQuery, connection);
        }

        private void but_add_Click(object sender, EventArgs e)
        {

        }
    }
}
