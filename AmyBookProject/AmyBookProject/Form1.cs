using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Personnel.Amy.Business;
using Personnel.Amy.Model;

namespace AmyBookProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BTN_AddBook_Click(object sender, EventArgs e)
        {
            BBook bll = new BBook();
            MBook model = new MBook();
            Random random = new Random();
            int a = random.Next(10000, 100000);
            model.KeyID = DateTime.Now.ToString("yyyyMMddHHmmss") + "0" + a;
            model.Name = this.TXT_BookName.Text.ToString();
            model.Author = this.TXT_BookAuthor.Text.ToString();
            bool ret = bll.AddBook(model);

            if (ret == true)
            {
                MessageBox.Show("添加成功");
            }
            else
            {
                MessageBox.Show("添加不成功");
            }
        }
    }
}
