using System;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.IO;

namespace Gama
{
    public class _DataAccessLayer
    {
        private string _connectionString;

        public _DataAccessLayer()
        {
            Initialize();
        }

        public void Initialize()
        {
            // Initialize data source. 

            if (ConfigurationManager.ConnectionStrings["GCS"] == null ||
                ConfigurationManager.ConnectionStrings["GCS"].ConnectionString.Trim() == "")
            {
                throw new Exception("A connection string named 'GCS' with a valid connection string " +
                                    "must exist in the <connectionStrings> configuration section for the application.");
            }

            _connectionString = ConfigurationManager.ConnectionStrings["GCS"].ConnectionString;
        }

        public DataTable returnDataTable(string sqlQuery)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);
            MySqlDataAdapter da = new MySqlDataAdapter(sqlQuery, conn);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                da.Fill(ds, "dtResults");
            }
            catch (Exception e)
            {
                // Handle exception.
                throw new Exception(e.Message);
            }
            finally
            {
                conn.Close();
            }

            return ds.Tables["dtResults"];
        }

        public DataSet returnDataSet(string sqlQuery)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);
            MySqlDataAdapter da = new MySqlDataAdapter(sqlQuery, conn);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                da.Fill(ds, "dtResults");
            }
            catch (Exception e)
            {
                // Handle exception.
                throw new Exception(e.Message);
            }
            finally
            {
                conn.Close();
            }

            return ds;
        }

        public void updateTable(string sqlCmd)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);            
            MySqlCommand cmd = new MySqlCommand(sqlCmd, conn);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                // Handle exception.
                throw new Exception(e.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public decimal returnDecimal(string query)
        {
            decimal returnDec = 0;

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.CommandTimeout = 0;
                object oDataSet = cmd.ExecuteScalar();
                
                if (oDataSet != null)
                {
                    returnDec = Convert.ToDecimal(oDataSet);
                }
                
                conn.Close();
            }
            return returnDec;
        }

        public int returnInt(string query)
        {
            int returnInt = 0;

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.CommandTimeout = 0;
                object oDataSet = cmd.ExecuteScalar();

                if (oDataSet != null)
                {
                    returnInt = Convert.ToInt32(oDataSet);
                }

                conn.Close();
            }
            return returnInt;
        }

        public void insertData(string sqlStatement)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);
            MySqlCommand cmd = new MySqlCommand(sqlStatement, conn);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                // Handle exception.
                throw new Exception(e.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public int insertDataReturnNewID(string sql)
        {
            int returnInt = 0;

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                returnInt = Convert.ToInt32(cmd.ExecuteScalar());

                conn.Close();
            }
            return returnInt;
        }

        public void deleteData(string sqlStatement)
        {
            MySqlConnection conn = new MySqlConnection(_connectionString);
            MySqlCommand cmd = new MySqlCommand(sqlStatement, conn);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                // Handle exception.
                throw new Exception(e.Message);
            }
            finally
            {
                conn.Close();
            }
        }


        public bool returnBoolean(string sqlCmd)
        {
            bool loginValid = false;
            
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlCmd, conn);
                object oTest = cmd.ExecuteScalar();

                if (oTest != null)
                {
                    if (Convert.ToInt32(oTest) == 1)
                    {
                        loginValid = true;
                    }
                }
                else
                {
                    loginValid = false;
                }

                conn.Close();
            }

            return loginValid;
        }

        //public DataTable returnLoginDetailsDataTable(string sqlQuery, string username, string password)
        //{
        //    MySqlConnection conn = new MySqlConnection(_connectionString);
        //    MySqlDataAdapter da = new MySqlDataAdapter(sqlQuery, conn);

        //    //conn.Open();
        //    MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);
        //    cmd.CommandType = System.Data.CommandType.Text;

        //    cmd.Parameters.AddWithValue("?userName", username);
        //    cmd.Parameters.AddWithValue("?password", password);

        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        conn.Open();
        //        da.Fill(ds, "dtResults");
        //    }
        //    catch (Exception e)
        //    {
        //        // Handle exception.
        //        throw new Exception(e.Message);
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }

        //    return ds.Tables["dtResults"];
        //}

        public bool returnBoolean(string sqlCmd, string email, string password)
        {
            bool loginValid = false;

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlCmd, conn);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);
                object oTest = cmd.ExecuteScalar();

                if (oTest != null)
                {
                    if (Convert.ToInt32(oTest) == 1)
                    {
                        loginValid = true;
                    }
                }
                else
                {
                    loginValid = false;
                }

                conn.Close();
            }

            return loginValid;
        }

        public void returnByte(string sql)
        {

            MySqlConnection conn = new MySqlConnection(_connectionString);
            MySqlCommand command = new MySqlCommand(sql, conn);

            // Writes the BLOB to a file (*.bmp).
            FileStream stream;
            // Streams the BLOB to the FileStream object.
            BinaryWriter writer;

            // Size of the BLOB buffer.
            int bufferSize = 100;
            // The BLOB byte[] buffer to be filled by GetBytes.
            byte[] outByte = new byte[bufferSize];
            // The bytes returned from GetBytes.
            long retval;
            // The starting position in the BLOB output.
            long startIndex = 0;

            // The eventName to use in the file name.
            string evtName = "";

            // Open the connection and read data into the DataReader.
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader(CommandBehavior.SequentialAccess);

            while (reader.Read())
            {
                // Get the publisher id, which must occur before getting the logo.
                evtName = reader.GetString(0);

                // Create a file to hold the output.
                stream = new FileStream(
                  "event_" + evtName + ".html", FileMode.OpenOrCreate, FileAccess.Write);
                writer = new BinaryWriter(stream);

                // Reset the starting byte for the new BLOB.
                startIndex = 0;

                // Read bytes into outByte[] and retain the number of bytes returned.
                retval = reader.GetBytes(1, startIndex, outByte, 0, bufferSize);

                // Continue while there are bytes beyond the size of the buffer.
                while (retval == bufferSize)
                {
                    writer.Write(outByte);
                    writer.Flush();

                    // Reposition start index to end of last buffer and fill buffer.
                    startIndex += bufferSize;
                    retval = reader.GetBytes(1, startIndex, outByte, 0, bufferSize);
                }

                // Write the remaining buffer.
                writer.Write(outByte, 0, (int)retval - 1);
                writer.Flush();

                // Close the output file.
                writer.Close();
                stream.Close();
            }

            // Close the reader and the connection.
            reader.Close();
            conn.Close();
        }

        public string returnString(string sql)
        {
            string strData = string.Empty;

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql , conn);
                
                object oTest = cmd.ExecuteScalar();

                if (oTest != null)
                {
                    
                    strData = Convert.ToString(oTest);                    
                }
                
                conn.Close();
            }

            return strData;
        }
    }
}