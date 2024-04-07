using FireStoreTut.Classes;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FireStoreTut.Forms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            FireStoreHelper.Instance.test();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            FireStoreHelper.Instance.addDocument2Collection("MY COLLECTION", "MY DOC2");
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            //Register register = new Register();
            //this.Hide();
            //register.ShowDialog();
            //this.Show();
            FireStoreHelper.Instance.getDataFromDocument("MY COLLECTION", "MY DOC3");
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
