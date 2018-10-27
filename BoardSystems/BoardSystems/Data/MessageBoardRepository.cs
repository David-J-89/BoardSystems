using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoardSystems.Data
{
    public class MessageBoardRepository : IMessageBoardRepository //this class implements the IMessageBoardRepository Interface.
    {
        public IQueryable<Reply> GetRepliesByTopic(int topicId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Topic> GetTopics()
        {
            throw new NotImplementedException();
        }
    }
}