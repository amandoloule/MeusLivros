using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace MeusLivros.Model
{
    public class LivroRepository
    {
        private List<Livro> _livroStore;
        private readonly string _stateFile;

        public LivroRepository()
        {
            _stateFile = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "MeusLivros.state"
                );

            Deserialize();
        }

        public void Save (Livro livro)
        {
            if (livro.Id == Guid.Empty)
                livro.Id = Guid.NewGuid();

            if (!_livroStore.Contains(livro))
                _livroStore.Add(livro);

            Serialize();
        }

        public void Delete(Livro livro)
        {
            _livroStore.Remove(livro);
            Serialize();
        }

        public List<Livro> FindByTitle(string title)
        {
            IEnumerable<Livro> found =
                from l in _livroStore
                where l.Titulo.ToLower().Contains(title.ToLower())
                select l;

            return found.ToList();
        }

        public List<Livro> FindByAuthor(string author)
        {
            IEnumerable<Livro> found =
                from l in _livroStore
                from a in l.Autor
                where a.Nome.Contains(author)
                select l;

            return found.ToList();
        }

        public List<Livro> FindAll()
        {
            return new List<Livro>(_livroStore);
        }

        public List<Autor> FindAllAuthors()
        {
            IEnumerable<Autor> found =
                from l in _livroStore
                from a in l.Autor
                select a;

            return found.Distinct().ToList();
        }

        private void Serialize()
        {
            using (FileStream stream =
                File.Open(_stateFile, FileMode.OpenOrCreate))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, _livroStore);
            }
        }

        private void Deserialize()
        {
            if (File.Exists(_stateFile))
            {
                using (FileStream stream =
                    File.Open(_stateFile, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();

                    _livroStore =
                        (List<Livro>)formatter.Deserialize(stream);
                }
            }
            else _livroStore = new List<Livro>();
        }
    }
}
