using SerfClub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SerfClub.DAL
{
    public class DataContextInitializer
    {
        public static void Initialize(DataContext context)
        {
            if (!context.Users.Any())
            {
                context.Users.Add(new Models.User()
                {
                    Nickname = "system",
                    Email = "qwe@qwe.ru",
                    Password = "qwe",
                    LastName = "Разработчик",
                    FirstName = "Системы"
                });
                context.SaveChanges();
            }

            if (!context.News.Any())
            {
                context.News.AddRange(new List<News>()
                {
                    new News()
                    {
                        AuthorId = 1,
                        Text = "Мой первый пост",
                        CreateDate = DateTime.Now.AddMonths(-13)
                    },
                    new News()
                    {
                        AuthorId = 1,
                        Text = "Всех с новым годом!",
                        CreateDate = new DateTime(2020, 12, 31, 11, 58, 00)
                    },
                    new News()
                    {
                        AuthorId = 1,
                        Text = "Вернулся",
                        CreateDate = DateTime.Now
                    }
                });
                context.SaveChanges();
            }
        }
    }
}
