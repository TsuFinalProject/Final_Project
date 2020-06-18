using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services.Helper
{
  public static  class  EnumHelper
    {

               public static  List<string> GetAllEnumNames(this Type type)  {
                  List<string> list = new List<string>();

                 var arr = type.GetEnumNames();

                  foreach (var el in arr)
                    {
                         list.Add(el);
                  }
  
                  return list;
    }
}
}
