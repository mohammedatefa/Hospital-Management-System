using HospitalSystemManagement.BusinessLogic;
using HospitalSystemManagement.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalSystemManagement
{
    public partial class AddDepartmentForm : Form
    {
        DepartmentLogic departmentLogic;
        Department DepartmentOfHospital;
        int id;
        public AddDepartmentForm()
        { 
            InitializeComponent();
            btnUpdate.Visible = false;
            btnAdd.Visible = true;
            departmentLogic= new DepartmentLogic();
        }
        internal AddDepartmentForm(Department dept)
        {
            InitializeComponent();
            btnUpdate.Visible = true;
            btnAdd.Visible = false;
            this.DepartmentOfHospital = dept;
            txtNameOfDept.Text = dept.Name;
            txtDescriptionOfDept.Text = dept.Description;
        }

        private void txtNameOfDept_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.BackColor = Color.White;
        }

        private void txtNameOfDept_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.BackColor = Color.FromArgb(224,224,224);
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAddDept_Click(object sender, EventArgs e)
        {
            if (departmentLogic.addDept(txtNameOfDept.Text, txtDescriptionOfDept.Text)) Close();
            else lblError.Visible = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (departmentLogic.updateDept(DepartmentOfHospital.ID,txtNameOfDept.Text, txtDescriptionOfDept.Text)) Close();
            else lblError.Visible = true;
        }

        private void AddDepartmentForm_Load(object sender, EventArgs e)
        {

        }

        private void txtNameOfDept_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
