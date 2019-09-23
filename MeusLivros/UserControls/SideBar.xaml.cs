using System.Windows;
using System.Windows.Controls;
using MeusLivros.Model;
using MeusLivros.Presenters;

namespace MeusLivros.UserControls
{
    /// <summary>
    /// Interaction logic for SideBar.xaml
    /// </summary>
    public partial class SideBar : UserControl
    {
        public SideBar()
        {
            InitializeComponent();
        }

        public ApplicationPresenter Presenter
        {
            get { return DataContext as ApplicationPresenter; }
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            Presenter.NewLivro();
        }

        private void ViewAll_Click(object sender, RoutedEventArgs e)
        {
            Presenter.DisplayAllLivros();
        }

        private void OpenLivro_Click(object sender, RoutedEventArgs e)
        {
            Button button = e.OriginalSource as Button;

            if (button != null)
                Presenter.OpenLivro(button.DataContext as Livro);
        }
    }
}
