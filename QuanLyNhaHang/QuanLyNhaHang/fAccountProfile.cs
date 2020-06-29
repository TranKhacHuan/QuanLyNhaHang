using QuanLyNhaHang.DAO;
using QuanLyNhaHang.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHang
{
    public partial class fAccountProfile : Form
    {
        public Action<string> ChangeInfo;
        private AccountDTO loginAccount;

        public AccountDTO LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(LoginAccount); }
        }
        public fAccountProfile(AccountDTO acc)
        {
            InitializeComponent();
            LoginAccount = acc;
        }
        void ChangeAccount(AccountDTO acc)
        {
            txbUserName.Text = LoginAccount.UserName;
            txbDisplayName.Text = LoginAccount.DisplayName;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void UpdateAccountInfo()
        {
            string displayName = txbDisplayName.Text;
            string password = txbPassWord.Text;
            string newpass = txbNewPass.Text;
            string reenterPass = txbReEnterPass.Text;
            string userName = txbUserName.Text;
            if(!newpass.Equals(reenterPass))
            {
                MessageBox.Show("Vui lòng  nhập lại  mật khẩu đúng với mật khẩu mới!");
            }
            else
            {
                if(AccountDAO.Instance.UpdateAccount(userName,displayName,password,newpass))
                {
                    MessageBox.Show("Cập nhật thành công");
                    ChangeInfo.Invoke(displayName);
                }
                else
                {
                    MessageBox.Show("Vui lòng điền đúng mật khẩu");
                }
            }    
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateAccountInfo();
        }
    }
}
