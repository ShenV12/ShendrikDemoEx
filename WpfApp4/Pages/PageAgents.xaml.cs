using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp4.Moduel;

namespace WpfApp4.Pages
{
    /// <summary>
    /// Interaction logic for PageAgents.xaml
    /// </summary>
    public partial class PageAgents : Page
    {
        public PageAgents()
        {
            InitializeComponent();

            lbAgents.ItemsSource = DB.db.Agent.ToList();

            cbFilter.Items.Add("Фильтрация");
            foreach(var agentType in DB.db.AgentType)
            {
                cbFilter.Items.Add(agentType);
            }
            cbFilter.SelectedIndex = 0;

            cbsort.Items.Add("Сортировка");
            cbsort.Items.Add("От А до Я");
            cbsort.Items.Add("От Я до А");
            cbsort.SelectedIndex = 0;
        }

        private void FindAgents()
        {
            var agents = DB.db.Agent.Where(x => x.Title.StartsWith(tbFind.Text)
            || x.DirectorName.StartsWith(tbFind.Text)).ToList();

            switch (cbsort.SelectedIndex)
            {
                case 0:break;
                case 1: agents = agents.OrderBy(x => x.Title).ToList(); break;
                case 2: agents = agents.OrderByDescending(x => x.Title).ToList(); break;
            }

            if(cbFilter.SelectedIndex > 0)
            {
                string agentType = cbFilter.SelectedItem.ToString();
                agents = agents.Where(x => x.AgentType.Title == agentType).ToList();
            }

            lbAgents.ItemsSource = agents;
        }

        private void cbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FindAgents();
        }

        private void cbsort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FindAgents();

        }

        private void tbFind_TextChanged(object sender, TextChangedEventArgs e)
        {
            FindAgents();
        }

        private void btnAddAgent_Click(object sender, RoutedEventArgs e)
        {
            FrameObj.frameMain.Navigate(new PageAddAgent(new Agent()));
        }

        private void btnEditAgent_Click(object sender, RoutedEventArgs e)
        {
            var agents = (Agent)lbAgents.SelectedItem;
            FrameObj.frameMain.Navigate(new PageAddAgent(agents));
        }

        private void btnDelAgent_Click(object sender, RoutedEventArgs e)
        {
            var agents = (Agent)lbAgents.SelectedItem;
            if (MessageBox.Show("Удалить?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {

            DB.db.Agent.Remove(agents);
                DB.db.SaveChanges();
                lbAgents.ItemsSource = DB.db.Agent.ToList();
            }

        }
    }
}
