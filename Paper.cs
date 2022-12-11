using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newLab2
{
    class Paper
    {
        public string _Publication { get; set; }
        public Person _Author { get; set; }
        public DateTime _TimeOfPublication { get; set; }

        public Paper(string Publication, Person Author, DateTime PublicationDate)
        {
            _Publication = Publication;
            _Author = Author;
            _TimeOfPublication = PublicationDate;
        }
        public Paper() : this("Publication1", new Person(), new DateTime(2000, 01, 02)) { }

        public override string ToString()
        {
            return string.Format(_Publication, " ", _Author.ToString(), " ", _TimeOfPublication.ToString());
        }

        public virtual object DeepCopy()
        {
            Paper PaperCopy = new Paper(this._Publication, this._Author, this._TimeOfPublication);
            return PaperCopy;
        }

    }
}
