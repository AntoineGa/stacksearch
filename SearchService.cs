using System.Collections.Generic;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using System.Linq;
using System;

namespace stacksearch{
    
    public static class SearchService{
        static readonly SearchServiceClient client;
        static readonly SearchIndexClient indexClient;
        static SearchService()
        {
            client = new SearchServiceClient("azs-playground", new SearchCredentials("252044BE3886FE4A8E3BAA4F595114BB"));
            indexClient = client.Indexes.GetClient("stackexchange");
        }
        
        public static List<Entry> SearchDocuments(string searchText, string filter, string orderBy, int page = 1, int pageSize = 10)
        {
            
            var sp = new SearchParameters();

            if (!string.IsNullOrEmpty(filter))
            {
                sp.Filter = filter;
            }
            sp.Top = pageSize;
            sp.Skip = (page - 1) * pageSize;
            if (!string.IsNullOrEmpty(orderBy))
            {
                sp.OrderBy = orderBy.Split(',');
            }
            sp.IncludeTotalResultCount = true;
            var results = indexClient.Documents.Search(searchText, sp);
            return results.Select(x=>new Entry(){
                    AnswerCount = (long)x.Document["answerCount"],
                    CommentCount = (long)x.Document["commentCount"],
                    Title = (string)x.Document["title"],
                    Body = (string)x.Document["body"],
                    CreationDate = ((DateTimeOffset)x.Document["creationDate"]).DateTime,
                    LastActivityDate = ((DateTimeOffset)x.Document["lastActivityDate"]).DateTime,
            }).ToList();
        }
    }
}