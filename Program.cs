using System;
using Npgsql;


var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

string connectionString = "Server=127.0.0.1;Database=template1;User ID=postgres;Password=@Super12345;";
using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
connection.Open();


app.MapGet("/", () => {

    try{
        using NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM departamentos", connection);
        using NpgsqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
        // Use the fetched results
            Console.WriteLine("Fila encontrada");
        }


        // Abrir la conexión
        //conn.Open();

        // Aquí puedes ejecutar tus comandos SQL
    }catch (NpgsqlException ex)
    {
        // Manejo de errores de conexión
        
        Console.WriteLine($"Error: {ex.Message}");
    }

});



app.Run();
