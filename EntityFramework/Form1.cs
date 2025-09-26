using EntityFramework.Models;

namespace EntityFramework
{
    public partial class Form1 : Form
    {

        Customer model = new Customer();
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        void Clear()
        {
            FirstName.Text = LastName.Text = Address.Text = "";
            saveBtn.Text = "Save";
            deleteBtn.Enabled = false;
            model.Id = 0;
            loadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Clear();
            this.ActiveControl = FirstName;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (FirstName.Text.Trim() == "")
            {
                MessageBox.Show("First name should be given.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            model.FirstName = FirstName.Text;
            model.LastName = LastName.Text;
            model.Address = Address.Text;

            using (CompanySdContext db = new CompanySdContext())
            {
                if (model.Id == 0)
                    db.Customers.Add(model);
                else
                    db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            MessageBox.Show("Customer added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Clear();
        }

        void loadData()
        {
            dgbCustomer.AutoGenerateColumns = false;
            using (CompanySdContext db = new CompanySdContext())
            {
                dgbCustomer.DataSource = db.Customers.ToList<Customer>();
            }
        }

        private void dgbCustomer_Click(object sender, EventArgs e)
        {
            if (dgbCustomer.CurrentRow.Index == -1) return;

            model.Id = Convert.ToInt32(dgbCustomer.CurrentRow.Cells["dgID"].Value);

            using (CompanySdContext db = new CompanySdContext())
            {
                model = db.Customers.Where(x => x.Id == model.Id).FirstOrDefault();

                FirstName.Text = model.FirstName;
                LastName.Text = model.LastName;
                Address.Text = model.Address;
            }

            saveBtn.Text = "Update";
            deleteBtn.Enabled = true;
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete this record", "Message", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            using (CompanySdContext db = new CompanySdContext())
            {
                var entry = db.Entry(model);
                if (entry.State == Microsoft.EntityFrameworkCore.EntityState.Detached)
                {
                    db.Customers.Attach(model);
                    db.Customers.Remove(model);
                    db.SaveChanges();
                    loadData();
                    Clear();
                    MessageBox.Show("Record deleted successfully!", "Message", MessageBoxButtons.OK);
                }
            }
        }
    }
}
