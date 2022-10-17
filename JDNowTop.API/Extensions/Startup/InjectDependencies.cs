using JDNowTop.Data.Models;
using JDNowTop.Data.Repositories.Abstractions;
using JDNowTop.Data.Repositories.Realizations;
using JDNowTop.Logic.Services.Abstractions;
using JDNowTop.Logic.Services.Realizations;
using System;

namespace JDNowTop.API.Extensions.Startup
{
    public static class InjectDependencies
    {
        public static void InjectServices(this IServiceCollection services)
        {
            services.AddScoped<ISongService, SongService>();
            services.AddScoped<IPositionService, PositionService>();
            services.AddScoped<IWeekService, WeekService>();
            services.AddScoped<ITimeService, TimeService>();
            services.AddScoped<IUserService, UserService>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => a.FullName == "JDNowTop.API, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null" ||
                            a.FullName == "JDNowTop.Data, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"));
        }

        public static void InjectRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Song, string>, SongRepository>();
            services.AddScoped<IRepository<Position, int>, PositionRepository>();
            services.AddScoped<IRepository<Week, int>, WeekRepository>();
            services.AddScoped<IRepository<UserData, string>, UserRepository>();
        }
    }
}
