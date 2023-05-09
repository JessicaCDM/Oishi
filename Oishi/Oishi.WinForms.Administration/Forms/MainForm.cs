namespace Oishi.WinForms.Administration.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void pictureBoxButtonUser_Click(object sender, EventArgs e)
        {
            Forms.Users.UserList userListForm = new Forms.Users.UserList();
            userListForm.Show();
        }

        private void toolStripMenuItemUsersList_Click(object sender, EventArgs e)
        {
            Forms.Users.UserList userListForm = new Forms.Users.UserList();
            userListForm.MdiParent = this;
            userListForm.Dock = DockStyle.Fill;
            userListForm.Show();
        }
    }
}