/* Copyright by ICEA - 2012
 * 
 * Created By Binh.N.D 06/10/2012
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeoViewer.Business.Properties;
using GeoViewer.Models;

namespace GeoViewer.Business
{
    public class SecurityBLL
    {
        #region Instance Of Class
        private static SecurityBLL _current = new SecurityBLL();
        public static SecurityBLL Current
        {
            get { return _current; }
        }
        #endregion

        #region Constant Of Roles

        public const string ROLE_ACCOUNT_MANAGE = "ACCOUNT_MANAGE";
        public const string ROLE_ACCOUNT_EDIT = "ACCOUNT_EDIT";
        public const string ROLE_ACCOUNT_VIEW = "ACCOUNT_VIEW";

        public const string ROLE_ALARM_EDIT = "ALARM_EDIT";
        public const string ROLE_ALARM_MANAGE = "ALARM_MANAGE";
        public const string ROLE_ALARM_VIEW = "ALARM_VIEW";

        public const string ROLE_DATA_EDIT = "DATA_EDIT";
        public const string ROLE_DATA_MANAGE = "DATA_MANAGE";
        public const string ROLE_DATA_VIEW = "DATA_VIEW";

        public const string ROLE_VIEWS_EDIT = "VIEWS_EDIT";
        public const string ROLE_VIEWS_MANAGE = "VIEWS_MANAGE";
        public const string ROLE_VIEWS_VIEW = "VIEWS_VIEW";

        #endregion

        public bool IsUserInRole(Account user, string role)
        {
            return IsUserInRole(user.Username, role);
        }

        public bool IsUserInRoles(Account user, string[] roles, bool requireAll = false)
        {
            return IsUserInRoles(user.Username, roles, requireAll);
        }

        public bool IsUserInRole(string username, string role)
        {
            using (var entityConntext = new GeoViewerEntities())
            {
                return entityConntext.Accounts.Any(ent => ent.Username == username && ent.Roles.Any(r => r.RoleName == role));
            }
        }

        public bool IsUserInRoles(string username, string[] roles, bool requireAll = false)
        {
            using (var entityConntext = new GeoViewerEntities())
            {
                foreach (var role in roles)
                {
                    bool hasRole = entityConntext.Accounts.Any(ent => ent.Username == username && ent.Roles.Any(r => r.RoleName == role));
                    if (hasRole && !requireAll)
                    {
                        return true;
                    }
                    if (!hasRole && requireAll)
                    {
                        return false;
                    }
                }
                return requireAll;
            }
        }

        public bool IsUserInRole(string role)
        {
            if (AccountBLL.Current.LogedInUser != null) return IsUserInRole(AccountBLL.Current.LogedInUser.Username, role);
            return false;
        }

        public bool IsUserInRoles(string[] roles, bool requireAll = false)
        {
            if (AccountBLL.Current.LogedInUser != null) return IsUserInRoles(AccountBLL.Current.LogedInUser.Username, roles, requireAll);
            return false;
        }

        public bool SetRolesForUser(string userName, string[] roles)
        {
            using (var entityConntext = new GeoViewerEntities())
            {
                // Check RootAdmin
                if (userName == "RootAdmin" && !roles.Contains(ROLE_ACCOUNT_MANAGE))
                    throw new Exception(Resources.Error_CannotRemoveAccountRoleOfRootAdmin);
                var user = entityConntext.Accounts.FirstOrDefault(ent => ent.Username == userName);
                if (user != null)
                {
                    user.Roles.Clear();
                    foreach (var role in roles)
                    {
                        var r = entityConntext.Roles.SingleOrDefault(ent => ent.RoleName == role);
                        if (r != null)
                        {
                            user.Roles.Add(r);
                        }
                    }
                    return entityConntext.SaveChanges() > 0;
                }
                return false;
            }
        }
        
        public void CheckPermissionThrowException(string role)
        {
            if (AccountBLL.Current.LogedInUser == null) throw new Exception(Resources.SecurityBLL_MustLogin);
            if (!IsUserInRole(role))
                throw new Exception(Properties.Resources.Error_Security_NotPermission);
        }

        public void CheckPermissionThrowException(string[] roles, bool requireAll = false)
        {
            if (AccountBLL.Current.LogedInUser == null) throw new Exception(Resources.SecurityBLL_MustLogin);
            if (!IsUserInRoles(roles, requireAll))
                throw new Exception(Properties.Resources.Error_Security_NotPermission);
        }
    }
}
