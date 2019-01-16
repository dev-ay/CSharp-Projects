namespace ScheduleIt2.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using ScheduleIt2.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ScheduleIt2.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            // Seed the User table with test data
            var store = new UserStore<ApplicationUser>(context);
            var manager = new UserManager<ApplicationUser>(store);
            var user = new ApplicationUser() { UserName = "Ryan@FakeEmail.com", Email = "Ryan@FakeEmail.com", EmailConfirmed = true };

            if (!context.Users.Any(u => u.UserName == "Ryan@FakeEmail.com"))
            {
                manager.Create(user, "AVeryBadPassword");
                user = new ApplicationUser() { UserName = "John@FakeEmail.com", Email = "John@FakeEmail.com", EmailConfirmed = true };
                manager.Create(user, "SimplePassword");
                user = new ApplicationUser() { UserName = "Maricella@FakeEmail.com", Email = "Maricella@FakeEmail.com", EmailConfirmed = true };
                manager.Create(user, "EasilyGuessed");
                user = new ApplicationUser() { UserName = "Florence@FakeEmail.com", Email = "Florence@FakeEmail.com", EmailConfirmed = true };
                manager.Create(user, "123456");
                user = new ApplicationUser() { UserName = "Matt@FakeEmail.com", Email = "Matt@FakeEmail.com", EmailConfirmed = true };
                manager.Create(user, "abc123");
            }

            // Seed the roles table with test data
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var roleNames = new List<string>() { "Admin", "User" };
            if (!roleManager.RoleExists(roleNames[0]) && !roleManager.RoleExists(roleNames[1]))
            {
                roleManager.Create(new IdentityRole(roleNames[0]));
                roleManager.Create(new IdentityRole(roleNames[1]));
            }

            //create admin user and assign to admin role
            if (!context.Users.Any(u => u.UserName == "admin@FakeEmail.com"))
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                user = new ApplicationUser() { UserName = "admin@FakeEmail.com", Email = "admin@FakeEmail.com", EmailConfirmed = true };
                manager.Create(user, "Admin1234");
                userManager.AddToRole(user.Id, "Admin");
            }


            //Add 3 more admin users
            if (!context.Users.Any(u => u.UserName == "admin1@FakeEmail.com"))
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                for (int i = 1; i <= 3; i++)
                {
                    user = new ApplicationUser()
                    {
                        UserName = String.Format("admin{0}@FakeEmail.com", i),
                        Email = String.Format("admin{0}@FakeEmail.com", i),
                        EmailConfirmed = true
                    };
                    manager.Create(user, "Admin1234");
                    userManager.AddToRole(user.Id, "Admin");
                }

            }



            // Seed the Event table with test data
            if (!context.Events.Any(e => e.Title == "Vacation"))
            {
                var eventList = new List<Event>();
                eventList.Add(new Models.TimeOffEvent()
                {
                    EventID = Guid.NewGuid(),
                    ActiveSchedule = true,
                    ApproverId = "TA",
                    Id = "121807f1-2765-4c64-847f-5532da481a33",
                    Start = new DateTime(2019, 1, 2),
                    End = new DateTime(2019, 1, 7),
                    Title = "Vacation",
                    Note = "They will be using their PTO to take time off to go on vacation.",
                    Submitted = new DateTime(2018, 12, 20)
                });
                eventList.Add(new Models.TimeOffEvent()
                {
                    EventID = Guid.NewGuid(),
                    ActiveSchedule = true,
                    ApproverId = "BS",
                    Id = "3dd192e8-4fb0-4fd0-8b85-8ec75d9d2cd4",
                    Start = new DateTime(2019, 1, 3),
                    End = new DateTime(2019, 1, 4),
                    Title = "Vacation",
                    Note = "They will be using their PTO to extend their New Year's Holiday",
                    Submitted = new DateTime(2018, 12, 20)
                });

                eventList.Add(new Models.TimeOffEvent()
                {
                    EventID = Guid.NewGuid(),
                    ActiveSchedule = true,
                    ApproverId = "TA",
                    Id = "76bf9a0e-c206-43b0-ac8e-071e5f26f2ad",
                    Start = new DateTime(2019, 1, 4),
                    End = new DateTime(2019, 1, 4),
                    Title = "Illness",
                    Note = "They called in sick today.",
                    Submitted = new DateTime(2019, 1, 4)
                });
                eventList.Add(new Models.TimeOffEvent()
                {
                    EventID = Guid.NewGuid(),
                    ActiveSchedule = true,
                    ApproverId = "BS",
                    Id = "ad1e0fc8-16b9-45da-b20f-c7c8ed8cfb7e",
                    Start = new DateTime(2019, 1, 2),
                    End = new DateTime(2019, 3, 1),
                    Title = "Parental Leave",
                    Note = "They are having a baby and will be taking parental leave before/after the birth of the baby.",
                    Submitted = new DateTime(2018, 6, 10)
                });
                eventList.Add(new Models.TimeOffEvent()
                {
                    EventID = Guid.NewGuid(),
                    ActiveSchedule = true,
                    ApproverId = "TA",
                    Id = "d5a3a91b-3104-4f9b-8997-27cf0cd29694",
                    Start = new DateTime(2019, 1, 8),
                    End = new DateTime(2019, 1, 8),
                    Title = "Illness",
                    Note = "They called in sick today.",
                    Submitted = new DateTime(2018, 1, 8)
                });
                eventList.Add(new Models.TimeOffEvent()
                {
                    EventID = Guid.NewGuid(),
                    ActiveSchedule = true,
                    ApproverId = "BS",
                    Id = "d95bb33b-cd21-4273-a634-5873a40efc2b",
                    Start = new DateTime(2019, 6, 7),
                    End = new DateTime(2019, 8, 30),
                    Title = "Parental Leave",
                    Note = "They are having a baby and will be taking parental leave before/after the birth of the baby.",
                    Submitted = null
                });
                eventList.Add(new Models.WorkTimeEvent()
                {
                    EventID = Guid.NewGuid(),
                    ActiveSchedule = true,
                    ApproverId = "TA",
                    Id = "121807f1-2765-4c64-847f-5532da481a33",
                    Start = new DateTime(2019, 1, 3, 9, 0, 0),
                    End = new DateTime(2019, 1, 3, 18, 0, 0),
                    Title = "Clocked In",
                    Note = "They clocked in at work.",
                    ClockFunctionStatus = ClockFunctionStatus.ClockInSuccess
                });
                eventList.Add(new Models.WorkTimeEvent()
                {
                    EventID = Guid.NewGuid(),
                    ActiveSchedule = true,
                    ApproverId = "BS",
                    Id = "3dd192e8-4fb0-4fd0-8b85-8ec75d9d2cd4",
                    Start = new DateTime(2019, 1, 3, 9, 0, 0),
                    End = new DateTime(2019, 1, 3, 19, 0, 0),
                    Title = "Clocked In",
                    Note = "They clocked in at work.",
                    ClockFunctionStatus = ClockFunctionStatus.ClockInSuccess
                });
                eventList.Add(new Models.WorkTimeEvent()
                {
                    EventID = Guid.NewGuid(),
                    ActiveSchedule = true,
                    ApproverId = "TA",
                    Id = "76bf9a0e-c206-43b0-ac8e-071e5f26f2ad",
                    Start = new DateTime(2019, 1, 3, 9, 15, 0),
                    End = new DateTime(2019, 1, 3, 18, 15, 0),
                    Title = "Clocked In",
                    Note = "They clocked in at work.",
                    ClockFunctionStatus = ClockFunctionStatus.ClockInSuccess
                });
                eventList.Add(new Models.WorkTimeEvent()
                {
                    EventID = Guid.NewGuid(),
                    ActiveSchedule = true,
                    ApproverId = "BS",
                    Id = "ad1e0fc8-16b9-45da-b20f-c7c8ed8cfb7e",
                    Start = new DateTime(2019, 1, 3, 9, 0, 0),
                    End = new DateTime(2019, 1, 3, 17, 0, 0),
                    Title = "Clocked In",
                    Note = "They clocked in at work.",
                    ClockFunctionStatus = ClockFunctionStatus.ClockInSuccess
                });

                context.Events.AddRange(eventList);
            }

            if (!context.Messages.Any(e => e.Sender == context.Users.Where(u => u.UserName == "Ryan@FakeEmail.com").FirstOrDefault()))
            {
                var messages = new List<Message>();
                messages.Add(new Message()
                {
                    MessageID = Guid.NewGuid(),
                    DateSent = new DateTime(2018, 12, 1, 13, 30, 0),
                    DateRead = new DateTime(2018, 12, 1, 14, 30, 0),
                    MessageTitle = "Important Message",
                    Content = "Thank you for reading this important message!",
                    //UnreadMessage = false,
                    Sender = context.Users.Where(u => u.UserName == "Ryan@FakeEmail.com").FirstOrDefault(),
                    Recipient = context.Users.Where(u => u.UserName == "John@FakeEmail.com").FirstOrDefault(),
                    EventID = null
                });
                messages.Add(new Message()
                {
                    MessageID = Guid.NewGuid(),
                    DateSent = new DateTime(2018, 12, 1, 15, 45, 0),
                    DateRead = null,
                    MessageTitle = "Saying Hello",
                    Content = "How are you doing today?",
                    Sender = context.Users.Where(u => u.UserName == "John@FakeEmail.com").FirstOrDefault(),
                    Recipient = context.Users.Where(u => u.UserName == "Ryan@FakeEmail.com").FirstOrDefault(),
                    EventID = null
                });
                messages.Add(new Message()
                {
                    MessageID = Guid.NewGuid(),
                    DateSent = new DateTime(2018, 12, 2, 11, 30, 0),
                    DateRead = new DateTime(2018, 12, 2, 11, 40, 0),
                    MessageTitle = "Lunch Plans",
                    Content = "What do you want to grab for lunch?",
                    Sender = context.Users.Where(u => u.UserName == "Ryan@FakeEmail.com").FirstOrDefault(),
                    Recipient = context.Users.Where(u => u.UserName == "John@FakeEmail.com").FirstOrDefault(),
                    EventID = null
                });
                messages.Add(new Message()
                {
                    MessageID = Guid.NewGuid(),
                    DateSent = new DateTime(2018, 12, 2, 11, 45, 0),
                    DateRead = null,
                    MessageTitle = "Re: Lunch Plans",
                    Content = "Do you want to go to Chipotle?",
                    Sender = context.Users.Where(u => u.UserName == "John@FakeEmail.com").FirstOrDefault(),
                    Recipient = context.Users.Where(u => u.UserName == "Ryan@FakeEmail.com").FirstOrDefault(),
                    EventID = null
                });
                messages.Add(new Message()
                {
                    MessageID = Guid.NewGuid(),
                    DateSent = new DateTime(2018, 12, 1, 13, 30, 0),
                    DateRead = new DateTime(2018, 12, 1, 13, 45, 0),
                    MessageTitle = "New Feature",
                    Content = "I've added a new feature to our program.",
                    Sender = context.Users.Where(u => u.UserName == "Maricella@FakeEmail.com").FirstOrDefault(),
                    Recipient = context.Users.Where(u => u.UserName == "Florence@FakeEmail.com").FirstOrDefault(),
                    EventID = null
                });
                messages.Add(new Message()
                {
                    MessageID = Guid.NewGuid(),
                    DateSent = new DateTime(2018, 12, 1, 13, 30, 0),
                    DateRead = new DateTime(2018, 12, 1, 14, 50, 0),
                    MessageTitle = "New Feature",
                    Content = "I've added a new feature to our program.",
                    Sender = context.Users.Where(u => u.UserName == "Maricella@FakeEmail.com").FirstOrDefault(),
                    Recipient = context.Users.Where(u => u.UserName == "Matt@FakeEmail.com").FirstOrDefault(),
                    EventID = null
                });
                messages.Add(new Message()
                {
                    MessageID = Guid.NewGuid(),
                    DateSent = new DateTime(2018, 12, 1, 14, 30, 0),
                    DateRead = null,
                    MessageTitle = "Re: New Feature",
                    Content = "That is such a cool feature!",
                    Sender = context.Users.Where(u => u.UserName == "Florence@FakeEmail.com").FirstOrDefault(),
                    Recipient = context.Users.Where(u => u.UserName == "Maricella@FakeEmail.com").FirstOrDefault(),
                    EventID = null
                });
                messages.Add(new Message()
                {
                    MessageID = Guid.NewGuid(),
                    DateSent = new DateTime(2018, 12, 2, 13, 30, 0),
                    DateRead = null,
                    MessageTitle = "Funny Video",
                    Content = "Look at this funny video I found!",
                    Sender = context.Users.Where(u => u.UserName == "Florence@FakeEmail.com").FirstOrDefault(),
                    Recipient = context.Users.Where(u => u.UserName == "Matt@FakeEmail.com").FirstOrDefault(),
                    EventID = null
                });
                messages.Add(new Message()
                {
                    MessageID = Guid.NewGuid(),
                    DateSent = new DateTime(2018, 12, 2, 14, 30, 0),
                    DateRead = null,
                    MessageTitle = "Re: Funny Video",
                    Content = "I can't get the video to play :(",
                    Sender = context.Users.Where(u => u.UserName == "Matt@FakeEmail.com").FirstOrDefault(),
                    Recipient = context.Users.Where(u => u.UserName == "Florence@FakeEmail.com").FirstOrDefault(),
                    EventID = null
                });
                messages.Add(new Message()
                {
                    MessageID = Guid.NewGuid(),
                    DateSent = new DateTime(2018, 12, 3, 9, 0, 0),
                    DateRead = null,
                    MessageTitle = "Tasks for Today",
                    Content = "Good Morning! The tasks for the day have been posted on the Azure Dev Ops site. Have fun!",
                    Sender = context.Users.Where(u => u.UserName == "Matt@FakeEmail.com").FirstOrDefault(),
                    Recipient = context.Users.Where(u => u.UserName == "Maricella@FakeEmail.com").FirstOrDefault(),
                    EventID = null
                });

                context.Messages.AddRange(messages);
            }
            context.SaveChanges();
        }
    }
}
