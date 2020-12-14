using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employeee
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dept d = new Dept();
            d.ID = int.Parse(textBox1.Text);
            d.Name = textBox2.Text;
            Model cf = new Model();
            cf.Depts.Add(d);
            cf.SaveChanges();
            textBox1.Text = textBox2.Text = string.Empty;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                
                Model cf = new Model();
                //Dept d = cf.Depts.Find(DeptId);
                int m = int.Parse(textBox1.Text);
                Dept d = (from dd in cf.Depts
                          where dd.ID == m
                          select dd).First();
                textBox2.Text = d.Name;

                Employee emp = (from em in cf.Employees
                                where em.DeptID == d.ID
                                select em).First();

                textBox3.Text = emp.ID.ToString();
                textBox4.Text = emp.Name;
                textBox5.Text = emp.Salary.ToString();
                

              
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Enter a valid ID!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("All fields must have values");
            }
            else
            {
                Model cf = new Model();
                int m = int.Parse(textBox1.Text);
                Dept d = (from dd in cf.Depts
                          where dd.ID == m
                          select dd).First();
                if (d == null)
                {
                    MessageBox.Show("ID NOT FOUND!");
                }
                else
                {
                    d.Name = textBox2.Text;

                    textBox1.Text = textBox2.Text = string.Empty;
                    cf.SaveChanges();
                    MessageBox.Show("Department updated");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                
                Model cf = new Model();
                //Dept d = cf.Depts.Find(DeptId);
                int m = int.Parse(textBox1.Text);
                Dept d = (from dd in cf.Depts
                          where dd.ID == m
                          select dd).First();
                cf.Depts.Remove(d);
                cf.SaveChanges();
                textBox1.Text = textBox2.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ID NOT FOUND!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please Enter Department ID First");
            }
            else
            {
                if (textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
                {
                    MessageBox.Show("All fields must have values");
                }
                else
                {
                    try
                    {
                        Model cf = new Model();
                        Employee emp = new Employee();
                        emp.ID = int.Parse(textBox3.Text);
                        emp.Name = textBox4.Text;
                        emp.Salary = int.Parse(textBox5.Text);
                        //Ent.Employees.AddObject(emp);
                        cf.Employees.Add(emp);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ID already Exists");
                    }
                }

            }

        }

        private void button9_Click(object sender, EventArgs e)
        {

            Model cf = new Model();
            Employee emp = new Employee();
            emp.ID = int.Parse(textBox3.Text);
            emp.Name = textBox4.Text;
            emp.Salary = int.Parse(textBox5.Text);
            emp.DeptID = int.Parse(textBox1.Text);
            textBox3.Text = textBox4.Text = textBox5.Text = string.Empty;
            cf.Employees.Add(emp);
            cf.SaveChanges();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("All fields must have values");
            }
            else
            {
                Model cf = new Model();
                int m = int.Parse(textBox3.Text);
                Employee emp = (from em in cf.Employees
                                where em.ID == m
                                select em).First();
                if (emp == null)
                {
                    MessageBox.Show("ID NOT FOUND!");
                }
                else
                {
                    emp.Name = textBox4.Text;
                    emp.Salary = int.Parse(textBox5.Text);

                    textBox3.Text = textBox4.Text = textBox5.Text = string.Empty;
                    cf.SaveChanges();
                    MessageBox.Show("Employee updated");
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                
                Model cf = new Model();
                int m = int.Parse(textBox3.Text);
                Employee emp = (from em in cf.Employees
                          where em.ID == m
                          select em).First();
                textBox4.Text = emp.Name;
                textBox5.Text = emp.Salary.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Enter a valid ID!");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                
                Model cf = new Model();
                //Dept d = cf.Depts.Find(DeptId);
                int m = int.Parse(textBox3.Text);
                Employee emp = (from em in cf.Employees
                          where em.ID == m
                          select em).First();
                cf.Employees.Remove(emp);
                cf.SaveChanges();
                textBox3.Text = textBox4.Text = textBox5.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ID NOT FOUND!");
            }

        }

        private void button11_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            Model cf = new Model();
            int empid = int.Parse(textBox3.Text) + 1;
            Employee emp = (from em in cf.Employees
                            where empid == em.ID
                            select em).FirstOrDefault();
            
            if (emp != null && emp.DeptID == id)
            {
                textBox1.Text = emp.DeptID.ToString();
                textBox3.Text = emp.ID.ToString();
                textBox4.Text = emp.Name;
                textBox5.Text = emp.Salary.ToString();

            }
            else 
            {
                MessageBox.Show("No More Employees");
            }


        }

        private void button10_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            Model cf = new Model();
            int empid = int.Parse(textBox3.Text) - 1;
            Employee emp = (from em in cf.Employees
                            where em.ID == empid
                            select em).FirstOrDefault();
            if (emp != null && emp.DeptID == id)
            {
                textBox1.Text = emp.DeptID.ToString();
                textBox3.Text= emp.ID.ToString();
                textBox4.Text = emp.Name;
                textBox5.Text = emp.Salary.ToString();
            }
            else
            {
                MessageBox.Show("No More Employees");
            }
            
        }
    }
}