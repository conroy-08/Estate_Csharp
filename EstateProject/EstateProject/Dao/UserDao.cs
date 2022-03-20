using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EstateProject.Common;
using EstateProject.Models;

namespace EstateProject.Dao
{


    public class UserDao
    {
        EstateDbContext dbContext = null;
        public UserDao()
        {
            dbContext = new EstateDbContext();
        }

        public long Insert(user entity)
        {
            dbContext.users.Add(entity);
            dbContext.SaveChanges();

            return entity.id;
        }
        public void Update(user entity, string newPassword)
        {
            //dbContext.users.Update(entity);
            entity.password = Encrytor.MD5Hash(newPassword);
            dbContext.SaveChanges();
        }

        public void UpdateProfile(user entity, string fullname,string email,string phone, string path)
        {
            //dbContext.users.Update(entity);
            entity.fullname = fullname;
            entity.email = email;
            entity.phone = phone;
            if(path != "")
            {
                entity.image = path;
            }
            
          
            dbContext.SaveChanges();
        }

        public user GetById(String userName)
        {
            return dbContext.users.SingleOrDefault(x => x.username == userName);
        }

        public int login(String userName, String passWord)
        {
            var result = dbContext.users.SingleOrDefault(x => x.username == userName );
            if (result == null)
            {
                return 0;
            }
            else
            {
               if(result.status == 0)
                {
                    return -1;
                }
                else
                {
                    if(result.password == passWord)
                    {
                        return 1;
                    }
                    else
                    {
                        return -2;
                    }
                }
            }

        }

    }
}