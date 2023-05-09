using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace Oishi.WinForms.Administration.Forms.Users
{
    public partial class UserList : Form
    {
        private Oishi.Data.Contexts.DatabaseContext? dbContext;

        public UserList()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            dbContext = new Contexts.ApplicationDatabaseContext();

            // Uncomment the line below to start fresh with a new database.
            // this.dbContext.Database.EnsureDeleted();
            //this.dbContext.Database.EnsureCreated();

            this.dbContext.UserAccounts.Load();

            this.userAccountBindingSource.DataSource = dbContext.UserAccounts.Local.ToBindingList();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            this.dbContext?.Dispose();
            this.dbContext = null;
        }
    }
}
