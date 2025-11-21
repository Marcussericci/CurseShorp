namespace Win
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtname.Text == "asd" && txtpass.Text == "123")
            {

                main main = new main();
                this.Hide();
                main.ShowDialog();
            }
            else
            {
                MessageBox.Show("You need to write correct Username and password");
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
