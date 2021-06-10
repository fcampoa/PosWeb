using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace POS.Model.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            var types = Assembly.GetExecutingAssembly().GetExportedTypes().Union(Assembly.GetCallingAssembly().GetExportedTypes());

#pragma warning disable CS0618 // Type or member is obsolete
            object p = new MapperConfiguration(cfg =>
            {
               // cfg.CreateMissingTypeMaps = false;

                LoadStandardMappings(types: types, mapper: cfg);

                LoadCustomMappings(types, cfg);
            });
#pragma warning restore CS0618 // Type or member is obsolete
        }

        public static void LoadCustomMappings(IEnumerable<Type> types, IMapperConfigurationExpression mapper)
        {
            if (types == null)
            {
                types = Assembly.GetExecutingAssembly().GetExportedTypes().Union(Assembly.GetCallingAssembly().GetExportedTypes());
            }

            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where typeof(ICustomMappings).IsAssignableFrom(t) &&
                              !t.IsAbstract &&
                              !t.IsInterface
                        select (ICustomMappings)Activator.CreateInstance(t)).ToArray();

            foreach (var map in maps)
            {
                map.CreateMappings(mapper);
            }

        }

        public static void LoadStandardMappings(IEnumerable<Type> types, IMapperConfigurationExpression mapper)
        {
            if (types == null)
            {
                types = Assembly.GetExecutingAssembly().GetExportedTypes().Union(Assembly.GetCallingAssembly().GetExportedTypes());
            }

            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>) &&
                              !t.IsAbstract &&
                              !t.IsInterface
                        select new
                        {
                            Source = i.GetGenericArguments()[0],
                            Destination = t
                        });

            foreach (var map in maps)
            {
                mapper.CreateMap(map.Source, map.Destination);
                mapper.CreateMap(map.Destination, map.Source);
            }
        }

        /// <summary>
        /// To be used only for test cases
        /// </summary>
        public static void Reset()
        {
           // Mapper.Reset();
        }
    }
}
