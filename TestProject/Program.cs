using TestProject.Authorization;
using TestProject.IServices;
using TestProject.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserTokenService, UserTokenService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IMailService, MailService>();
builder.Services.AddScoped<IUserAuthorizeService, UserAuthorizeService>();
builder.Services.AddScoped<ITranslationService, TranslationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.UseMiddleware<AuthenticationMiddleware>();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
