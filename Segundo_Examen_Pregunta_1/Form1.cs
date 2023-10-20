using System.Data;

namespace Segundo_Examen_Pregunta_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int replicas = int.Parse(textBox1.Text);
            double liminf = double.Parse(textBox2.Text);
            double limsup = double.Parse(textBox3.Text);
            double a_1 = double.Parse(textBox4.Text);
            double b_1 = double.Parse(textBox5.Text);

            if (liminf >= limsup)
            {
                MessageBox.Show("El límite superior debe ser mayor al límite inferior");
                return;
            }


            DataTable dt = new DataTable();
            dt.Columns.Add("Iteración", typeof(int));
            dt.Columns.Add("Valor aleatorio", typeof(double));
            dt.Columns.Add("Altura del punto", typeof(double));
            dt.Columns.Add("Área", typeof(double));

            Random rand = new Random();
            double sum = 0;
            for (int i = 0; i < replicas; i++)
            {
                double numaleatorio = liminf + (limsup - liminf) * rand.NextDouble();
                double funcionexp = Math.Pow(a_1, b_1 * numaleatorio);
                sum += funcionexp;

                dt.Rows.Add(i + 1, numaleatorio, funcionexp, (limsup - liminf) * funcionexp / replicas);
            }

            dataGridView1.DataSource = dt;

            double area = (limsup - liminf) * sum / replicas;
            label8.Text = "Estimación de la integral: " + area.ToString();

        }
    }
}