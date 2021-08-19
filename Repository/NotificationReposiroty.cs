/* using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using OrigamiEdu.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;
using OrigamiEdu.Services;

namespace OrigamiEdu.Repository
{
    public class NotificationRepository
    {
        private readonly Context context;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly httpServices httpSvc;

        public NotificationRepository(Context context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, httpServices httpSvc)
        {
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.httpSvc = httpSvc;
        }

        #nullable enable
        public async void addNotificationPersonalAsync(int type,  string recepientUname, string? info, string link)
        {
            // Type [1] - Like
            // Type [2] - Commented
            // Type [3] - Severe
            // Type [4] - Info
            if(type == 1)
            {
                
                var like = await (from n in context.notifications
                                  join u in userManager.Users on n.user.Id equals u.Id
                                  where n.user.UserName == recepientUname &&
                                  n.type == "like" &&
                                  n.link == link
                                  select new notification{
                                      user = u,
                                      unameInvolved = n.unameInvolved,
                                      timestamp = n.timestamp,
                                      isSeen = false
                                  }).FirstOrDefaultAsync();

                var unameInvolvedToList = like.unameInvolved.ToList();

                if(unameInvolvedToList.Contains(httpSvc.getSignedInUsername())){
                    unameInvolvedToList.Remove(httpSvc.getSignedInUsername());
                }

                unameInvolvedToList.Insert(0, httpSvc.getSignedInUsername());
                like.unameInvolved = unameInvolvedToList.ToArray();

                like.timestamp = DateTime.Now;
                context.Update(like);
                await context.SaveChangesAsync();
            }else if(type == 2)
            {
                var comment = await (from n in context.notifications
                                  join u in userManager.Users on n.user.Id equals u.Id
                                  where n.user.UserName == recepientUname &&
                                  n.type == "comment" &&
                                  n.link == link
                                  select new notification{
                                      user = u,
                                      unameInvolved = n.unameInvolved,
                                      timestamp = n.timestamp,
                                      isSeen = false
                                  }).FirstOrDefaultAsync();

                var unameInvolvedToList = comment.unameInvolved.ToList();
                if(unameInvolvedToList.Contains(sender)){
                    unameInvolvedToList.Remove(sender);
                    unameInvolvedToList.Insert(0, sender);
                    comment.unameInvolved = unameInvolvedToList.ToArray();
                }
                comment.timestamp = DateTime.Now;
                context.Update(comment);
                await context.SaveChangesAsync();
            }
        }
    }
} */