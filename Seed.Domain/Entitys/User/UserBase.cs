using Common.Domain.Base;
using Common.Domain.Model;
using System;

namespace Seed.Domain.Entitys
{
    public class UserBase : DomainBaseWithUserCreate
    {
        public UserBase()
        {

        }

		public UserBase(int userid, int statususerid, int typeuserid, string login, string password) 
        {
            this.UserId = userid;
            this.StatusUserId = statususerid;
            this.TypeUserId = typeuserid;
            this.Login = login;
            this.Password = password;

        }


		public class UserFactoryBase
        {
            public virtual User GetDefaultInstanceBase(dynamic data, CurrentUser user)
            {
                var construction = new User(data.UserId,
                                        data.StatusUserId,
                                        data.TypeUserId,
                                        data.Login,
                                        data.Password);



				construction.SetConfirmBehavior(data.ConfirmBehavior);
				construction.SetAttributeBehavior(data.AttributeBehavior);
        		return construction;
            }

        }

        public virtual int UserId { get; protected set; }
        public virtual int StatusUserId { get; protected set; }
        public virtual int TypeUserId { get; protected set; }
        public virtual string Login { get; protected set; }
        public virtual string Password { get; protected set; }



    }
}
