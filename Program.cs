var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/api/decode", (string input) => {
    return new { result = DecodeInput(input) };
});

app.UseDefaultFiles(); 
app.UseStaticFiles();

app.Run();

string DecodeInput(string input) {
    if(input == null || input == "") {
        return new string("Hello, World!");
    } else {
        // Need to test the input
        return new string(input);
    }
}

string Ones(string input) {
    return null;
}

string Tens(string input) {
    return null;
}