using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardSystems.Data
{
    interface IMessageBoardRepository
    {
       IQueryable<Topic> GetTopics();
       IQueryable<Reply> GetRepliesByTopic(int topicId);
    }
}
