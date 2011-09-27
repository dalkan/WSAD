using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StudentForm.StudentService;

namespace StudentForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView1.Columns.Clear();
            metodStudentSave();
            Reset();
        }

        private void Reset()
        {
            txtName.Clear();
            txtEmail.Clear();
            txtAdress.Clear();
        }

        private void metodStudentSave()
        {
            
            string strName = txtName.Text;
            string strAdress = txtAdress.Text;
            string strEmail = txtEmail.Text;

            Student stuSave = new Student() { Name = strName, Adress = strAdress, Email = strEmail };

            ServiceSoapClient serviceSql = new ServiceSoapClient();
            serviceSql.SaveStudent(stuSave);

            /*SqlAgent sqlAgent = new SqlAgent();
            sqlAgent.metodSqlStudentSave(stuSave);
            */
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView1.Columns.Clear();
            showStudent();
            Reset();
        }

        private void showStudent()
        {
            ServiceSoapClient serviceSqlShow = new ServiceSoapClient();
            var listStudent = serviceSqlShow.ShowStudent();

            listView1.Columns.Add("Name", 100, System.Windows.Forms.HorizontalAlignment.Left);
            listView1.Columns.Add("Email", 100, System.Windows.Forms.HorizontalAlignment.Left);
            listView1.Columns.Add("Adress", 100, System.Windows.Forms.HorizontalAlignment.Left);
            foreach (var student in listStudent)
            {
                string[] studentArray = new string[3] { student.Name, student.Email, student.Adress };
                listView1.Items.Add(new ListViewItem(studentArray));
 
            }

            
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView1.Columns.Clear();
            searchStudent();
            Reset();
        }

        private void searchStudent()
        {

            string strName = txtName.Text;
            string strAdress = txtAdress.Text;
            string strEmail = txtEmail.Text;

            Student stuSearch = new Student() { Name = strName, Adress = strAdress, Email = strEmail };

            ServiceSoapClient serviceSql = new ServiceSoapClient();
            var listStudent = serviceSql.SearchStudent(stuSearch);

            listView1.Columns.Add("Name", 100, System.Windows.Forms.HorizontalAlignment.Left);
            listView1.Columns.Add("Email", 100, System.Windows.Forms.HorizontalAlignment.Left);
            listView1.Columns.Add("Adress", 100, System.Windows.Forms.HorizontalAlignment.Left);
            foreach (var student in listStudent)
            {
                string[] studentArray = new string[3] { student.Name, student.Email, student.Adress };
                listView1.Items.Add(new ListViewItem(studentArray));

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView1.Columns.Clear();
            updateStudent();
            Reset();

        }

        private void updateStudent()
        {
            string strName = txtName.Text;
            string strAdress = txtAdress.Text;
            string strEmail = txtEmail.Text;

            Student stuUpdate = new Student() { Name = strName, Adress = strAdress, Email = strEmail };

            ServiceSoapClient serviceSql = new ServiceSoapClient();
            serviceSql.UpdateStudent(stuUpdate);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView1.Columns.Clear();
            deleteStudent();
            Reset();
        }

        private void deleteStudent()
        {
            string strName = txtName.Text;
            string strAdress = txtAdress.Text;
            string strEmail = txtEmail.Text;

            Student stuDelete = new Student() { Name = strName, Adress = strAdress, Email = strEmail };
            ServiceSoapClient serviceSql = new ServiceSoapClient();
            serviceSql.DeleteStudent(stuDelete);
        }
        
       

       /* private void metodStudentSaveService()
        {
            ServiceSoapClient saveClient = new ServiceSoapClient();

            string strName = txtName.Text;
            string strAdress = txtAdress.Text;
            string strEmail = txtEmail.Text;
            StudentDao stuSave = new StudentDao() { Name = strName, Adress = strAdress, Email = strEmail };

           

        }*/
        
    }
}
