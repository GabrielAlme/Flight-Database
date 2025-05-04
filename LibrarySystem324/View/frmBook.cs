using LibrarySystem324.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LibrarySystem324
{
    public partial class frmBook : Form
    {
        private DataTable dt = new DataTable();
        private Schedule selectedBook;
        public frmBook()
        {
            InitializeComponent();
        }

      
   
        private void button2_Click(object sender, EventArgs e)
        {
            Schedule.createNew();
            showBooks();    
        }

       

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
            DataGridView Grd = dataGridView1;
            DataTable Tbl = (DataTable)Grd.DataSource;
            DataRow SelRow = Tbl.Rows[];
            Schedule bok = new Schedule(SelRow);

            drpPlane.SelectedValue = bok.PlaneID;
            drpAirport.SelectedValue = bok.Arrival_Airport;
            drpGate.SelectedValue= bok.Arrival_Gate;

            selectedBook = bok;
            }
            catch (Exception ex) { }
        }


        private void showBooks()
        {
            // DataTable aTable = DBEngin.GetTable("select * from Book");
            DataTable aTable = Schedule.booksTableWithAuthorName();
            dataGridView1.DataSource = aTable;
            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt1 = DBEngine.GetTable("Select PlaneID from Plane;");
            drpPlane.DataSource = dt1;
            drpPlane.DisplayMember = "Plane_ID";
            drpPlane.ValueMember = "PlaneID";

            DataTable dt2 = DBEngine.GetTable("Select Distinct Location from Gate");
            drpAirport.DataSource = dt2;
            drpAirport.DisplayMember = "Arrival_Airport";
            drpAirport.ValueMember = "Location";

            DataTable dt3 = DBEngine.GetTable("Select Distinct GateNo from Gate");
            drpGate.DataSource = dt3;
            drpGate.DisplayMember = "Arrival_Gate";
            drpGate.ValueMember = "GateNo";
            showBooks();
        }



        private void button3_Click(object sender, EventArgs e)
        {
            //txtBookID.Text, txtTitle.Text, txtISBN.Text, txtPubYear.Text, drpAuthor.SelectedValue.ToString()
            selectedBook.Arrival_Airport = drpAirport.SelectedValue.ToString();
            selectedBook.Arrival_Gate = drpGate.SelectedValue.ToString();
            selectedBook.PlaneNo = Int32.Parse(drpPlane.SelectedValue.ToString());

            selectedBook.save();
            showBooks();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete Schedule with " +
                "PlaneNo (" + selectedBook.Arrival_Airport + ")", "Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                selectedBook.delete();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
            showBooks();
        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
         dataGridView1.DataSource = Schedule.search(" a.AirportName like '%"+ txtSearch.Text.Trim() +"%'");
       
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
