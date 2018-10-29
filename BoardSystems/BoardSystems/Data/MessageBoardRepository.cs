﻿using System;
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

        public bool Save()
        {
            try
            {
                return _ctx.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                //TODO log this error
                return false;
            }
        }

        public bool AddTopic(Topic newTopic)
        {
            try
            {
                _ctx.Topics.Add(newTopic);
                return true;
            }
            catch (Exception ex)
            {
                //TODO log this error
                return false;
            }
        }
    }
}