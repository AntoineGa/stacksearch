using System;

namespace stacksearch{
    public class Entry{
        public long AnswerCount { get; set; }
        
        public string Body { get; set; }
        
        public long CommentCount { get; set; }
        
        public string Title { get; set; }
        
        public DateTime CreationDate { get; set; }
        
        public DateTime LastActivityDate { get; set; }
    }
    
}