using System;
using System.Collections.ObjectModel;

namespace MeusLivros.Model
{
    [Serializable]
    public class Livro : Notifier
    {
        private Guid _id = Guid.Empty;
        private string _imagePath;
        private string _editora;
        private ObservableCollection<Autor> _autor = new ObservableCollection<Autor>();
        private int _ano;
        private int _edicao;
        private string _titulo;
        private long _paginas;
        private long _lido;

        public Guid Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        public string ImagePath
        {
            get { return _imagePath; }
            set
            {
                _imagePath = value;
                OnPropertyChanged("ImagePath");
            }
        }

        public string Editora
        {
            get { return _editora; }
            set
            {
                _editora = value;
                OnPropertyChanged("Editora");
            }
        }

        public ObservableCollection<Autor> Autor
        {
            get { return _autor; }
            set
            {
                _autor = value;
                OnPropertyChanged("Autor");
            }
        }

        public int Ano
        {
            get { return _ano; }
            set
            {
                _ano = value;
                OnPropertyChanged("Ano");
            }
        }

        public int Edicao
        {
            get { return _edicao; }
            set
            {
                _edicao = value;
                OnPropertyChanged("Edicao");
            }
        }

        public string Titulo
        {
            get { return _titulo; }
            set
            {
                _titulo = value;
                OnPropertyChanged("Titulo");
            }
        }

        public long Paginas
        {
            get { return _paginas; }
            set
            {
                _paginas = value;
                OnPropertyChanged("Paginas");
                OnPropertyChanged("Porcentagem");
            }
        }

        public long Lido
        {
            get { return _lido; }
            set
            {
                _lido = value;
                OnPropertyChanged("Lido");
                OnPropertyChanged("Porcentagem");
            }
        }

        public long Porcentagem
        {
            get
            {
                if (Lido > 0 && Paginas > 0)
                {
                    double valor = (double)Lido / (double)Paginas * 100.0;
                    return (long)valor;
                }
                else
                    return 0;
            }
        }

        public string Autores
        {
            get
            {
                string result = string.Empty;

                foreach(Autor autor in Autor)
                {
                    result += autor + ", ";
                }

                return result;
            }
        }

        public override string ToString()
        {
            return Titulo;
        }

        public override bool Equals(object obj)
        {
            Livro other = obj as Livro;
            return other != null && other.Id == Id;
        }
    }
}
