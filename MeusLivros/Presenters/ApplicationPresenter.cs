using System;
using System.Collections.ObjectModel;
using MeusLivros.Model;
using MeusLivros.Views;

namespace MeusLivros.Presenters
{
    public class ApplicationPresenter : PresenterBase<Shell>
    {
        private readonly LivroRepository _livroRepository;
        private ObservableCollection<Livro> _currentLivros;
        private ObservableCollection<Autor> _currentAutores;
        private string _statusText;

        public ApplicationPresenter(
            Shell view,
            LivroRepository livroRepository)
            : base(view)
        {
            _livroRepository = livroRepository;

            _currentLivros = new ObservableCollection<Livro>(
                _livroRepository.FindAll()
                );
            _currentAutores = new ObservableCollection<Autor>(
                _livroRepository.FindAllAuthors()
                );
        }

        public ObservableCollection<Livro> CurrentLivros
        {
            get { return _currentLivros; }
            set
            {
                _currentLivros = value;
                OnPropertyChanged("CurrentLivros");
                OnPropertyChanged("CurrentAutores");
            }
        }

        public ObservableCollection<Autor> CurrentAutores
        {
            get { return _currentAutores; }
            set
            {
                _currentAutores = value;
                OnPropertyChanged("CurrentAutores");
            }
        }

        public string StatusText
        {
            get { return _statusText; }
            set
            {
                _statusText = value;
                OnPropertyChanged("StatusText");
            }
        }

        public void Search(string criteria, string type = "title")
        {
            if (!string.IsNullOrEmpty(criteria) && criteria.Length > 2)
            {
                CurrentLivros = type == "title" ?
                    new ObservableCollection<Livro>(_livroRepository.FindByTitle(criteria))
                    : new ObservableCollection<Livro>(_livroRepository.FindByAuthor(criteria));

                StatusText = string.Format(
                    "{0} livros encontrados",
                    CurrentLivros.Count
                    );
            }
            else
            {
                CurrentLivros = new ObservableCollection<Livro>(
                    _livroRepository.FindAll()
                    );

                StatusText = "Mostrando todos os livros.";
            }
        }

        public void NewLivro()
        {
            OpenLivro(new Livro());
        }

        public void SaveLivro(Livro livro)
        {
            if (!CurrentLivros.Contains(livro))
                CurrentLivros.Add(livro);

            _livroRepository.Save(livro);
            _currentAutores = new ObservableCollection<Autor>(
               _livroRepository.FindAllAuthors()
               );

            StatusText = string.Format(
                "Livro '{0}' foi salvo.",
                livro.Titulo
                );
        }

        public void DeleteLivro(Livro livro)
        {
            if (CurrentLivros.Contains(livro))
                CurrentLivros.Remove(livro);

            _livroRepository.Delete(livro);

            StatusText = string.Format(
                "Livro '{0}' foi excluído.",
                livro.Titulo
                );
        }

        public void CloseTab<T>(PresenterBase<T> presenter)
        {
            View.RemoveTab(presenter);
        }

        public void OpenLivro(Livro livro)
        {
            if (livro == null) return;

            View.AddTab(
                new EditLivroPresenter(
                    this,
                    new EditLivroView(),
                    livro
                    )
                );
        }

        public void DisplayAllLivros()
        {
            View.AddTab(
                new LivroListPresenter(
                    this,
                    new LivroListView()
                    )
                );
        }
    }
}
