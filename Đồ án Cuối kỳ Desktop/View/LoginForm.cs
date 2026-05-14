using Đồ_án_Cuối_kỳ_Desktop.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Đồ_án_Cuối_kỳ_Desktop
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        private void picConMat_Click(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar == true || txtPassword.PasswordChar != '\0')
            {
                txtPassword.UseSystemPasswordChar = false;
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Khởi tạo Context 
            using (QuanLySanCauLongContext db = new QuanLySanCauLongContext())
            {
                var user = db.NhanViens.Where(u => u.TenDangNhap == username).FirstOrDefault();

                if (user == null)
                {
                    MessageBox.Show("Tên đăng nhập không tồn tại!");
                    txtUsername.Focus();
                }
                else
                {
                    if (user.MatKhau == password)
                    {
                        MessageBox.Show("Đăng nhập thành công!");

                        MainForm f = new MainForm();
                        this.Hide();
                        f.ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu không chính xác!");
                        txtPassword.Focus();
                    }
                }
            }
        }

    }
}
