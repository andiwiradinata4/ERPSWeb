﻿namespace ERPS.Infrastructure.Utilities.Interface
{
    public interface IMessageObject
    {
        List<Message> Errors { get; }

        List<Message> Warnings { get; }

        List<Message> Confirmations { get; }

        List<Message> Informations { get; }

        Exception Exception { get; }

        bool ProcessingStatus { get; }

        void AddException(Exception ex);

        void AddMessage(Message msg);

        void AddMessage(MessageType type, string code, string desc, string field = "");

        void AddMessage(IMessageObject msg);

        void AddMessage(List<IMessageObject> msgList);

        bool HasError();
    }
}
