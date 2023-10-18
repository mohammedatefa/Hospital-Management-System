using HospitalSystemManagement.Model;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HospitalSystemManagement
{
    public partial class AddDoctorForm : Form
    {
        DataContext dataContext;
        Doctor doctor;
        public AddDoctorForm()
        {
            InitializeComponent();
            dataContext = new DataContext();
            cmBoxDeptName.DataSource = dataContext.Departments.ToList();
            cmBoxDeptName.DisplayMember = "Name";
            btnUpdate.Visible = false;
        }
        internal AddDoctorForm(Doctor doctor)
        {
            InitializeComponent();
            dataContext = new DataContext();
            this.doctor = doctor;
            cmBoxDeptName.DataSource = dataContext.Departments.ToList();
            cmBoxDeptName.DisplayMember = "Name";
            btnAdd.Visible = false;
            txtName.Text = doctor.Name;
            txtEmail.Text = doctor.Email;
             txtPhone.Text=doctor.Phone;
            txtSalary.Text=doctor.Salary;
            txtAddress.Text=doctor.Address;
            dateTimePicker1.Value=doctor.BirthDate;
        }

        private void txtAddress_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.BackColor = Color.White;
        }

        private void txtAddress_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.BackColor = Color.FromArgb(224,224,224);
            
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtEmail.Text == "" || txtPhone.Text == "" || txtSalary.Text == "" || txtAddress.Text == "" || dateTimePicker1.Text == "" || txtPhone.Text.Length < 11)
            {
                MessageBox.Show("you must fill all data please !!!! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Department dep = (Department)cmBoxDeptName.SelectedItem;
                dataContext.Doctors.Add(new Doctor()
                {
                    Name = txtName.Text,
                    Email = txtEmail.Text,
                    Phone = txtPhone.Text,
                    Salary = txtSalary.Text,
                    Address = txtAddress.Text,
                    Department = dep,
                    BirthDate = DateTime.Parse(dateTimePicker1.Text),

                });
                dataContext.SaveChanges();
                Close();

            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtEmail.Text == "" || txtPhone.Text == "" || txtSalary.Text == "" || txtAddress.Text == "" || dateTimePicker1.Text == "" || txtPhone.Text.Length < 11)
            {
                MessageBox.Show("you must fill all data please ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var dep = (Department)cmBoxDeptName.SelectedItem;
                Doctor doc = dataContext.Doctors.First(d => d.ID == doctor.ID);
                doc.Name = txtName.Text;
                doc.Email = txtEmail.Text;
                doc.Phone = txtPhone.Text;
                doc.Salary = txtSalary.Text;
                doc.Address = txtAddress.Text;
                doc.Department = dep;
                doc.BirthDate = DateTime.Parse(dateTimePicker1.Text);
                dataContext.SaveChanges();
                Close();

            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                e.Handled = true;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            { e.Handled = true; }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                e.Handled = true;
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            PhoneLblError.Visible = txtPhone.Text.Length < 11;

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            NameLblError.Visible = txtName.Text.Length < 3;
        }

        private void AddDoctorForm_Load(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            EmailLblError.Visible = !txtEmail.Text.Contains('@');
        }

        private void PhoneLblError_Click(object sender, EventArgs e)
        {

        }

        private void AddressLblError_Click(object sender, EventArgs e)
        {

        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            AddressLblError.Visible = txtAddress.Text.Length < 3;
        }

        private void NameLblError_Click(object sender, EventArgs e)
        {

        }
    }
}
