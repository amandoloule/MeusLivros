using MeusLivros.Model;
using MeusLivros.Views;
using System.Collections.ObjectModel;

namespace MeusLivros.Presenters
{
    public class LivroListPresenter : PresenterBase<LivroListView>
    {
        private readonly ApplicationPresenter _applicationPresenter;

        public LivroListPresenter(
            ApplicationPresenter applicationPresenter,
            LivroListView view)
            : base(view, "TabHeader")
        {
            _applicationPresenter = applicationPresenter;
        }

        public string TabHeader
        {
            get { return "Todos os Livros"; }
        }

        public ObservableCollection<Livro> AllLivros
        {
            get { return _applicationPresenter.CurrentLivros; }
        }

        public void OpenLivro(Livro livro)
        {
            _applicationPresenter.OpenLivro(livro);
        }

        public void Close()
        {
            _applicationPresenter.CloseTab(this);
        }

        public override bool Equals(object obj)
        {
            return obj != null && GetType() == obj.GetType();
        }
    }
}
