var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/api/decode", (double input) => {
    return new { result = DecodeInput(input) };
});

app.UseDefaultFiles(); 
app.UseStaticFiles();

app.Run();

string DecodeInput(double input) {
    // Input Testing
    if(input == 0) {
        return new string("Hello, World!");
    } else {
        string output = "";

        // Split number into two at the decimal point e.g. "123" and "45"
        string[] parts = input.ToString().Split('.');
        // Parse the whole digits into an array e.g. [1,2,3]
        var digits = parts[0].Select(c => int.Parse(c.ToString())).ToArray();
        // Parse the decimal digits into an array or return an empty one e.g. [4,5] or []
        var decimals = parts.Length > 1 
            ? parts[1].Select(c => int.Parse(c.ToString())).ToArray()
            : Array.Empty<int>();

        // This will likely be a for loop, need to figure out the best pattern
        //for (int i=0; i<digits.Length-1; i++) {
            if (digits.Length == 1) {
                output += Ones(digits[0]);
            } else if (digits.Length == 2 && digits[1] == 0) {
                output += Tens(digits[0]);
            } else if (digits.Length == 2 && digits[0] == 1) {
                output += Teens(digits[1]);
            } else if (digits.Length == 2) {
                output += Tens(digits[0]) + " ";
                output += Ones(digits[1]);
            }
        //}

        if (decimals.Length == 0) {
            // No decimals to work with.
        }
        return output;
    }
}

// How do I handle Zeros? Probably before calling Ones
// I can probably combine the following three into one function

string Ones(int input) {
    switch(input) {
    case 1:
        return new string("ONE");
    case 2:
        return new string("TWO");
    case 3:
        return new string("THREE");
    case 4:
        return new string("FOUR");
    case 5:
        return new string("FIVE");
    case 6:
        return new string("SIX");
    case 7:
        return new string("SEVEN");
    case 8:
        return new string("EIGHT");
    case 9:
        return new string("NINE");
    default:
        return new string("");
    }
}

string Teens(double input) {
    switch(input) {
    case 1:
        return new string("ELEVEN");
    case 2:
        return new string("TWELVE");
    case 3:
        return new string("THIRTEEN");
    case 4:
        return new string("FOURTEEN");
    case 5:
        return new string("FIFTEEN");
    case 6:
        return new string("SIXTEEN");
    case 7:
        return new string("SEVENTEEN");
    case 8:
        return new string("EIGHTTEEN");
    case 9:
        return new string("NINETEEN");
    default:
        return new string("");
    }
}

string Tens(double input) {
    switch(input) {
    case 1:
        return new string("TEN");
    case 2:
        return new string("TWENTY");
    case 3:
        return new string("THIRTY");
    case 4:
        return new string("FOURTY");
    case 5:
        return new string("FIFTY");
    case 6:
        return new string("SIXTY");
    case 7:
        return new string("SEVENTY");
    case 8:
        return new string("EIGHTTY");
    case 9:
        return new string("NINETY");
    default:
        return new string("");
    }
}