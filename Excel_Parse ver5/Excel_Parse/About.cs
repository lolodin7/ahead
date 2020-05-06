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
    public partial class About : Form
    {
        private MainFormView controlMainForm;
        private string info_text;

        public About(MainFormView _mf)
        {
            InitializeComponent();

            controlMainForm = _mf;

            info_text = "Версия 1.1.3\n\n- Добавлен раздел \"Сессии\"\n- Фикс мелких багов";
        }

        private void About_FormClosing(object sender, FormClosingEventArgs e)
        {
            controlMainForm.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(info_text, "О программе");
        }
    }
}
