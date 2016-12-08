using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Help.Common.Service
{
    public class StartUp
    {
        public static void AutoMapperStart()
        {
            var profiles = Assembly.GetExecutingAssembly().GetTypes().Where(t => typeof(Profile).IsAssignableFrom(t) && t.GetConstructor(Type.EmptyTypes) != null)
                .Select(Activator.CreateInstance).Cast<Profile>().ToList();

            Mapper.Initialize(a => profiles.ForEach(a.AddProfile));
        }
    }
}
