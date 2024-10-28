using System;
using System.Windows.Forms;

namespace xxxxx
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //LS
            txt_ResultLs.ReadOnly = true;
            //LQ
            txt_Result.ReadOnly = true;
        }
        private void AcceptOnlyNumberInTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                            && !char.IsDigit(e.KeyChar)
                            && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        private void btn_Calc_Click(object sender, EventArgs e)
        {
            try
            {
                // قراءة المدخلات
                double lambda = Convert.ToDouble(txt_Lambda.Text);
                double wq = Convert.ToDouble(txt_Wq.Text);
                double ws = Convert.ToDouble(txt_Ws.Text);
                // حساب Lq و Ls
                double Lq = lambda * wq;
                double Ls = lambda * ws;
                txt_ResultLs.Text = Ls.ToString();
                txt_Result.Text = Lq.ToString();
            }
            catch (Exception ex)
            {
                if (ex is FormatException)
                {
                    MessageBox.Show("يرجى التأكد من إدخال قيم صحيحة.");

                }
                else
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
