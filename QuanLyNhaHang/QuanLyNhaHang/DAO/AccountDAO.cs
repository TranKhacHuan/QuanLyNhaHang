﻿using QuanLyNhaHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DAO
{
    public class AccountDAO
    {
            private static AccountDAO instance;

            public static AccountDAO Instance
            {
                get { if (instance == null) instance = new AccountDAO(); return instance; }
                private set { instance = value; }
            }

            private AccountDAO() { }

            public bool Login(string userName, string passWord)
            {
                string query = "USP_Login @userName , @passWord";

                DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { userName, passWord });

                return result.Rows.Count > 0;
            }
            public bool UpdateAccount(string userName, string displayName, string pass, string newPass)
            {
                int result = DataProvider.Instance.ExecuteNonQuery("exec USP_UpdateAccount @userName , @displayName , @password , @newPassword", new object[] { userName, displayName, pass, newPass });

                return result > 0;
            }
            public DataTable GetListAccount()
            {
            return DataProvider.Instance.ExecuteQuery("select UserName , DisplayName , Type from Account");
            }
            public AccountDTO GetAccountByUserName(string userName)
            {
                DataTable data = DataProvider.Instance.ExecuteQuery("Select * from Account where UserName = '" + userName + "'");

                foreach (DataRow item in data.Rows)
                {
                    return new AccountDTO(item);
                }

                return null;
            }
            public bool InsertAccount(string userName, string displayName, int type)
            {
                string query = string.Format("INSERT dbo.Account ( UserName, DisplayName, Type ) VALUES  ( N'{0}', N'{1}', {2} )", userName, displayName, type);
                int result = DataProvider.Instance.ExecuteNonQuery(query);
                return result > 0;
            }
            public bool UpdateAccount(string userName, string displayName, int type)
            {
                string query = string.Format("UPDATE dbo.Account SET DisplayName =N'{0}', Type={1} WHERE UserName =N'{2}'", displayName, type, userName);
                int result = DataProvider.Instance.ExecuteNonQuery(query);
                return result > 0;
            }
            public bool DeleteAccount(string userName)
            {              
                string query = string.Format("DELETE dbo.Account WHERE userName = N'{0}'", userName);
                int result = DataProvider.Instance.ExecuteNonQuery(query);
                return result > 0;
            }
            public bool ResetPass(string userName)
            {
                string query = string.Format("UPDATE dbo.Account SET password = '1' WHERE UserName = N'{0}'",userName);
                int result = DataProvider.Instance.ExecuteNonQuery(query);
                return result > 0;
        }
    }
}
