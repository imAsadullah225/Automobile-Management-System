using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using MetroFramework;
using MetroFramework.Controls;
using System.IO;

namespace AutomobileManagementSys
{
    public partial class multiForms : Form
    {
        #region MultiForms All Classes

        private class Accounts
        {
           static protected string Username { get; set; }
           static protected string Password { get; set; }
           static protected string SecurityQues { get; set; }
           static protected string SecurityAns { get; set; }
           static protected string Path { get; set; }
           static protected multiForms multiForm;
        }

        private class Login : Accounts
        {
            public Login(string _Username, string _Password, string _Path, multiForms _multiForm)
            {
                Username = _Username;
                Password = _Password;
                Path = _Path;
                multiForm = _multiForm;

                if (Username == "" || Username == "Username" || Password == "" || Password == "Password")
                {
                    MetroMessageBox.Show(multiForm,
                        "Please fill in all fields",
                        "Blank fields",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
                }
                else
                {
                    StreamReader sr = new StreamReader(Path);
                    string DB_Username = sr.ReadLine();
                    string DB_Password = sr.ReadLine();

                    if (Username == DB_Username && Password == DB_Password)
                    {
                        ManagementSysForm managementForm = new ManagementSysForm();
                        managementForm.currentUser_Label.Text = Username;
                        multiForm.Hide();
                        managementForm.Closed += (s, args) => multiForm.Close();
                        managementForm.Show();

                    }
                    else
                    {
                        MetroMessageBox.Show(multiForm,
                        "Please Enter Right Username and Password",
                        "Incorrect Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
                    }
                }
            }
        }

        private class Register : Accounts
        {
            
            public Register(string _Username, 
                string _Password, 
                string _SecurityQues, string _SecurityAns, string _Path, multiForms _multiForm)
            {
                Username = _Username;
                Password = _Password;
                SecurityQues = _SecurityQues;
                SecurityAns = _SecurityAns;
                Path = _Path;
                multiForm = _multiForm;

                if(!File.Exists(Path))
                {
                    if (Username == "" || Username == "Username" ||
                        Password == "" || Password == "Create Password" ||
                        SecurityQues == "" || SecurityQues == "Select a Security Question" ||
                        SecurityAns == "" || SecurityAns == "Security Answer")
                    {
                        MetroMessageBox.Show(multiForm,
                        "Please fill in all fields",
                        "Blank fields",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
                    }
                    else
                    {
                        StreamWriter sw = new StreamWriter(Path);
                        sw.WriteLine(Username);
                        sw.WriteLine(Password);
                        sw.WriteLine(SecurityQues);
                        sw.WriteLine(SecurityAns);
                        sw.Close();

                        MetroMessageBox.Show(multiForm,
                        "Your Account has been Created",
                        "Sucessfully Created",
                        MessageBoxButtons.OK, MessageBoxIcon.Question, 125);
                    }
                }
                else
                {
                    MetroMessageBox.Show(multiForm,
                        "Sorry you don't have Permission to Create another Admin",
                        "Already a Admin Exists",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
                }
                
            }
        }

        private class Reset : Accounts
        {
            public Reset(string _Username, string _SecurityQue, string _SecurityAns, string _Path, multiForms _multiform)
            {
                Username = _Username;
                SecurityQues = _SecurityQue;
                SecurityAns = _SecurityAns;
                Path = _Path;
                multiForm = _multiform;
            }

            public Reset(string newPassword, string _SecurityAns, string _Path, multiForms _multiform)
            {
                Password = newPassword;
                Path = _Path;
                multiForm = _multiform;

                string DB_SecurityAns = SecurityAns;

                if (Password == "" || Password == "New Password" || _SecurityAns == "" || _SecurityAns == "Security Answer")
                {
                    MetroMessageBox.Show(multiForm,
                        "Please fill in all fields",
                        "Blank fields",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
                }
                else
                {
                    if (_SecurityAns == DB_SecurityAns)
                    {
                        StreamWriter sw = new StreamWriter(Path);
                        sw.WriteLine(Username);
                        sw.WriteLine(Password);
                        sw.WriteLine(SecurityQues);
                        sw.WriteLine(SecurityAns);
                        sw.Close();

                        MetroMessageBox.Show(multiForm,
                        "Your Account has been Reset Sucessfully",
                        "Password Changed",
                        MessageBoxButtons.OK, MessageBoxIcon.Question, 125);
                    }
                    else
                    {
                        MetroMessageBox.Show(multiForm,
                        "Please Enter Right Securtiy Answer",
                        "Wrong Security Answer",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
                    }
                }
            }
        }

        #endregion

        #region Login, Register, Reset (Buttons Events)

        private void login_Button_Click(object sender, EventArgs e)
        {
            string directoryPath;
            directoryPath = Environment.CurrentDirectory + "\\Database\\Accounts\\Admin\\AdminInfo.txt";

            Login loginAccount = new Login(username_Textbox.Text, password_Textbox.Text, directoryPath, this);
        }

        private void register_Button_Click(object sender, EventArgs e)
        {
            string directoryPath;

            Directory.CreateDirectory(Environment.CurrentDirectory + "\\Database\\Accounts\\Admin");
            directoryPath = Environment.CurrentDirectory + "\\Database\\Accounts\\Admin\\AdminInfo.txt";

            Register reg = new Register(regUsername_Textbox.Text, 
                regPassword_Textbox.Text, 
                regSecurityQue_DropDown.selectedValue, 
                regSecurityAns_Textbox.Text, 
                directoryPath, this);
        }

        private void gotoReset_Button_Click(object sender, EventArgs e)
        {
            if (username_Textbox.Text == "" || username_Textbox.Text == "Username")
            {
                MetroMessageBox.Show(this,
                        "Please Enter Admin Username which you wants to Reset",
                        "Blank field",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
            }
            else
            {
                string directoryPath;
                directoryPath = Environment.CurrentDirectory + "\\Database\\Accounts\\Admin\\AdminInfo.txt";

                if (File.Exists(directoryPath))
                {
                    string DB_Username;
                    string DB_Password;
                    string DB_SecurityQues;
                    string DB_SecurityAns;

                    StreamReader sr = new StreamReader (directoryPath);
                    DB_Username = sr.ReadLine(); 
                    DB_Password =  sr.ReadLine();
                    DB_SecurityQues = sr.ReadLine();
                    DB_SecurityAns = sr.ReadLine();
                    sr.Close();

                    if (username_Textbox.Text == DB_Username)
                    {
                        rsetUsername_Textbox.Text = DB_Username;
                        rsetSecurityQue_Textbox.Text = DB_SecurityQues;

                        Reset infoReset = new Reset(DB_Username, DB_SecurityQues, DB_SecurityAns, directoryPath, this);

                        Buttons_Separator.Visible = false;
                        resetAccount_Panel.Location = new Point(0, 185);
                        login_Panel.Location = new Point(391, 185);
                        register_Panel.Location = new Point(784, 185);
                    }
                    else
                    {
                        MetroMessageBox.Show(this,
                        "Sorry this Admin Username is not Registered",
                        "Invalid Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
                    }
                }
                else
                {
                    MetroMessageBox.Show(this,
                        "Sorry no Admin Record found please Register a Admin",
                        "No Record",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop, 125);
                }
            }
        }

        private void resetAccount_Button_Click(object sender, EventArgs e)
        {
            string directoryPath;
            directoryPath = Environment.CurrentDirectory + "\\Database\\Accounts\\Admin\\AdminInfo.txt";

            Reset passReset = new Reset(rsetPassword_Textbox.Text, rsetSecurityAns_Textbox.Text, directoryPath, this);
        }

        #endregion

        #region multiForms Constructors

        public multiForms()
        {
            InitializeComponent();
        }

        #endregion

        #region Form Border Buttons Events & Methods

        private void close_Button_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void minimized_Button_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        #endregion

        #region All Events

        private void gotoLogin_Button_Click(object sender, EventArgs e)
        {
            Buttons_Separator.Visible = true;
            Buttons_Separator.Location = new Point(42, 168);
            login_Panel.Location = new Point(0, 185);
            register_Panel.Location = new Point(391, 185);
            resetAccount_Panel.Location = new Point(784, 185);
        }

        private void gotoRegister_Button_Click(object sender, EventArgs e)
        {
            Buttons_Separator.Visible = true;
            Buttons_Separator.Location = new Point(191, 168);
            login_Panel.Location = new Point(391, 185);
            register_Panel.Location = new Point(0, 185);
            resetAccount_Panel.Location = new Point(784, 185);
        }

        public void RemoveText(object sender, EventArgs e)
        {
            BunifuMetroTextbox tb = (BunifuMetroTextbox)sender;

            if (tb.Text == "Username" || tb.Text == "Security Answer")
            {
                tb.Text = "";
            }
            else if (tb.Text == "Password")
            {
                tb.Text = "";
                password_Textbox.isPassword = true;
            }
            else if (tb.Text == "Create Password")
            {
                tb.Text = "";
                regPassword_Textbox.isPassword = true;
            }
            else if (tb.Text == "New Password")
            {
                tb.Text = "";
                rsetPassword_Textbox.isPassword = true;
            }
        }

        public void AddText(object sender, EventArgs e)
        {
            if (username_Textbox.Text == "")
            {
                username_Textbox.Text = "Username";
            }
            else if (password_Textbox.Text == "")
            {
                password_Textbox.isPassword = false;
                password_Textbox.Text = "Password";
            }
            else if (regUsername_Textbox.Text == "")
            {
                regUsername_Textbox.Text = "Username";
            }
            else if (regSecurityAns_Textbox.Text == "")
            {
                regSecurityAns_Textbox.Text = "Security Answer";
            }
            else if (regPassword_Textbox.Text == "")
            {
                regPassword_Textbox.isPassword = false;
                regPassword_Textbox.Text = "Create Password";
            }
            else if (rsetPassword_Textbox.Text == "")
            {
                rsetPassword_Textbox.isPassword = false;
                rsetPassword_Textbox.Text = "New Password";
            }
            else if (rsetSecurityAns_Textbox.Text == "")
            {
                rsetSecurityAns_Textbox.Text = "Security Answer";
            }
        }

        #endregion
    }
}
