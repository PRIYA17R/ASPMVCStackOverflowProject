using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace StackOverflow.ServiceLayer
{
  public static  class MapperExtension
    {
        public static void IgnoreUnMappedProperties (TypeMap map, IMappingExpression expr)
        {
            foreach (string propName in map.GetUnmappedPropertyNames())
            {
                if(map.SourceType.GetProperty(propName) != null)
                {
                    expr.ForMember(propName, opt => opt.Ignore());
                }
                if (map.DestinationType.GetProperty(propName) != null)
                {
                    expr.ForMember(propName, opt => opt.Ignore());
                }

            }
        }
        public static void IgnoreUnMapped(this IProfileExpression profile)
        {
            profile.ForAllMaps(IgnoreUnMappedProperties);
        }
    }
}


