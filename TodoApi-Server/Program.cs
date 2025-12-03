// using Microsoft.EntityFrameworkCore;
// // 💥 ודאי שה-Namespace של הפרויקט שלך (שמכיל את Items ו-ToDoDbContext) מיובא נכון
// using TodoApi; 

// var builder = WebApplication.CreateBuilder(args);

// // ===============================================
// // 1. הגדרות שירותים (Services Configuration)
// // ===============================================

// // הזרקת ה-DbContext לשירותי הפרויקט
// builder.Services.AddDbContext<ToDoDbContext>(
//     options => options.UseMySql(
//         builder.Configuration.GetConnectionString("ToDoDB"), 
//         new MySqlServerVersion(new Version(8, 0, 32)) 
//     )
// );

// // הוספת שירותי CORS (Cross-Origin Resource Sharing)
// builder.Services.AddCors();

// // הוספת שירותי Swagger לבדיקה קלה של ה-API
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// var app = builder.Build();

// // ===============================================
// // 2. הגדרות ה-Pipeline ו-Middleware
// // ===============================================

// // הפעלת Swagger - רק בסביבת פיתוח
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// // 💥 הפעלת CORS - הגדרת גישה כללית (AllowAnyOrigin)
// app.UseCors(options => 
// {
//     options.AllowAnyOrigin()
//            .AllowAnyMethod()
//            .AllowAnyHeader();
// });

// // ===============================================
// // 3. מיפוי נתיבים (CRUD Endpoints)
// // ===============================================

// // GET: שליפת כל המשימות
// app.MapGet("/api/todoitems", async (ToDoDbContext context) =>
// {
//     return await context.Items.ToListAsync(); 
// });

// // POST: הוספת משימה חדשה
// app.MapPost("/api/todoitems", async (ToDoDbContext context, Item item) =>
// {
//     context.Items.Add(item);
//     await context.SaveChangesAsync();
//     return Results.Created($"/api/todoitems/{item.Id}", item); 
// });

// // PUT: עדכון משימה קיימת לפי ID
// app.MapPut("/api/todoitems/{id}", async (ToDoDbContext context, int id, Item inputItem) =>
// {
//     var todoItem = await context.Items.FindAsync(id);
//     if (todoItem is null) return Results.NotFound();

//     todoItem.Name = inputItem.Name;
//     todoItem.IsComplete = inputItem.IsComplete;

//     await context.SaveChangesAsync();
//     return Results.NoContent();
// });

// // DELETE: מחיקת משימה קיימת לפי ID
// app.MapDelete("/api/todoitems/{id}", async (ToDoDbContext context, int id) =>
// {
//     var todoItem = await context.Items.FindAsync(id);
//     if (todoItem is null) return Results.NotFound();

//     context.Items.Remove(todoItem);
//     await context.SaveChangesAsync();

//     return Results.NoContent();
// });

// // ===============================================
// // 4. הרצת האפליקציה
// // ===============================================
// app.Run();


// using Microsoft.EntityFrameworkCore;
// using TodoApi;
// using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

// var builder = WebApplication.CreateBuilder(args);

// // ===============================================
// // 1. הזרקת ה-DbContext (חיבור למסד הנתונים)
// // ===============================================
// var connectionString = builder.Configuration.GetConnectionString("ToDoDB");
// var serverVersion = new MySqlServerVersion(new Version(8, 0, 32)); // עדכנו בהתאם לגרסת ה-MySQL שלכם

// builder.Services.AddDbContext<ToDoDbContext>(
//     options => options.UseMySql(connectionString, serverVersion)
// );

// // ===============================================
// // 2. הוספת שירותים נדרשים
// // ===============================================

// // CORS: מאפשר לקליינט ה-React לפנות ל-API
// builder.Services.AddCors(options =>
// {
//     options.AddDefaultPolicy(
//         policy =>
//         {
//             // מאפשר גישה מכל מקור, לכל המתודות ולכל הכותרות.
//             // ב-Production יש לצמצם את ה-AllowAnyOrigin לכתובת הספציפית של הקליינט.
//             policy.AllowAnyOrigin()
//                   .AllowAnyMethod()
//                   .AllowAnyHeader();
//         });
// });

// // Swagger/OpenAPI: מאפשר תיעוד וממשק לבדיקת ה-API
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// var app = builder.Build();

// // ===============================================
// // 3. הגדרת Middleware (בשימוש בזמן ריצה)
// // ===============================================

// // הפעלת Swagger ו-SwaggerUI רק בסביבת פיתוח (אופציונלי אך מומלץ)
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// // שימוש ב-CORS
// app.UseCors();

// // ===============================================
// // 4. מיפוי נתיבים (CRUD Endpoints)
// // ===============================================

// // GET: שליפת כל המשימות
// app.MapGet("/api/todoitems", async (ToDoDbContext context) =>
// {
//     // משתמשים ב-context.Items שמוגדר ב-ToDoDbContext
//     return await context.Items.ToListAsync();
// })
// .WithName("GetTodoItems"); // נותן שם ל-Endpoint (עוזר ל-Swagger)

// // GET: שליפת משימה יחידה לפי ID
// app.MapGet("/api/todoitems/{id}", async (ToDoDbContext context, int id) =>
// {
//     var item = await context.Items.FindAsync(id);
//     return item is null ? Results.NotFound() : Results.Ok(item);
// })
// .WithName("GetTodoItem");

// // POST: הוספת משימה חדשה
// app.MapPost("/api/todoitems", async (ToDoDbContext context, Item newItem) =>
// {
//     context.Items.Add(newItem);
//     await context.SaveChangesAsync();
//     // מחזירים 201 Created עם כתובת המשאב החדש
//     return Results.Created($"/api/todoitems/{newItem.Id}", newItem);
// })
// .WithName("CreateTodoItem");

// // PUT: עדכון משימה קיימת לפי ID
// app.MapPut("/api/todoitems/{id}", async (ToDoDbContext context, int id, Item inputItem) =>
// {
//     var todoItem = await context.Items.FindAsync(id);
//     if (todoItem is null) return Results.NotFound();

//     todoItem.Name = inputItem.Name;
//     todoItem.IsComplete = inputItem.IsComplete;

//     await context.SaveChangesAsync();
//     // מחזירים 204 No Content
//     return Results.NoContent();
// })
// .WithName("UpdateTodoItem");

// // DELETE: מחיקת משימה קיימת לפי ID
// app.MapDelete("/api/todoitems/{id}", async (ToDoDbContext context, int id) =>
// {
//     var todoItem = await context.Items.FindAsync(id);
//     if (todoItem is null) return Results.NotFound();

//     context.Items.Remove(todoItem);
//     await context.SaveChangesAsync();

//     // מחזירים 204 No Content
//     return Results.NoContent();
// })
// .WithName("DeleteTodoItem");


// app.Run();



using Microsoft.EntityFrameworkCore;
using TodoApi;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// ===============================================
// 1. הזרקת ה-DbContext - התאמה ל-Deployment
// ===============================================

// 💥 תיקון קריטי: מחפש קודם את ToDoDB (מקומי) ואז את משתנה הסביבה CONNECTION_STRING (ענן)
var connectionString = builder.Configuration.GetConnectionString("ToDoDB") ?? 
                       builder.Configuration.GetValue<string>("CONNECTION_STRING");

if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string 'ToDoDB' or 'CONNECTION_STRING' not found. Check appsettings.json or environment variables.");
}

// הגדרת גרסת השרת ל-MySQL (ודאי גרסה תואמת ל-CleverCloud)
var serverVersion = new MySqlServerVersion(new Version(8, 0, 32)); 

builder.Services.AddDbContext<ToDoDbContext>(
    //options => options.UseMySql(connectionString, serverVersion)
    // Program.cs מחפש Connection String בשם "ToDoDB"
options=>options.UseMySql(
    builder.Configuration.GetConnectionString("ToDoDB"),
    new MySqlServerVersion(new Version(8, 0, 32))
    // ...
)
);

// ===============================================
// 2. הוספת שירותים נדרשים (CORS, Swagger)
// ===============================================
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ===============================================
// 3. הגדרת Middleware
// ===============================================
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors();

// ===============================================
// 4. מיפוי נתיבים (CRUD Endpoints)
// ===============================================

// GET All
app.MapGet("/api/todoitems", async (ToDoDbContext context) => await context.Items.ToListAsync());

// GET by ID
app.MapGet("/api/todoitems/{id}", async (ToDoDbContext context, int id) =>
{
    var item = await context.Items.FindAsync(id);
    return item is null ? Results.NotFound() : Results.Ok(item);
});

// POST (Create)
app.MapPost("/api/todoitems", async (ToDoDbContext context, Item newItem) =>
{
    context.Items.Add(newItem);
    await context.SaveChangesAsync();
    return Results.Created($"/api/todoitems/{newItem.Id}", newItem);
});

// PUT (Update)
app.MapPut("/api/todoitems/{id}", async (ToDoDbContext context, int id, Item inputItem) =>
{
    var todoItem = await context.Items.FindAsync(id);
    if (todoItem is null) return Results.NotFound();

    todoItem.Name = inputItem.Name;
    todoItem.IsComplete = inputItem.IsComplete;

    await context.SaveChangesAsync();
    return Results.NoContent();
});

// DELETE
app.MapDelete("/api/todoitems/{id}", async (ToDoDbContext context, int id) =>
{
    var todoItem = await context.Items.FindAsync(id);
    if (todoItem is null) return Results.NotFound();

    context.Items.Remove(todoItem);
    await context.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();