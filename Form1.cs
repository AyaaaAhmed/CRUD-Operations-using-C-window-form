using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WinFormsApp1

{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection mycon = new SqlConnection("Data Source=.;Initial Catalog=QA42;Integrated Security=True");
            mycon.Open();
            SqlCommand cmd = new SqlCommand("insert into [Human Resource Schema].[Employee]([EmpNo],[Emp Fname],[Emp Lname],[Dept No],[Salary]) values(" + textBox3.Text + ",'" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "'," + textBox5.Text + ")", mycon);
            try
            {
                SqlDataReader MyReader = cmd.ExecuteReader();
                MyReader.Close();
                mycon.Close();
                MessageBox.Show("Data Inserted Successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
            
            
        }

        private void label7_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Employee.Items.Clear();
            Departments.Items.Clear();
            WorksOnProject.Items.Clear();
            SqlConnection mycon = new SqlConnection("Data Source=.;Initial Catalog=QA42;Integrated Security=True");
            mycon.Open();
            SqlCommand my_sql_command_at_employee_table= new SqlCommand("select * FROM [Human Resource Schema].[Employee]", mycon);
            SqlDataReader rdr_employee_table = my_sql_command_at_employee_table.ExecuteReader();
            while (rdr_employee_table.Read())
            {  
                Employee.Items.Add(rdr_employee_table["EmpNo"].ToString() +"    " + rdr_employee_table["Emp Fname"].ToString() +"       "+ rdr_employee_table["Emp Lname"].ToString());

            }
            rdr_employee_table.Close();


            SqlCommand my_sql_command_at_department_table = new SqlCommand("SELECT * FROM [Company Schema].[Department];", mycon);
            SqlDataReader rdr_dep_table = my_sql_command_at_department_table.ExecuteReader();
            while (rdr_dep_table.Read())
            {
                Departments.Items.Add(rdr_dep_table["DeptNo"].ToString() + "   " + rdr_dep_table["Location"].ToString());
            }
            rdr_dep_table.Close();

            SqlCommand my_sql_command_at_worksOn_table = new SqlCommand("select * FROM [dbo].[Works_on]", mycon);
            SqlDataReader rdr_worksOn_table = my_sql_command_at_worksOn_table.ExecuteReader();
            while (rdr_worksOn_table.Read())
            { 
                WorksOnProject.Items.Add(rdr_worksOn_table["EmpNo"].ToString()+"           "+"         " + rdr_worksOn_table["ProjectNo"].ToString());
            }
            rdr_worksOn_table.Close();
            


            SqlCommand my_sql_command_at_project_table = new SqlCommand("select * FROM [Company Schema].[Project]", mycon);
            SqlDataReader rdr_projects_table = my_sql_command_at_project_table.ExecuteReader();
            while (rdr_projects_table.Read())
            {
                Projects.Items.Add(rdr_projects_table["ProjectNo"].ToString() + "           " + "         " + rdr_projects_table["ProjectName"].ToString());
            }
            rdr_projects_table.Close();
            mycon.Close();


        }

        private void l_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void li_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection mycon = new SqlConnection("Data Source=.;Initial Catalog=QA42;Integrated Security=True");
            mycon.Open();
            SqlCommand cmd1 = new SqlCommand(" delete from [dbo].[Works_on]  WHERE [EmpNo]=" + textBox3.Text + ";", mycon);
            SqlCommand cmd2 = new SqlCommand(" delete from [Human Resource Schema].[Employee] WHERE[EmpNo]= " + textBox3.Text + ";", mycon);
            try
            {
                SqlDataReader MyReader = cmd1.ExecuteReader();
                MyReader.Close();
                SqlDataReader MyReader1 = cmd2.ExecuteReader();
                MyReader1.Close();
                mycon.Close();
                MessageBox.Show("Data deleted Successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label9_Click_2(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection mycon = new SqlConnection("Data Source=.;Initial Catalog=QA42;Integrated Security=True");
            mycon.Open();
            SqlCommand cmd = new SqlCommand("update [Human Resource Schema].[Employee] SET [Emp Fname] = '" + textBox1.Text + "' , [Emp Lname] = '" + textBox2.Text + "' , [Dept No] = '" + textBox4.Text + "' , [Salary]  = " + textBox5.Text + "  WHERE [EmpNo] = " + textBox3.Text , mycon);
            try
            {
                SqlDataReader MyReader = cmd.ExecuteReader();
                MyReader.Close();
                mycon.Close();
                MessageBox.Show("Data updated Successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlConnection mycon = new SqlConnection("Data Source=.;Initial Catalog=QA42;Integrated Security=True");
            mycon.Open();
            SqlCommand cmd2 = new SqlCommand("select * from dbo.works_on_view;", mycon);
            try
            {
                SqlDataReader rdr2 = cmd2.ExecuteReader();
                while (rdr2.Read())
                {
                    viewBox.Items.Add(rdr2["EmpNo"].ToString() + "       " + rdr2["job"].ToString() + "       " );

                }
                rdr2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
          
            SqlConnection mycon = new SqlConnection("Data Source=.;Initial Catalog=QA42;Integrated Security=True");
            mycon.Open();
            SqlCommand cmd = new SqlCommand("adddepartmnets", mycon);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter myparam1 = new SqlParameter("@depID", textBox7.Text);
            myparam1.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(myparam1); 

            SqlParameter myparam2 = new SqlParameter("@depName", textBox6.Text);
            myparam2.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(myparam2);

            SqlParameter myparam3 = new SqlParameter("@depLocation", textBox8.Text);
            myparam3.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(myparam3);

            try
            {
                cmd.ExecuteNonQuery();
                mycon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection mycon = new SqlConnection("Data Source=.;Initial Catalog=QA42;Integrated Security=True");
            mycon.Open();
            SqlCommand cmd = new SqlCommand("deleteSp", mycon);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter myparam = new SqlParameter("@ID", textBox7.Text);
            myparam.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(myparam);

            try
            {
                cmd.ExecuteNonQuery();
                mycon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection mycon = new SqlConnection("Data Source=.;Initial Catalog=QA42;Integrated Security=True");
            mycon.Open();
            SqlCommand cmd = new SqlCommand("UpdateDeptStoredp", mycon);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter myparam = new SqlParameter("@depID", textBox7.Text);
            myparam.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(myparam);
            SqlParameter myparam1 = new SqlParameter("@depLocation", textBox8.Text);
            myparam1.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(myparam1);

            try
            {
                cmd.ExecuteNonQuery();
                mycon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}


