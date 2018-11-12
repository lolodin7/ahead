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

namespace Excel_Parse
{
    public partial class Products : Form
    {
        private SqlConnection connection;
        private int ProductId;

        public Products()
        {
            InitializeComponent();

        }
    }
}
