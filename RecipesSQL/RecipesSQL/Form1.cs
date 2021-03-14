using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipesSQL
{
    public partial class Form1 : Form
    {
        string type = "";
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            showRecipes();
        }
        private void ExcNQ(string commandTxt)
        {
            string connectionString = @"Data Source=DESKTOP-QCT98SA\SQLEXPRESS;Initial Catalog=DBRecipes;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString); // יצירת האובייקט
            SqlCommand command = new SqlCommand(commandTxt, connection); // command -הגדרת ה

            connection.Open(); // התחלת ביצוע הפעולה
            command.ExecuteNonQuery();
            connection.Close(); // סגירת הפעולה
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtTime.Text != ""  && cbCategory.Text != "" && (rbRegular.Checked || rbMeat.Checked || rbVegetarian.Checked || rbVegan.Checked))
            {
                if (rbRegular.Checked) { type = rbRegular.Text; }
                if (rbMeat.Checked) { type = rbMeat.Text; }
                if (rbVegetarian.Checked) { type = rbVegetarian.Text; }
                if (rbVegan.Checked) { type = rbVegan.Text; }

                ExcNQ(  $"INSERT INTO TBRecipes(Recipe_Name, Recipe_Time, Recipe_Type, Recipe_Category) " +
                        $"VALUES('{txtName.Text}', '{txtTime.Text}', '{type}', '{cbCategory.Text}')"    );
                showRecipes();
            }
            else
            {
                MessageBox.Show(".שגיאה: מלא את כל החלקים החסרים\n.למעט שדה מס' המתכון");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtTime.Text != "" && cbCategory.Text != "" && (rbRegular.Checked || rbMeat.Checked || rbVegetarian.Checked || rbVegan.Checked))
            {
                if (rbRegular.Checked) { type = rbRegular.Text; }
                if (rbMeat.Checked) { type = rbMeat.Text; }
                if (rbVegetarian.Checked) { type = rbVegetarian.Text; }
                if (rbVegan.Checked) { type = rbVegan.Text; }

                ExcNQ(  $"UPDATE TBRecipes " +
                        $"Set Recipe_Name='{txtName.Text}', Recipe_Time='{txtTime.Text}', Recipe_Type='{type}', Recipe_Category='{cbCategory.Text}'" +
                        $"Where Recipe_Id='{txtID.Text}'"   );
                showRecipes();
            }
            else
            {
                MessageBox.Show(".שגיאה: מלא את כל החלקים החסרים\n.למעט שדה מס' המתכון");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ExcNQ(  $"DELETE TBRecipes " +
                    $"Where Recipe_Id='{txtID.Text}'");
            showRecipes();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            showRecipes();
        }

        private void showRecipes()
        {
            string connectionString = @"Data Source=DESKTOP-QCT98SA\SQLEXPRESS;Initial Catalog=DBRecipes;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString); // יצירת האובייקט
            SqlCommand command = new SqlCommand(    $"SELECT * " +
                                                    $"From TBRecipes " +
                                                    $"Order by Recipe_Id", connection    ); // command -הגדרת ה

            connection.Open(); // התחלת ביצוע הפעולה
            SqlDataReader reader = command.ExecuteReader();
            DataTable recipes = new DataTable();
            recipes.Load(reader);
            dgvRecipes.DataSource = recipes;
            connection.Close(); // סגירת הפעולה
        }
    }
}
