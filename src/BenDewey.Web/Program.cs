using BenDewey.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.Configure<ContactEmailOptions>(builder.Configuration.GetSection(ContactEmailOptions.SectionName));
builder.Services.AddTransient<IContactEmailSender, SmtpContactEmailSender>();
builder.Services.Configure<ProjectInventoryOptions>(builder.Configuration.GetSection(ProjectInventoryOptions.SectionName));
builder.Services.AddSingleton<IProjectInventoryAccess, ProjectInventoryAccess>();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(8);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.Name = "BenDewey.ProjectInventory";
    options.Cookie.SameSite = SameSiteMode.Lax;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
