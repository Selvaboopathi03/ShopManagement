using NLog;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Store
{
    public partial class frmLogin : Form
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();  // Initialize NLog logger
        private AppDbContext _context = new AppDbContext();

        public frmLogin()
        {
            InitializeComponent();
            // Add items to the ComboBox first
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.Items.Add("Select Role"); // Add placeholder item
            cmbRole.Items.Add("Admin");
            cmbRole.Items.Add("User");

            // Set the default selection to the placeholder item
            cmbRole.SelectedIndex = 0; // This should now be valid
        }


        private void Login_Load(object sender, EventArgs e)
        {
            logger.Info("Login form loaded.");  // Log when the form is loaded
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string UserName = textBox1.Text.Trim();
                string Password = textBox2.Text.Trim();
                string Role = cmbRole.Text.Trim();

                // Validate that none of the fields are empty
                if (string.IsNullOrEmpty(UserName))
                {
                    MessageBox.Show("Please enter your username.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Focus(); // Set focus on the username textbox
                    return;
                }

                if (string.IsNullOrEmpty(Password))
                {
                    MessageBox.Show("Please enter your password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox2.Focus(); // Set focus on the password textbox
                    return;
                }

                if (Role == "Select Role")
                {
                    MessageBox.Show("Please select a role.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbRole.Focus();
                    return;
                }


                logger.Info($"Login attempt with username: {UserName} and role: {Role}");

                var user = _context.Users.FirstOrDefault(a => a.Username == UserName && a.PasswordHash == Password && a.Role == Role);

                if (user != null)
                {
                    logger.Info($"Login successful for user: {UserName}");

                    if (user.Role == "admin")
                    {
                        int userId = user.UserID;
                        this.Hide();
                        frmMain frmMain = new frmMain(userId);
                        frmMain.ShowDialog();
                        logger.Info($"Admin {UserName} logged in and opened frmMain.");
                    }
                    else if (user.Role == "user")
                    {
                        int userId = user.UserID;
                        this.Hide();
                        frmMain frmMain = new frmMain(userId);
                        frmMain.ShowDialog();
                        logger.Info($"User {UserName} logged in and opened frmMain.");
                    }
                }
                else
                {
                    logger.Warn($"Login failed for user: {UserName}");
                    MessageBox.Show("Invalid credentials", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "An error occurred during the login process.");
                MessageBox.Show("An error occurred while logging in", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            frmRegister frmRegister = new frmRegister();
            frmRegister.ShowDialog();
        }
    }
}
