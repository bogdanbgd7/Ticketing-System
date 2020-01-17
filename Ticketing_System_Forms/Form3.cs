using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Entity;
using System.IO;

namespace Ticketing_System_Forms
{
    public partial class Form3 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=WRSBP185150-J7T\\SQLEXPRESS;Initial Catalog=LocalDB;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        DataSet ds;
        SqlCommandBuilder cmdbl;
        DataTable dt = new DataTable();

        Ticket model = new Ticket();
        public Form3()
        {
            InitializeComponent();
            var frm2 = new Form2();

        }


        void babara()
        {
            dataGridView1.Refresh();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                tb_Owner.Text = row.Cells[1].Value.ToString();
                tb_StoreNumb.Text = row.Cells[2].Value.ToString();
                tb_DeviceNumb.Text = row.Cells[3].Value.ToString();
                tb_Team.Text = row.Cells[4].Value.ToString();
                tb_Status.Text = row.Cells[5].Value.ToString();
                tb_Severity.Text = row.Cells[6].Value.ToString();
                tb_Priority.Text = row.Cells[7].Value.ToString();
                tb_Type.Text = row.Cells[8].Value.ToString();
                tb_tCode.Text = row.Cells[9].Value.ToString();
                tb_SubType.Text = row.Cells[10].Value.ToString();
                tb_tCategory.Text = row.Cells[11].Value.ToString();
                tb_tType.Text = row.Cells[12].Value.ToString();
                tb_Problem_Notes.Text = row.Cells[13].Value.ToString();
                tb_CallerPhone.Text = row.Cells[14].Value.ToString();
                tb_CallerName.Text = row.Cells[15].Value.ToString();
                tb_ResCode.Text = row.Cells[16].Value.ToString();
                tb_ResType.Text = row.Cells[17].Value.ToString();
                tb_ResNotes.Text = row.Cells[18].Value.ToString();
                tb_Created.Text = row.Cells[19].Value.ToString();
                tb_Closed.Text = row.Cells[20].Value.ToString();
                tb_LastUpdatedBy.Text = row.Cells[21].Value.ToString();
                tb_Assigned.Text = row.Cells[22].Value.ToString();

            }
            else
            {
                MessageBox.Show("There is no Records");
            }
        }

        public void showData()
        {
            adapt = new SqlDataAdapter("select * from Ticket", con);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cmdbl = new SqlCommandBuilder(adapt);
                adapt.Update(ds, "BP185150_TICKETING");
                MessageBox.Show("UPDATED");

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'localDBDataSet.Ticket' table. You can move, or remove it, as needed.
            this.ticketTableAdapter.Fill(this.localDBDataSet.Ticket);

        }

        private void btn_SaveUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value);

            var frm2 = new Form2();
            string textfromForm1 = frm2.tb_TicketID.Text;

            try
            {
                con.Open();
                cmd = new SqlCommand("update Ticket set owner = '" + tb_Owner.Text + "', storeNumb = '" + tb_StoreNumb.Text + "' where ticketID ='" +  +id + "'", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated!!!");
                showData();
            }
            catch (Exception exx)
            {

                MessageBox.Show(exx.Message);
                con.Close();
            }
            

        }

        Nullable<int> i = null;

        //Works
        private void searchByOwner_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                string searchQuery = searchByOwner.Text;

                string quuuuuuuery = "select * from Ticket where owner like '" + searchQuery + "%'";
                SqlDataAdapter newadapt = new SqlDataAdapter(quuuuuuuery, con);
                DataTable dttt = new DataTable();
                newadapt.Fill(dttt);
                dataGridView1.DataSource = dttt;

                //MessageBox.Show("Searched.");
                //dataGridView1.Update();
                dataGridView1.Refresh();
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        private void tb_SearchBy_StoreNumber_TextChanged(object sender, EventArgs e)
        {
            

            try
            {
                con.Open();

                string searchQuery = tb_SearchBy_StoreNumber.Text;

                string quuuuuuuery = "select * from Ticket where storeNumb like '" + searchQuery + "%'";
                SqlDataAdapter newadapt = new SqlDataAdapter(quuuuuuuery, con);
                DataTable dttt = new DataTable();
                newadapt.Fill(dttt);
                dataGridView1.DataSource = dttt;

                //MessageBox.Show("Searched.");
                //dataGridView1.Update();
                dataGridView1.Refresh();
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void cb_SearchBy_Team_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                string searchQuery = cb_SearchBy_Team.SelectedItem.ToString();

                string quuuuuuuery = "select * from Ticket where team like '" + searchQuery + "%'";
                SqlDataAdapter newadapt = new SqlDataAdapter(quuuuuuuery, con);
                DataTable dttt = new DataTable();
                newadapt.Fill(dttt);
                dataGridView1.DataSource = dttt;

                //MessageBox.Show("Searched.");
                //dataGridView1.Update();
                dataGridView1.Refresh();
                con.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Create_Report_Click(object sender, EventArgs e)
        {
            
            con.Open();

            cmd = new SqlCommand("Select * from Ticket", con);
            SqlDataReader reader = cmd.ExecuteReader();

            string fileName = "test_Report.csv";
            StreamWriter sw = new StreamWriter(fileName);
            object[] output = new object[reader.FieldCount];

            for (int i = 0; i < reader.FieldCount; i++)
                output[i] = reader.GetName(i);

            sw.WriteLine(string.Join(",", output));

            while (reader.Read())
            {
                reader.GetValues(output);
                sw.WriteLine(string.Join(",", output));
            }

            sw.Close();
            reader.Close();
            con.Close();

            MessageBox.Show("Report created successfuly.");
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            searchByOwner.Text = "";
            tb_SearchBy_StoreNumber.Text = "";
            cb_SearchBy_Team.SelectedIndex = -1;
        }
    }
}
