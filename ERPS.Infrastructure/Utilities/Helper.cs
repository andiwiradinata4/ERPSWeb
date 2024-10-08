﻿using ERPS.Core.Entities.Base.Interface;
using System.Security.Claims;
using System.Security.Principal;

namespace ERPS.Infrastructure.Utilities
{
    public class Helper
    {
        public static void setPostData(IBaseEntityStandard entity, IPrincipal user)
        {
            entity.CreatedDate = DateTime.Now;
            entity.CreatedDateUTC = DateTime.UtcNow;
            entity.LogDate = DateTime.Now;
            entity.LogDateUTC = DateTime.UtcNow;
            if (user != null)
            {
                entity.CreatedBy = getValueFromClaims(user, "nameidentifier", user.Identity?.Name ?? "");
                entity.CreatedByUserDisplayName = getValueFromClaims(user, "name", user.Identity?.Name ?? "");
                entity.LogBy = getValueFromClaims(user, "nameidentifier", user.Identity?.Name ?? "");
                entity.LogByUserDisplayName = getValueFromClaims(user, "name", user.Identity?.Name ?? "");
            }
        }

        public static void setPostDataForNonBaseEntity(object entity, IPrincipal user)
        {
            //Type type = entity.GetType();
            //PropertyInfo property = type.GetProperty("CreatedDate");
            //PropertyInfo property3 = type.GetProperty("CreatedDateUTC");
            //PropertyInfo property2 = type.GetProperty("LogDate");
            //PropertyInfo property4 = type.GetProperty("LogDateUTC");
            //PropertyInfo property5 = type.GetProperty("CreatedBy");
            //PropertyInfo property6 = type.GetProperty("LogBy");
            //PropertyInfo property7 = type.GetProperty("CreatedByUserDisplayName");
            //PropertyInfo property8 = type.GetProperty("LogByUserDisplayName");
            //property.SetValue(entity, DateTime.Now);
            //property2.SetValue(entity, DateTime.Now);
            //property3.SetValue(entity, DateTime.UtcNow);
            //property4.SetValue(entity, DateTime.UtcNow);
            //if (user != null)
            //{
            //    property5.SetValue(entity, user.Identity!.Name);
            //    property6.SetValue(entity, user.Identity!.Name);
            //    property7.SetValue(entity, getValueFromClaims(user, "userDisplayName", user.Identity?.Name ?? ""));
            //    property8.SetValue(entity, getValueFromClaims(user, "userDisplayName", user.Identity?.Name ?? ""));
            //}
        }

        public static void setPutData(IBaseEntityStandard entity, IPrincipal user)
        {
            entity.LogDate = DateTime.Now;
            entity.LogDateUTC = DateTime.UtcNow;
            if (user != null)
            {
                entity.LogBy = getValueFromClaims(user, "nameidentifier", user.Identity?.Name ?? "");

                ///NameIdentifier
                ///userDisplayName
                entity.LogByUserDisplayName = getValueFromClaims(user, "name", user.Identity?.Name ?? "");
            }
            
        }

        public static void setPutDataForNonBaseEntity(object entity, IPrincipal user)
        {
            //Type type = entity.GetType();
            //PropertyInfo property = type.GetProperty("LogDate");
            //PropertyInfo property2 = type.GetProperty("LogDateUTC");
            //PropertyInfo property3 = type.GetProperty("LogBy");
            //PropertyInfo property4 = type.GetProperty("LogByUserDisplayName");
            //property.SetValue(entity, DateTime.Now);
            //property2.SetValue(entity, DateTime.UtcNow);
            //if (user != null)
            //{
            //    property3.SetValue(entity, user.Identity!.Name);
            //    property4.SetValue(entity, getValueFromClaims(user, "userDisplayName", user.Identity!.Name));
            //}
        }

        public static string getValueFromClaims(IPrincipal user, string claimType, string defaultValue = "")
        {
            try
            {
                if (user != null)
                {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                    ClaimsPrincipal user2 = user as ClaimsPrincipal;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                    return getValueFromClaims(user2!, claimType, defaultValue);
                }
            }
            catch
            {
            }

            return defaultValue;
        }

        public static string getValueFromClaims(ClaimsPrincipal user, string claimType, string defaultValue = "")
        {
            try
            {
                if (user != null && user.Claims != null && user.Claims.Count() > 0)
                {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                    Claim claim = user.Claims.Where((x) => x.Type.Equals(claimType, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                    if (claim == null) claim = user.Claims.Where((x) => x.Type.Contains(claimType, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                    if (claim != null && !string.IsNullOrEmpty(claim.Value))
                    {
                        return claim.Value;
                    }
                }
            }
            catch
            {
            }

            return defaultValue;
        }

    }
}
