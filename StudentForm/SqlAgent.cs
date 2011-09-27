using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;
using StudentForm.StudentService;
using StudentForm;
/// <summary>
/// Summary description for SqlAgent
/// </summary>
public class SqlAgent
{
    //private Student[] students;
    public SqlAgent()
    {
        //
        // TODO: Add constructor logic here
        // 
    }

    public Collection<Student> metodStudentShow()
    {
        SqlDataReader myReader = null;
        string connectionString = "server=localhost; Trusted_Connection=yes; database=test";
        SqlConnection mySqlConnection = new SqlConnection(connectionString);
        string sqlStr = " select name, email, adress";
        sqlStr += " from Student  ";
        SqlCommand mySqlCommand = new SqlCommand(sqlStr, mySqlConnection);
        Collection<Student> scollection = new Collection<Student>();
        try
        {
            mySqlConnection.Open();
            myReader = mySqlCommand.ExecuteReader();
            Console.Write("Name" + "\t");
            Console.Write("Email " + "\t");
            Console.WriteLine("Adress " + "\t");

            while (myReader.Read())
            {
               // Student s = new Student(myReader.GetString(0), myReader.GetString(1), myReader.GetString(2));
                //scollection.Add(s);
                /*Console.Write(myReader.GetString(0) + "\t");
                Console.Write(myReader.GetString(1) + "\t");
                Console.Write(myReader.GetString(2) + "\t");
                Console.Write(myReader.GetString(3) + "\t");
                Console.Write(myReader.GetString(4) + "\t");
                Console.WriteLine(myReader.GetString(5) + "\t");*/

            }
            Console.WriteLine(scollection);
        }
        catch (Exception e)
        {
            Console.WriteLine("mySqlConnection fel meddelande: " + e.ToString());
        }

        finally
        {
            if (myReader != null)
                myReader.Close();
            if (mySqlConnection.State == ConnectionState.Open)
                mySqlConnection.Close();
        }
        return scollection;
    }

    public void metodSqlStudentSave(StudentDao StuSave)
    {


        string connectionString = @"server=localhost\sqlexpress; Trusted_Connection=yes; database=test";

        SqlConnection mySqlConnection = new SqlConnection(connectionString);
        SqlCommand mySqlCommand = new SqlCommand();
        mySqlConnection.Open();
        mySqlCommand.Connection = mySqlConnection;


        try
        {
            string sqlStr = " insert into Student values ";
            sqlStr += " ('" + StuSave.Name + "','" + StuSave.Email + "','" + StuSave.Adress + "')";

            mySqlCommand.CommandText = sqlStr;
            mySqlCommand.ExecuteNonQuery();
            Console.WriteLine("name = 'Dogan' is inserted");
        }
        catch (Exception e)
        {
            Console.WriteLine("mySqlConnection fel meddelande: " + e.ToString());
        }
        finally
        {

            if (mySqlConnection.State == ConnectionState.Open)
                mySqlConnection.Close();
        }


    }
}