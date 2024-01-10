using FastFoodSignalR.BusinessLayer.Abstract;
using FastFoodSignalR.BusinessLayer.Concrate;
using FastFoodSignalR.DataAccessLayer.Abstract;
using FastFoodSignalR.DataAccessLayer.Concrate;
using FastFoodSignalR.DataAccessLayer.EntityFramework;
using FastFoodSignalR.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SignalRAPI.Hubs;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<FastFoodContext>();
builder.Services.AddIdentity<AppUser, AppRole>(
    opt =>
    {
        opt.Password.RequireNonAlphanumeric = false;
        opt.Password.RequiredLength = 1;
        opt.Password.RequireUppercase = false;
        opt.Password.RequireLowercase = false;
        opt.Password.RequireDigit = false;
    }
    )
    // .AddErrorDescriber<CustomerIdentityValidation>()
    .AddEntityFrameworkStores<FastFoodContext>();
builder.Services.AddMvc();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());


builder.Services.AddScoped<IAboutService, AboutManager>();
builder.Services.AddScoped<IAboutDal, efAboutDal>();

builder.Services.AddScoped<IBookingService, BookingManager>();
builder.Services.AddScoped<IBookingDal, efBookingDal>();

builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICategoryDal, efCategoryDal>();

builder.Services.AddScoped<IContactService, ContactManager>();
builder.Services.AddScoped<IContactDal, efContactDal>();

builder.Services.AddScoped<IDiscountService, DiscountManager>();
builder.Services.AddScoped<IDiscountDal, efDiscountDal>();

builder.Services.AddScoped<IFeatureService, FeatureManager>();
builder.Services.AddScoped<IFeatureDal, efFeatureDal>();

builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<IProductDal, efProductDal>();

builder.Services.AddScoped<ISocialMediaService, SocialMediaManager>();
builder.Services.AddScoped<ISocialMediaDal, efSocialMediaDal>();

builder.Services.AddScoped<ITestimonialService, TestimonialManager>();
builder.Services.AddScoped<ITestimonialDal, efTestimonialDal>();

builder.Services.AddScoped<IOrderService, OrderManager>();
builder.Services.AddScoped<IOrderDal, efOrderDal>();

builder.Services.AddScoped<IOrderDetailService, OrderDetailManager>();
builder.Services.AddScoped<IOrderDetailDal, efOrderDetailDal>();

builder.Services.AddScoped<IMoneyCaseService, MoneyCaseManager>();
builder.Services.AddScoped<IMoneyCaseDal, efMoneyCaseDal>();


builder.Services.AddScoped<ISliderService, SliderManager>();
builder.Services.AddScoped<ISliderDal, efSliderDal>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.SetIsOriginAllowed((host) => true)
            //WithOrigins("https://localhost:44385/") 
                   .AllowCredentials()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.AddControllers();
builder.Services.AddSignalR();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("AllowSpecificOrigin");
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.MapHub<SignalRHub>("/signalrhub");

app.Run();
