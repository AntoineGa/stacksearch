using System.Collections.Generic;
using System.Linq;
using System;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace stacksearch{
    
    public class SimpleSearchPayload
    {
        public SimpleSearchPayload(){
            Facets = new List<string>();
            Filter = string.Empty;
            Count=false;
            Search=string.Empty;
        }
        [JsonPropertyAttribute("count")]
        public bool Count { get; set; }
        [JsonPropertyAttribute("facets")]
        public List<string> Facets { get; set; }
        
        [JsonPropertyAttribute("filter")]
        public string Filter { get; set; }
        [JsonPropertyAttribute("search")]
        public string Search { get; set; }
    }
    
    
    public class SimpleSearchResponse{
        
        [JsonPropertyAttribute("value")]
        public List<JObject> Value{get;set;}
    }
    
    
    public static class SearchService{
        private readonly static string ServiceUrl = "https://azs-playground.search.windows.net/indexes/stackexchange/docs/search?api-version=2015-02-28";
       
        public static List<Entry> SearchDocuments(string searchText, string filter, string orderBy, int page = 1, int pageSize = 10)
        {
                
            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/json";
                wc.Headers[HttpRequestHeader.Accept] = "application/json";
                wc.Headers["api-key"] = "252044BE3886FE4A8E3BAA4F595114BB";
                var payload= new SimpleSearchPayload();
                payload.Count=true;
                payload.Search = searchText;
                string response = wc.UploadString(ServiceUrl, JsonConvert.SerializeObject(payload));
                var results = JsonConvert.DeserializeObject<SimpleSearchResponse>(response);
                return results.Value.Select(x=>new Entry(){
                    AnswerCount = (long)x["answerCount"],
                    CommentCount = (long)x["commentCount"],
                    Title = (string)x["title"],
                    Body = (string)x["body"],
                    CreationDate = ((DateTimeOffset)x["creationDate"]).DateTime,
                    LastActivityDate = ((DateTimeOffset)x["lastActivityDate"]).DateTime,
            }).ToList();
            }
        }
    }
}