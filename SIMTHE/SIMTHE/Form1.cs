using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace SIMTHE
{
    public partial class Form1 : Form
    {
        private string connectionString = "Data Source=LAPTOP-0GVJC0P1\\SQLEXPRESS;Initial Catalog=sqlSIMTHE;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Sim ORDER BY NgayKichHoat ASC"; // Truy vấn SQL để lấy dữ liệu
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridViewSim.DataSource = dataTable; // Gán dữ liệu cho DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }
        private void btnLoadData_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}