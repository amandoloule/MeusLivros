using System.Windows;
using System.Windows.Controls;
using MeusLivros.Model;
using MeusLivros.Presenters;

namespace MeusLivros.Views
{
    /// <summary>
    /// Interaction logic for LivroListView.xaml
    /// </summary>
    public partial class LivroListView : UserControl
    {
        public LivroListView()
        {
            InitializeComponent();
        }

        public LivroListPresenter Presenter
        {
            get { return DataContext as LivroListPresenter; }
        }

        private void OpenLivro_Click(object sender, RoutedEventArgs e)
        {
            Button button = e.OriginalSource as Button;

            if (button != null)
                Presenter.OpenLivro(button.DataContext as Livro);
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Presenter.Close();
        }
    }
}
