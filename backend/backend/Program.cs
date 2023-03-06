var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000")
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod();
                      });
});


//for session variables, currently doesn't work
//builder.Services.AddHttpContextAccessor();
//builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

//for session variables, currently doesn't work
//// services.AddResponseCaching();
//builder.Services.AddDistributedMemoryCache();
//builder.Services.AddSession();
builder.Services.AddControllers();


var app = builder.Build();

//for session variables, currently doesn't work
//app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();