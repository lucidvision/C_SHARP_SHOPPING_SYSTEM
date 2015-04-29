using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    class DBConnect
    {
        public SqlConnection connection;
        private string server;
        private string database;

        public DBConnect()
        {
            Initialize();
        }

        public void Initialize()
        {
            server = "cypress.csil.sfu.ca";
            database = "bcpark354";

            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "integrated security= sspi;";

            try
            {
                connection = new SqlConnection(connectionString);
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        public void OpenConnection()
        {
            try
            {
                connection.Open();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Cannot Open Connection", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        public void CloseConnection()
        {
            try
            {
                connection.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Cannot Close Connection", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        public SqlDataReader getData(String query)
        {
            SqlDataReader myReader = null;
            try
            {
                SqlCommand myCommand = new SqlCommand(query, connection);
                myReader = myCommand.ExecuteReader();
                return myReader;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Cannot Return Query", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return myReader;
            }
        }
    }
}