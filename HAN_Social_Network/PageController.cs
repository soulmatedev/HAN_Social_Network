using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN_Social_Network
{
    internal class PageController
    {
        private static Authorization authorization;
        public static Authorization Authorization

        {
            get
            {
                if (authorization == null)
                {
                    authorization = new Authorization();
                }
                return authorization;
            }
        }

        private static Registration registration;
        public static Registration Registration
        {
            get
            {
                if(registration== null)
                {
                    registration = new Registration();
                }
                return registration;
            }
        }

        private static int AccountId { get; set; }

        public static void SetAccount (int accountId)
        {
            AccountId = accountId;
        }
        private static ProfilePage profilePage;
        public static ProfilePage ProfilePage
        {
            get
            {
                if(profilePage == null) 
                {
                    profilePage = new ProfilePage(AccountId);
                }
                return profilePage;
            }
        }

        private static UserEdit userEdit;
        public static UserEdit UserEdit
        {
            get
            {
                if (userEdit == null)
                {
                    userEdit = new UserEdit();
                }
                return userEdit;
            }
        }

        private static CreatePostPage createPostPage;
        public static CreatePostPage CreatePostPage
        {
            get
            {
                if (createPostPage == null)
                {
                    createPostPage = new CreatePostPage(AccountId);
                }
                return createPostPage;
            }
        }

    }
}
