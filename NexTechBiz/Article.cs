using System;

namespace NexTechCore
{
    public class Article
    {
        string _title;
        string _by;
        string _url;

        public string Title
        {
            get
            {
                return _title ?? "";
            }
            set
            {
                _title = value;
            }
        }
        public string By
        {
            get
            {
                return _by ?? "";
            }
            set
            {
                _by = value;
            }
        }
        public string Url
        {
            get
            {
                return _url ?? "";
            }
            set
            {
                _url = value;
            }
        }

        public override string ToString()
        {
            return Title + " " + By + " " + Url;
        }
    }
}
