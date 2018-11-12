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
    public partial class FieldsLength : Form
    {
        public int TitleLength { get; set; }
        public int BulletsLength { get; set; }
        public int BackendLength { get; set; }
        public int DescriptionLength { get; set; }
        public int IntendedUseLength { get; set; }
        public int SubjectMatterLength { get; set; }
        public int OtherAttributesLength { get; set; }


        public FieldsLength(int _titleLength, int _bulletsLength, int _backendLength, int _descriptionLength, int _intendedUseLength, int _subjectMatterLength, int _otherAttributesLength)
        {
            InitializeComponent();

            TitleLength = _titleLength;
            BulletsLength = _bulletsLength;
            BackendLength = _backendLength;
            DescriptionLength = _descriptionLength;
            IntendedUseLength = _intendedUseLength;
            SubjectMatterLength = _subjectMatterLength;
            OtherAttributesLength = _otherAttributesLength;

            FillFields();
        }

        private void FillFields()
        {
            tb_Title.Text = TitleLength.ToString();
            tb_Bullets.Text = BulletsLength.ToString();
            tb_Backend.Text = BackendLength.ToString();
            tb_Description.Text = DescriptionLength.ToString();
            tb_IntendedUse.Text = IntendedUseLength.ToString();
            tb_SubjectMatter.Text = SubjectMatterLength.ToString();
            tb_OtherAttributes.Text = OtherAttributesLength.ToString();
        }

        private void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            TextBox[] tb = new TextBox[7] { tb_Title, tb_Bullets, tb_Backend, tb_Description, tb_IntendedUse, tb_SubjectMatter, tb_OtherAttributes};

            for (int i = 0; i < tb.Length; i++)
            {
                if (tb[i].Text.Equals(""))
                {
                    tb[i].Text = "0";
                }
            }

            TitleLength = int.Parse(tb_Title.Text);
            BulletsLength = int.Parse(tb_Bullets.Text);
            BackendLength = int.Parse(tb_Backend.Text);
            DescriptionLength = int.Parse(tb_Description.Text);
            IntendedUseLength = int.Parse(tb_IntendedUse.Text);
            SubjectMatterLength = int.Parse(tb_SubjectMatter.Text);
            OtherAttributesLength = int.Parse(tb_OtherAttributes.Text);
        }
    }
}
