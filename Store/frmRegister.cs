using NLog; // Import the NLog namespace
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Store
{
    public partial class frmRegister : Form
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger(); // NLog Logger instance
        private readonly AppDbContext _context = new AppDbContext();

        public frmRegister()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string UserName = txtName.Text;
            string Password = txtPassword.Text;
            string role = string.Empty;

            try
            {
                if (rdoAdmin.Checked || rdoUser.Checked)
                {
                    if (rdoAdmin.Checked)
                    {
                        role = "admin";
                    }
                    else if (rdoUser.Checked)
                    {
                        role = "user";
                    }
                }
                else
                {
                    MessageBox.Show("Please Select Role", "Shop", MessageBoxButtons.OK);
                    logger.Warn("Role not selected during registration attempt.");
                    return;
                }

                if (string.IsNullOrEmpty(UserName))
                {
                    MessageBox.Show("Please Enter the UserName", "Shop", MessageBoxButtons.OK);
                    logger.Warn("Username field was empty.");
                    return;
                }

                if (!IsValidPassword(Password))
                {
                    MessageBox.Show("Please Enter Correct password", "Shop", MessageBoxButtons.OK);
                    logger.Warn("Invalid password format for user: {0}", UserName);
                    return;
                }

                User user = new User();
                user.Username = UserName;
                user.PasswordHash = Password;
                user.Role = role;

                var CheckUser = _context.Users.FirstOrDefault(a => a.Username.Equals(UserName));

                if (CheckUser == null)
                {
                    var Check = _context.Users.FirstOrDefault(a => a.Username.Equals(UserName));
                    if(Check == null)
                    {
                        var Register = _context.Users.Add(user);
                        _context.SaveChanges();
                        if (Register != null)
                        {
                            MessageBox.Show("User Registered Successfully", "Shop", MessageBoxButtons.OK);
                            logger.Info("New user registered: {0}", UserName);

                            txtName.Text = "";
                            txtPassword.Text = "";
                            this.Close();
                            int UserId = _context.Users.FirstOrDefault(a=>a.Username.Equals(UserName)).UserID;
                            frmMain frmMain = new frmMain(UserId);
                            frmMain.ShowDialog();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("UserName Already Exists", "Shop", MessageBoxButtons.OK);
                    logger.Warn("Registration attempt failed: Username '{0}' already exists.", UserName);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error occurred during registration.");
                MessageBox.Show("An error occurred while registering. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool IsValidPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                logger.Warn("Password validation failed: Password is empty.");
                return false;
            }

            // Minimum 6 characters, at least one number, and one special character
            string pattern = @"^(?=.*[0-9])(?=.*[!@#$%^&*])[a-zA-Z0-9!@#$%^&*]{6,}$";
            bool isValid = Regex.IsMatch(password, pattern);

            if (!isValid)
            {
                logger.Warn("Password validation failed: Does not meet criteria.");
            }

            return isValid;
        }
    }
}
