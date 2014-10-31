using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryHelper
{
   public static class Common
    {
       public enum Roles
       {
           [Description("RoleAdmin")]
           Admin= 1,
           [Description("RoleUser")]
           User= 2,
           [Description("RoleSupplier")]
           Supplier= 3,
           [Description("RoleCustomer")]
           Customer = 4
       }

       public static string GetString(this Enum en)
       {
           return en.ToString().Trim();
       }
       
       public static string GetDescription(this Enum en)
       {
           Type type = en.GetType();

           MemberInfo[] memInfo = type.GetMember(en.ToString());

           if (memInfo != null && memInfo.Length > 0)
           {
               object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

               if (attrs != null && attrs.Length > 0)
               {
                   return ((DescriptionAttribute)attrs[0]).Description;
               }
           }

           return en.ToString();
          
       }
    }
}
