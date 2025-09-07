var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/api/decode", (double input) => {
    return new { result = DecodeInput(input) };
});

app.UseDefaultFiles(); 
app.UseStaticFiles();

app.Run();

string DecodeInput(double input) {
    if (input == 0) return "ZERO";
    string output = "";
    bool negFlag = false;
    if (input < 0) {
        negFlag = true;
        input = Math.Abs(input);
    }
    if (input > 999999999999999) return "INPUT TOO LARGE (OVER 100 TRILLION)";

    string[] parts = input.ToString().Split('.');
    var digits = parts[0].Select(c => int.Parse(c.ToString())).ToArray();
    var decimals = parts.Length > 1
        ? parts[1].Select(c => int.Parse(c.ToString())).ToArray()
        : Array.Empty<int>();

    string[] scales = { "", "THOUSAND", "MILLION", "BILLION", "TRILLION" };
    int groupCount = 0;
    int position = digits.Length;
    // Checking in groups of three
    for (int i = digits.Length; i > 0; i -= 3) {
        // Make sure doest start in a negative
        int start = Math.Max(i - 3, 0);
        int length = i - start;
        var group = digits.Skip(start).Take(length).ToArray();
        string groupWords = ProcessGroup(group);
        if (groupWords != "") {
            output = groupWords + (scales[groupCount] != "" ? " " + scales[groupCount] + " " : " ") + output;
        }
        groupCount++;
    }

    if (decimals.Length > 0) {
        output += "DOLLARS AND ";
        if (decimals.Length == 2) {
            if (decimals[0] == 1 && decimals[1] != 0) {
                output += Teens(decimals[1]);
            } else {
                output += Tens(decimals[0]) + " " + Ones(decimals[1]);
            }
        } else {
            output += Ones(decimals[0]);
        }
        output += " CENTS";
    } else {
        output += "DOLLARS";
    }

    if (negFlag) output = "NEGATIVE " + output;
    return output;
}

string ProcessGroup(int[] digits) {
    string result = "";
    for (int i = 0; i < digits.Length; i++) {
        int position = digits.Length - i;
        if (position == 3 && digits[i] != 0) {
            result += Ones(digits[i]) + " HUNDRED ";
        } else if (position == 2) {
            if (digits[i] == 1 && digits[i+1] != 0) {
                result += Teens(digits[i+1]) + " ";
                break; // Handles two positions, so skip ahead
            } else {
                result += Tens(digits[i]) + " ";
            }
        } else if (position == 1 && digits[i] != 0) {
            result += Ones(digits[i]) + " ";
        }
    }
    return result;
}

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