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


namespace Ticketing_System_Forms
{
    public partial class Form2 : Form
    {


        SqlConnection con = new SqlConnection("Data Source=WRSBP185150-J7T\\SQLEXPRESS;Initial Catalog=LocalDB;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        DataSet ds;

        //-------------------------------------------------------------------------------------------------------------------------------------




        Ticket model = new Ticket();




        //-------------------------------------------------------------------------------------------------------------------------------------

        public void retrieveId()

        {

            try
            {
                con.Open();
                string query = "select ticketID from Ticket";
                cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int value = int.Parse(reader[0].ToString()) + 1;
                    tb_TicketID.Text = value.ToString();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
           
        }
       

        void randomTicketID()
        {
            Random slumpGenerator = new Random();
            int tal = slumpGenerator.Next(40, 240);
            tb_TicketID.Text = tal.ToString();

        }

        public Form2()
        {
            InitializeComponent();
            var frm1 = new Form1();
            tb_Owner.Text = frm1.qlid;
            //enableTicketStatusAfterFillingFields();
            //randomTicketID();


            retrieveId();

            tb_Created.Text = DateTime.Now.ToString("dd-MM-yyyy");

            label_currentUser.Text = frm1.qlid;


            //if (tb_ResolutionNote.Text == "" || cb_ResolutionCode.SelectedIndex == -1 || cb_ResolutionType.SelectedIndex == -1)
            //{
            //    cb_Status.Enabled = false;
            //}
            //else
            //{

            //    cb_Status.Enabled = true;
            //}

           


        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            tb_Created.Text = DateTime.Now.ToString("dd-MM-yyyy");


        }

        public void trash()
        {
            
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            void oldSQL()
            {

                //cmd = new SqlCommand("insert into dbo.BP185150_TICKETING(owner, storeNumb, deviceNumber, team, status, severity, priority, type, tCode, tSubtype, tCategory, tType, problemNotes, callerPhone, callerName, resCode, resType, resNotes, created, closed, lastUpdatedBy, assigned) values(@owner, @storeNumber, @deviceNumber, @team, @status, @severity, @priority, @type, @tCode, @tSubtype, @tCategory, @tType, @problemNotes, @callerPhone, @callerName, @resCode, @resType, @resNotes, @created, @closed, @lastUpdatedBy, @assigned)", con);
                //con.Open();


                //cmd.Parameters.AddWithValue("@owner", tb_Owner.Text);
                //cmd.Parameters.AddWithValue("@storeNumber", tb_StoreNumber.Text);
                //cmd.Parameters.AddWithValue("@deviceNumber", tb_DeviceNumber.Text);
                //cmd.Parameters.AddWithValue("@team", tb_Team.Text);
                //cmd.Parameters.AddWithValue("@status", cb_Status.SelectedItem);
                //cmd.Parameters.AddWithValue("@severity", cb_Severity.SelectedItem);
                //cmd.Parameters.AddWithValue("@priority", cb_Priority.SelectedItem);
                //cmd.Parameters.AddWithValue("@type", cb_Type.SelectedItem);
                //cmd.Parameters.AddWithValue("@tCode", cb_Code.SelectedItem);
                //cmd.Parameters.AddWithValue("@tSubtype", cb_Subtype.SelectedItem);
                //cmd.Parameters.AddWithValue("@tCategory", cb_Category.SelectedItem);
                //cmd.Parameters.AddWithValue("@tType", cb_TD_Type.SelectedItem);
                //cmd.Parameters.AddWithValue("@problemNotes", tb_ProblemNotes.Text);
                //cmd.Parameters.AddWithValue("@callerPhone", tb_CallerPhone.Text);
                //cmd.Parameters.AddWithValue("@callerName", tb_CallerName.Text);
                //cmd.Parameters.AddWithValue("@resCode", cb_ResolutionCode.SelectedItem);
                //cmd.Parameters.AddWithValue("@resType", cb_ResolutionType.SelectedItem);
                //cmd.Parameters.AddWithValue("@resNotes", tb_ResolutionNote.Text);
                //cmd.Parameters.AddWithValue("@created", tb_Created.Text);
                //cmd.Parameters.AddWithValue("@closed", tb_Closed.Text);
                //cmd.Parameters.AddWithValue("@lastUpdatedBy", tb_LastUpdatedBy.Text);
                //cmd.Parameters.AddWithValue("@assigned", tb_AssignedTo.Text);


                //cmd.ExecuteNonQuery();

                //con.Close();
            }

            Console.WriteLine("Button pressed.");


            try
            {
                model.ticketID = int.Parse(tb_TicketID.Text);
                model.owner = tb_Owner.Text;
                model.storeNumb = tb_StoreNumber.Text;
                model.deviceNumber = tb_DeviceNumber.Text;
                model.team = tb_Team.Text;
                model.status = cb_Status.SelectedItem.ToString();
                model.severity = cb_Severity.SelectedItem.ToString();
                model.priority = cb_Priority.SelectedItem.ToString();
                model.type = cb_Type.SelectedItem.ToString();
                model.tCode = cb_Code.SelectedItem.ToString();
                model.tSubtype = cb_Subtype.SelectedItem.ToString();
                model.tCategory = cb_Category.SelectedItem.ToString();
                model.tType = cb_TD_Type.SelectedItem.ToString();
                model.problemNotes = tb_ProblemNotes.Text;
                model.callerPhone = tb_CallerPhone.Text;
                model.callerName = tb_CallerName.Text;
                model.resCode = cb_ResolutionCode.SelectedItem.ToString();
                model.resType = cb_ResolutionType.SelectedItem.ToString();
                model.resNotes = tb_ResolutionNote.Text;
                model.created = tb_Created.Text;
                model.closed = tb_Closed.Text;
                model.lastUpdatedBy = tb_LastUpdatedBy.Text;
                model.assigned = tb_AssignedTo.Text;


                using (LocalDBEntities db = new LocalDBEntities())
                {
                    db.Tickets.Add(model);
                    db.SaveChanges();
                }

                MessageBox.Show("Record Inserted Successfully");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

         
        }

        

        private void tb_ResolutionNote_TextChanged(object sender, EventArgs e)
        {
            cb_Status.Enabled = true;

        }

        private void btn_Update_Click_1(object sender, EventArgs e)
        {
            Console.WriteLine("Button pressed.");

            Form3 frm3 = new Form3();
            frm3.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Button pressed.");

            


            try
            {
                model.ticketID = int.Parse(tb_TicketID.Text);
                model.owner = tb_Owner.Text;
                model.storeNumb = tb_StoreNumber.Text;
                model.deviceNumber = tb_DeviceNumber.Text;
                model.team = tb_Team.Text;
                model.status = cb_Status.SelectedItem.ToString();
                model.severity = cb_Severity.SelectedItem.ToString();
                model.priority = cb_Priority.SelectedItem.ToString();
                model.type = cb_Type.SelectedItem.ToString();
                model.tCode = cb_Code.SelectedItem.ToString();
                model.tSubtype = cb_Subtype.SelectedItem.ToString();
                model.tCategory = cb_Category.SelectedItem.ToString();
                model.tType = cb_TD_Type.SelectedItem.ToString();
                model.problemNotes = tb_ProblemNotes.Text;
                model.callerPhone = tb_CallerPhone.Text;
                model.callerName = tb_CallerName.Text;
                model.resCode = cb_ResolutionCode.SelectedItem.ToString();
                model.resType = cb_ResolutionType.SelectedItem.ToString();
                model.resNotes = tb_ResolutionNote.Text;
                model.created = tb_Created.Text;
                model.closed = tb_Closed.Text;
                model.lastUpdatedBy = tb_LastUpdatedBy.Text;
                model.assigned = tb_AssignedTo.Text;


                using (LocalDBEntities db = new LocalDBEntities())
                {
                    db.Tickets.Add(model);
                    db.SaveChanges();
                }

                MessageBox.Show("Record Inserted Successfully");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
    }
    }

