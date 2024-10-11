using System.Diagnostics;
using BloggingPlatformAssignment;
using BloggingPlatformAssignment.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddSingleton<MongoDBContext>(provider => new MongoDBContext(connectionString: "mongodb://localhost:27017", databaseName: "MongoDB", collectionName: "Collection"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<MongoDBContext>();
    
    User user = new User(){Username = "Henrik", Password = "Henrikspassword", Email = "henriks@gmail.com", Bio = "Henrik blogger max!"};
    User user2 = new User() {Username = "KetoFan", Password = "Ketofanpassword", Email = "ketofan@gmail.com", Bio = "KetoFan jeg vil vide alt om keto!!1!"};
    Blog blog = new Blog() {BlogOwner = user.Id, Name = "Henrik Keto Blog"};
    Post post = new Post() {UserId = user.Id, BlogId = blog.Id, Title = "Kom i gang med Keto!", Content = "Når du skal starte på keto, er der et par nødvendige " +
        "informationer du skal have til at starte med. Keto navnet kommer fra ketose, som er den tilstand kroppen skal være i, når man følger keto diæten"};
    Comment comment = new Comment(){PostId = post.Id, UserId = user2.Id, Content = "Nice. Godt skrevet! Jeg venter spændt på flere indlæg."};
    Comment comment2 = new Comment(){PostId = post.Id, UserId = user2.Id, Content = "Når ja, forresten. Du skriver slet ikke noget om ketogener?"};
    Comment comment3 = new Comment(){PostId = post.Id, UserId = user.Id, Content = "Slap af, Robert Dølhhus - det kommer senere."};
    context.Collection<User>().InsertOneAsync(user);
    context.Collection<User>().InsertOneAsync(user2);
    context.Collection<Blog>().InsertOneAsync(blog);
    context.Collection<Post>().InsertOneAsync(post);
    context.Collection<Comment>().InsertOneAsync(comment);
    context.Collection<Comment>().InsertOneAsync(comment2);
    context.Collection<Comment>().InsertOneAsync(comment3);
}


app.Run();

