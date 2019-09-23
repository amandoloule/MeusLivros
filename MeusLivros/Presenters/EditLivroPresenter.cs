using MeusLivros.Model;
using MeusLivros.Views;
using System.Collections.ObjectModel;

namespace MeusLivros.Presenters
{
    public class EditLivroPresenter : PresenterBase<EditLivroView>
    {
        private readonly ApplicationPresenter _applicationPresenter;
        private readonly Livro _livro;

        public EditLivroPresenter(
            ApplicationPresenter applicationPresenter,
            EditLivroView view,
            Livro livro)
            : base(view, "Livro.Titulo")
        {
            _applicationPresenter = applicationPresenter;
            _livro = livro;
        }

        public Livro Livro
        {
            get { return _livro; }
        }

        public ObservableCollection<Autor> JaCadastrados
        {
            get { return _applicationPresenter.CurrentAutores; }
        }

        public void SelectImage()
        {
            string imagePath = View.AskUserForImagePath();
            if (!string.IsNullOrEmpty(imagePath))
                Livro.ImagePath = imagePath;
        }

        public void AddAuthor(string novoAutor)
        {
            Livro.Autor.Add(new Autor { Nome = novoAutor });
        }

        public void RemoveAuthor(object autor)
        {
            Livro.Autor.Remove(autor as Autor);
        }

        public void Save()
        {
            _applicationPresenter.SaveLivro(Livro);
        }

        public void Delete()
        {
            _applicationPresenter.CloseTab(this);
            _applicationPresenter.DeleteLivro(Livro);
        }

        public void Close()
        {
            _applicationPresenter.CloseTab(this);
        }

        public override bool Equals(object obj)
        {
            EditLivroPresenter presenter = obj as EditLivroPresenter;
            return presenter != null && presenter.Livro.Equals(Livro);
        }
    }
}
