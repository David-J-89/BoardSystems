using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoardSystems.Data
{
    public class MessageBoardRepository : IMessageBoardRepository //this class implements the IMessageBoardRepository Interface.
    {
        MessageBoardContext _ctx;
        public MessageBoardRepository(MessageBoardContext ctx)
        {
            _ctx = new MessageBoardContext();
        }
        public IQueryable<Topic> GetTopics()
        {
                
            return _ctx.Topics;
        }

        public IQueryable<Reply> GetRepliesByTopic(int topicId)
        {
            return _ctx.Replies.Where(r => r.TopicId == topicId);
        }
        
    }
}