using System;
using MySql.Data.MySqlClient;

var builder = WebApplication.CreateBuilder(args);
//string yourConnectionString = builder.Configuration.GetConnectionString("Default");

var app = builder.Build();
string yourConnectionString = "Server=127.0.0.1;Database=empropazlocal;User ID=empropazlocal;Password=2GinTwasODakgOPLqCKoOueYGQUsfEjYjsSiEM2Qr7I;";
using var conn = new MySqlConnection(yourConnectionString);


app.MapGet("/", () => {

    try{
        // Abrir la conexión
        conn.Open();
        Console.WriteLine("Conexión exitosa a MySQL!");

        // Aquí puedes ejecutar tus comandos SQL
    }catch (MySqlException ex)
    {
        // Manejo de errores de conexión
        
        Console.WriteLine($"Error: {ex.Message}");
    }

});



app.Run();
