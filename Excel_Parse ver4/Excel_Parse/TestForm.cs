using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Excel_Parse
{
    public partial class TestForm : Form
    {
        SemCoreBuilder smb;
        public TestForm()
        {
            InitializeComponent();
            smb = new SemCoreBuilder(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            smb.GetSemCoreJOINKeywordCategoryByProductId(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            smb.GetKeywordsByCategoryId(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            smb.GetSemCoreJOINKeywordCategoryAll();
        }
    }
}
