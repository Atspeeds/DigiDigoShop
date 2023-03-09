using System;

namespace BlogManagement.Application.Contract.Article
{
    public class SearchArticle
    {
        public string Title { get; set; }
        public string DateRelease { get; set; }
        public long CategoryId { get; set; }
    }
}
