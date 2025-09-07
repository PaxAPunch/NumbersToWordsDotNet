var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/api/decode", (double input) => {
    return new { result = DecodeInput(input) };
});

app.UseDefaultFiles(); 
app.UseStaticFiles();

app.Run();

string DecodeInput(double input) {
    string output = "";
    if (input == 0) {
        output = "ZERO ";
    }
    bool negFlag = false;
    if (input < 0) {
        negFlag = true;
        input = Math.Abs(input);
    }
    // Issue here with 1 cent under that.
    if (input >= 1000000000000000) return "INPUT TOO LARGE (OVER 999 TRILLION)";

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
        if (digits.Length == 1 && digits[0] == 0) {
            output += "ZERO DOLLARS AND ";
        } else if (digits.Length == 1 && digits[0] == 1) {
            output += "DOLLAR AND ";
        } else {
            output += "DOLLARS AND ";
        }
        if (decimals.Length == 2) {
            if (decimals[0] == 1 && decimals[1] != 0) {
                output += numToWord(decimals[1], "teens");
            } else {
                output += numToWord(decimals[0], "tens") + " " + numToWord(decimals[1], "ones");
            }
        } else {
            output += numToWord(decimals[0], "tens");
        }
        if (decimals.Length == 2 && decimals[0] == 0 && decimals[1] == 1) {
            output += " CENT";
        } else {
            output += " CENTS";
        }
    } else {
        if (digits.Length == 1 && digits[0] == 1) {
            output += "DOLLAR";
        } else {
            output += "DOLLARS";
        }
    }

    if (negFlag) output = "NEGATIVE " + output;
    return output;
}

string ProcessGroup(int[] digits) {
    string result = "";
    for (int i = 0; i < digits.Length; i++) {
        int position = digits.Length - i;
        if (position == 3 && digits[i] != 0) {
            result += numToWord(digits[i], "ones") + " HUNDRED ";
        } else if (position == 2) {
            if (digits[i] == 1 && digits[i+1] != 0) {
                result += numToWord(digits[i+1], "teens") + " ";
                break; // Handles two positions, so skip ahead
            } else {
                result += numToWord(digits[i], "tens") + " ";
            }
        } else if (position == 1 && digits[i] != 0) {
            result += numToWord(digits[i], "ones") + " ";
        }
    }
    return result;
}

string numToWord(int input, string category) {
    string[] ones = { "", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE" };
    string[] teens = { "", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN" };
    string[] tens = { "", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" };

    switch(category) {
        case "ones":
            return ones[input];
            break;
        case "teens":
            return teens[input];
            break;
        case "tens":
            return tens[input];
            break;
        default:
            return "";
    }
}