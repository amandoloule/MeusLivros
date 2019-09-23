using System.Windows;
using System.Windows.Controls;
using MeusLivros.Presenters;
using Microsoft.Win32;

namespace MeusLivros.Views
{
    /// <summary>
    /// Interaction logic for EditLivroView.xaml
    /// </summary>
    public partial class EditLivroView : UserControl
    {
        public EditLivroView()
        {
            InitializeComponent();
        }

        public EditLivroPresenter Presenter
        {
            get { return DataContext as EditLivroPresenter; }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Presenter.Save();
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Presenter.Delete();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Presenter.Close();
        }

        private void SelectImage_Click(object sender, RoutedEventArgs e)
        {
            Presenter.SelectImage();
        }

        public string AskUserForImagePath()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.ShowDialog();
            return dlg.FileName;
        }

        private void AddAuthor_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(novoAutor.Text))
                Presenter.AddAuthor(novoAutor.Text);
        }

        private void ParaDireita_Click(object sender, RoutedEventArgs e)
        {
            if (cadastrados.SelectedItem != null)
                Presenter.AddAuthor(cadastrados.SelectedItem.ToString());
        }

        private void Remover_Click(object sender, RoutedEventArgs e)
        {
            if (aCadastrar.SelectedItem != null)
                Presenter.RemoveAuthor(aCadastrar.SelectedItem);
        }
    }
}
