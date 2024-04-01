using BookApplication.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Data;
using System.Drawing;

namespace BookApplication.Services
{
    public class Observer : IObserver
    {
        private readonly string _email;
        public Observer(string email)
        {
            _email = email;
        }
        public void OnNotify(Comment comment)
        {
            SendEmail(comment);
        }
        public void SendEmail(Comment comment)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Sending Email!");
            Console.WriteLine("To: " + _email);
            Console.WriteLine("Body: New comment \" " + comment.CommentText + "\" has been added By: " + comment.Author);
            Console.ResetColor();

        }
    }

}