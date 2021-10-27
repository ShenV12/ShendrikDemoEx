using Microsoft.Win32;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WpfApp4.Moduel;

namespace WpfApp4.Pages
{
    /// <summary>
    /// Interaction logic for PageAddAgent.xaml
    /// </summary>
    public partial class PageAddAgent : Page
    {
        private Agent agent;
        public PageAddAgent(Agent agent)
        {
            InitializeComponent();

            this.agent = agent;

            cbType.ItemsSource = DB.db.AgentType.ToList();

            cbType.SelectedIndex = 0;

            if (agent == null)
            {
                MessageBox.Show("Не выбран объект");
            }
            else
            {
                CheackAgent();
            }
        }

        private void CheackAgent()
        {
            tbTitle.Text = agent.Title;
            tbAddress.Text = agent.Address;
            tbINN.Text = agent.INN;
            tbKPP.Text = agent.KPP;
            tbDirector.Text = agent.DirectorName;
            tbPhone.Text = agent.Phone;
            tbEmail.Text = agent.Email;
            tbPriority.Text = agent.Priority.ToString();
            tbLogo.Text = agent.Logo;

            if (agent.AgentType == null)
            {
                cbType.SelectedIndex = 0;
            }
            else
            {
                cbType.SelectedItem = agent.AgentType;
            }
        }


        private void btnImageLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Выберите изображение";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                tbLogo.Text = op.FileName;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbLogo.Text))
            {
                tbLogo.Text = null;
            }

            if (string.IsNullOrWhiteSpace(tbTitle.Text) || string.IsNullOrWhiteSpace(tbAddress.Text) ||
                string.IsNullOrWhiteSpace(tbINN.Text) || string.IsNullOrWhiteSpace(tbKPP.Text) ||
                string.IsNullOrWhiteSpace(tbDirector.Text) || string.IsNullOrWhiteSpace(tbPhone.Text) ||
                string.IsNullOrWhiteSpace(tbEmail.Text) || string.IsNullOrWhiteSpace(tbPriority.Text) ||
                cbType.SelectedItem == null)
            {
                MessageBox.Show("Не все поля заполнены");
            }
            else
            {

                agent.Title = tbTitle.Text;
                agent.Address = tbAddress.Text;
                agent.INN = tbINN.Text;
                agent.KPP = tbKPP.Text;
                agent.DirectorName = tbDirector.Text;
                agent.Phone = tbPhone.Text;
                agent.Email = tbEmail.Text;
                agent.Priority =int.Parse(tbPriority.Text);
                agent.Logo = tbLogo.Text;

                DB.db.SaveChanges();

                FrameObj.frameMain.Navigate(new PageAgents());

            }
        }
    }
}
