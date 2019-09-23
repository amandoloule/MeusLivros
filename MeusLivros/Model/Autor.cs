using System;

namespace MeusLivros.Model
{
    [Serializable]
    public class Autor : Notifier
    {
        private string _nome;

        public string Nome
        {
            get { return _nome; }
            set
            {
                _nome = value;
                OnPropertyChanged("Nome");
            }
        }

        public override string ToString()
        {
            return Nome;
        }

        public override bool Equals(object obj)
        {
            Autor other = obj as Autor;
            return other != null && string.Equals(other.Nome, Nome);
        }

        public override int GetHashCode()
        {
            int hashNome = Nome == null ? 0 : Nome.GetHashCode();

            return hashNome;
        }
    }
}
