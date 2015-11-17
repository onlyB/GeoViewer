/* Copyright by ICEA - 2012
 * 
 * Created By Binh.N.D 06/10/2012
 * 
 * Update By Binh.N.D 07/10/2012
 * - Updated note
 * - Updated Note
 * Update By Binh.N.D 08/10/2012
 * - Updated note
 * - Updated Note
 *      
 */

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Linq;
using System.Text;
using GeoViewer.Business.Properties;
using GeoViewer.Models;
using GeoViewer.Utils;
namespace GeoViewer.Business
{
    public partial class AccountBLL
    {
        #region Instance Of Class
        private static AccountBLL _current = new AccountBLL();
        public static AccountBLL Current
        {
            get { return _current; }
        }
        #endregion

        private Account _logedInUser;
        public Account LogedInUser
        {
            get { return _logedInUser; }
        }

        public void Login(string username, string password)
        {
            using (var entityConntext = new GeoViewerEntities())
            {
                string md5Pass = password.GetMd5Hash();
                Account obj = entityConntext.Accounts.SingleOrDefault(ent => ent.Username == username);
                if (obj == null) throw new Exception(Properties.Resources.Error_Account_AccountNotExist);
                if (obj.Password != md5Pass) throw new Exception(Properties.Resources.Error_Account_PasswordNotMatch);
                if (!obj.IsApproved) throw new Exception(Resources.Error_Account_UnApproved);
                if (obj.IsLocked) throw new Exception(Resources.Error_Account_IsLocked);
                _logedInUser = obj;
                obj.LastLoginDate = DateTime.Now;
                entityConntext.SaveChanges();
            }
        }

        public void Logout()
        {
            _logedInUser = null;
        }

        public void Validate(Account account)
        {
            if (!account.Username.IsValidUsername()) throw new Exception(Resources.Error_UsernameInvalid);
            if (!account.Email.IsValidEmail()) throw new Exception(Resources.Error_EmailInvalid);
            if (!account.FullName.IsValidLength(0, 100)) throw new Exception(Resources.Error_FullNameInvalid);
            // Check RootAdmin
            if (account.Username == "RootAdmin" && (!account.IsApproved || account.IsLocked)) throw new Exception(Resources.Error_CannotLockRootAdmin);
        }

        public bool Insert(Account account)
        {
            using (var entityConntext = new GeoViewerEntities())
            {
                SecurityBLL.Current.CheckPermissionThrowException(SecurityBLL.ROLE_ACCOUNT_MANAGE);
                Validate(account);
                int count = entityConntext.Accounts.Count(ent => ent.Username == account.Username);
                if (count > 0) throw new Exception(Properties.Resources.Error_Account_UsernameExist);
                count = entityConntext.Accounts.Count(ent => ent.Email == account.Email);
                if (count > 0) throw new Exception(Properties.Resources.Error_Account_EmailExist);
                account.Password = account.Password.GetMd5Hash();
                account.CreatedDate = DateTime.Now;
                account.IsApproved = true;
                account.IsLocked = false;
                entityConntext.Accounts.AddObject(account);
                return entityConntext.SaveChanges() > 0;
            }
        }

        public bool Update(Account account)
        {
            using (var entityConntext = new GeoViewerEntities())
            {
                SecurityBLL.Current.CheckPermissionThrowException(new string[]
                                                                      {
                                                                          SecurityBLL.ROLE_ACCOUNT_MANAGE,
                                                                          SecurityBLL.ROLE_ACCOUNT_EDIT
                                                                      });
                Validate(account);
                int count =
                    entityConntext.Accounts.Count(
                        ent => ent.Username != account.Username && ent.Email == account.Email);
                if (count > 0)
                {
                    throw new Exception(Resources.Error_Account_EmailIsUsed);
                }
                entityConntext.AttachUpdatedObject(account);
                return entityConntext.SaveChanges() > 0;
            }
        }

        public bool Delete(Account account)
        {
            using (var entityConntext = new GeoViewerEntities())
            {
                SecurityBLL.Current.CheckPermissionThrowException(SecurityBLL.ROLE_ACCOUNT_MANAGE);
                // Check RootAdmin
                if (account.Username == "RootAdmin") throw new Exception(Resources.Error_CannotDeleteRootAdmin);
                entityConntext.AttachUpdatedObject(account, EntityState.Deleted);
                return entityConntext.SaveChanges() > 0;
            }
        }

        public bool Delete(string username)
        {
            var account = GetByUsername(username);
            if (account != null)
                return Delete(account);
            return false;
        }

        /// <summary>
        /// LogedIn user changes his password
        /// </summary>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public bool ChangePassword(string oldPassword, string newPassword)
        {
            using (var entityConntext = new GeoViewerEntities())
            {
                if (AppContext.Current.LogedInUser.Password != oldPassword.GetMd5Hash())
                    throw new Exception(Properties.Resources.Error_OldPasswordNotMatch);

                AppContext.Current.LogedInUser.Password = newPassword.GetMd5Hash();

                entityConntext.AttachUpdatedObject(AppContext.Current.LogedInUser);
                return entityConntext.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// Admin change password of an user
        /// </summary>
        /// <param name="user"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public bool ChangePassword(Account user, string newPassword)
        {
            using (var entityConntext = new GeoViewerEntities())
            {
                SecurityBLL.Current.CheckPermissionThrowException(new string[]
                                                                      {
                                                                          SecurityBLL.ROLE_ACCOUNT_EDIT,
                                                                          SecurityBLL.ROLE_ACCOUNT_MANAGE
                                                                      });
                user.Password = newPassword.GetMd5Hash();
                entityConntext.AttachUpdatedObject(user);
                return entityConntext.SaveChanges() > 0;
            }
        }

        public Account GetByUsername(string username)
        {
            using (var entityConntext = new GeoViewerEntities())
            {
                return entityConntext.Accounts.SingleOrDefault(ent => ent.Username == username);
            }
        }
    }
}
