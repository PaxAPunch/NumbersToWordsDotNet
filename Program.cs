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
        if (input < 0) {
            output = "NEGATIVE ";
            // Change the input to potive for simpler handling
            input = Math.Abs(input);
        }
        // Split number into two at the decimal point e.g. "123" and "45"
        string[] parts = input.ToString().Split('.');
        // Parse the whole digits into an array e.g. [1,2,3]
        var digits = parts[0].Select(c => int.Parse(c.ToString())).ToArray();
        // Parse the decimal digits into an array or return an empty one e.g. [4,5] or []
        var decimals = parts.Length > 1 
            ? parts[1].Select(c => int.Parse(c.ToString())).ToArray()
            : Array.Empty<int>();

        int position = digits.Length;
        for (int i=0; i<=digits.Length-1; i++) {
            if ((position - 2) % 3 == 0) {
                // Teens test in here
                if (digits[i] == 1 && digits[i+1] != 0) {
                    output += Teens(digits[i+1]);
                    i++;
                } else {
                    output += Tens(digits[i]) + " ";
                }
            } else {
                output += Ones(digits[i]) + " ";
            }

            // Do I split it into groups of three and process them in batches?
            
            if (digits[i] != 0) {
                if (position % 3 == 0) {
                    output += "HUNDRED ";
                } else if (position % 4 == 0) {
                    output += "THOUSAND ";
                } else if (position % 7 == 0) {
                    output += "MILLION ";
                } else if (position % 10 == 0) {
                    output += "BILLION ";
                } else if (position % 13 == 0) {
                    output += "TRILLION ";
                }
            }
            position--;
        }

        // Need dollars and cents

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
        return new string("EIGHTEEN");
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
        return new string("FORTY");
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