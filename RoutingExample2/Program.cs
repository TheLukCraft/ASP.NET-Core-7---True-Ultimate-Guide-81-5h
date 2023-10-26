using RoutingExample2.CustomConstraints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRouting(options =>
{
    options.ConstraintMap.Add("months", typeof(MonthsCustomConstraint));
});

var app = builder.Build();

app.UseRouting();

#pragma warning disable ASP0014 // Suggest using top level route registrations
app.UseEndpoints(async endpoints =>
{
    endpoints.Map("files/{filename}.{extension}", async context =>
    {
        string? filename = Convert.ToString(context.Request.RouteValues["filename"]);
        string? extension = Convert.ToString(context.Request.RouteValues["extension"]);
        await context.Response.WriteAsync($"In files - {filename} - {extension}");
    });
    endpoints.Map("employee/profile/{EmployeeName:minlength(3):maxlength(7):alpha=luk}", async context =>
    //you can use length with 2 values instead of using min and max.
    //endpoints.Map("employee/profile/{EmployeeName:length(4,7)=luk}", async context =>
    {
        string? emplyeename = Convert.ToString(context.Request.RouteValues["employeename"]);
        await context.Response.WriteAsync($"In Emplyee profile - {emplyeename}");
    });
    //you can use min and max for numbers, but if you want 2 values, youu can use range
    //endpoints.Map("products/details/{id:int:min(1)?}", async context =>
    endpoints.Map("products/details/{id:int:range(1,100)?}", async context =>
    {
        if (context.Request.RouteValues.ContainsKey("id"))
        {
            int id = Convert.ToInt32(context.Request.RouteValues["id"]);
            await context.Response.WriteAsync($"Product details - {id}");
        }
        else
        {
            await context.Response.WriteAsync($"Product details - id is not supplied");
        }
    });

    // daily-dgest-report/{reportdate}
    endpoints.Map("daily-digest-report/{reportdate:datetime}", async context =>
    {
        DateTime reportdate = Convert.ToDateTime(context.Request.RouteValues["reportdate"]);
        await context.Response.WriteAsync($"In daily-digest-report: {reportdate}");
    });

    // cities/cityid
    endpoints.Map("cities/{cityid:guid}", async context =>
    {
        Guid cityid = Guid.Parse(Convert.ToString(context.Request.RouteValues["cityid"])!);
        await context.Response.WriteAsync($"City information - {cityid}");
    });

    //sales-report/2030/apr
    endpoints.Map("sales-report/{year:int:min(1900)}/{month:months}", async context =>
    {
        int year = Convert.ToInt32(context.Request.RouteValues["year"]);
        string? month = Convert.ToString(context.Request.RouteValues["month"]);
        if (month == "apr" || month == "jul" || month == "oct" || month == "jan")
            await context.Response.WriteAsync($"sales report - {year} - {month}");
        else
            await context.Response.WriteAsync($"{year} - {month} is not allowed for sales report");
    });

    //sales-report/2024/jan
    endpoints.Map("sales-report/2024/jan", async context =>
    {
        await context.Response.WriteAsync("Sales report exclusively for 2024 - jan");
    });
});
#pragma warning restore ASP0014 // Suggest using top level route registrations

app.Run(async context =>
{
    await context.Response.WriteAsync($"No rote matched at");
});
app.Run();