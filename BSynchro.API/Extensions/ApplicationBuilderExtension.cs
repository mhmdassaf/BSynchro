using BSynchro.DAL.DataContext;
using Microsoft.EntityFrameworkCore;

namespace BSynchro.API.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static void ApplyMigration(this WebApplication app)
        {
           var dBContext  = app.Services.CreateScope().ServiceProvider.GetService<BSynchroDBContext>();
            if(dBContext != null)
                dBContext.Database.Migrate();
        }
    }
}
