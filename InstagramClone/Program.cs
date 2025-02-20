using InstagramClone.BLL;
using InstagramClone.DAL;
using InstagramClone.Models;
using Microsoft.EntityFrameworkCore;

namespace InstagramClone {
	public class Program {
		public static void Main(string[] args) {
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddDbContext<InsDataContext>(options =>
				options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			// BLL
			builder.Services.AddTransient<CommentService>();
			builder.Services.AddTransient<DirectMessageService>();
			builder.Services.AddTransient<PostService>();
			builder.Services.AddTransient<StoryService>();
			builder.Services.AddTransient<UserInteractionService>();
			builder.Services.AddTransient<UserService>();

			// DAL
			builder.Services.AddTransient<UserRepository>();
			builder.Services.AddTransient<CommentRepository>();
			builder.Services.AddTransient<DirectMessageRepository>();
			builder.Services.AddTransient<PostRepository>();
			builder.Services.AddTransient<StoryRepository>();
			builder.Services.AddTransient<UserInteractionRepository>();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment()) {
				app.UseExceptionHandler("/Home/Error");
			}
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
