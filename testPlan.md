# Numbers To Words Application Test Plan

## 1. Overview
This test plan is designed to verify that the numbers to words application correctly converts numerical inputs (including decimals, negatives, and large numbers) into their English word equivalents. It also includes testing for dollars and cents formatting.

---

## 2. Test Cases

| Test Case # | Description | Input | Expected Output | Notes |
|-------------|-------------|-------|-----------------|-------|
| 1  | Single digit zero | 0 | ZERO DOLLARS   |  |
| 2  | Multiple digit zero | 00 | ZERO DOLLARS |  |
| 3  | Zero with decimal | 0.1 | ZERO DOLLARS TEN CENTS | handling between zero and one |
| 4  | Single digit | 5 | FIVE DOLLARS |  |
| 5  | Single tens  | 10 | TEN DOLLARS |  |
| 6  | Teen | 13 | THIRTEEN DOLLARS |  |
| 7  | Two-digit tens | 42 | FORTY TWO DOLLARS | Tens + ones |
| 8  | Three-digit number | 123 | ONE HUNDRED TWENTY THREE DOLLARS | Hundreds, tens, ones |
| 9  | Negative number | -7 | NEGATIVE SEVEN DOLLARS | Negative handling |
| 10 | Negative decimal | -0.56 | NEGATIVE ZERO DOLLARS FIFTY SIX CENTS |  |
| 11 | Decimal number | 2.02 | TWO DOLLARS TWO CENTS |  |
| 12 | Thousands | 1001 | ONE THOUSAND ONE DOLLARS |  |
| 13 | Larger numbers | 123456 | ONE HUNDRED TWENTY THREE THOUSAND FOUR HUNDRED FIFTY SIX DOLLARS |  |
| 14 | Million | 1000000 | ONE MILLION DOLLARS | |
| 15 | Billion scale | 1000000000 | ONE BILLION DOLLARS |  |
| 16 | Trillion scale | 1000000000000 | ONE TRILLION DOLLARS |  |
| 17 | Trillion with cents | 1000000000000.1 | ONE TRILLION DOLLARS TEN CENTS |  |
| 18 | Trailing zero decimal | 1.50 | ONE DOLLAR FIFTY CENTS |  |
| 19 | Large negative | -987654321 | NEGATIVE NINE HUNDRED EIGHTY SEVEN MILLION SIX HUNDRED FIFTY FOUR THOUSAND THREE HUNDRED TWENTY ONE DOLLARS |  |
| 20 | Max whole digits | 999999999999 | NINE HUNDRED NINETY NINE BILLION NINE HUNDRED NINETY NINE MILLION NINE HUNDRED NINETY NINE THOUSAND NINE HUNDRED NINETY NINE DOLLARS | |
| 21 | One dollar | 1 | ONE DOLLAR | Test DOLLAR not DOLLARS |
| 22 | One dollar and cents | 1.5 | ONE DOLLAR AND FIFTY CENTS |  |
| 23 | One cent | 5.01 | FIVE DOLLARS ONE CENT |  |
| 24 | Two cents | 5.02 | FIVE DOLLARS TWO CENTS | |
| 25 | One dollar and one cent | 1.01 | ONE DOLLAR ONE CENT | |
|Error / Edge Cases |  |  |  |  |
| 26  | Decimal with multiple digits | 12.345 | TWELVE DOLLARS THIRTY FOUR CENTS | Multiple decimal digits |
| 27 | Smaller than money | 0.007 | ZERO DOLLARS |  |
| 28 | Max digits with cents | 999999999999.99 | NINE HUNDRED NINETY NINE BILLION NINE HUNDRED NINETY NINE MILLION NINE HUNDRED NINETY NINE THOUSAND NINE HUNDRED NINETY NINE DOLLARS NINETY NINE CENTS |  |

---

## 3. Notes  
- **Negative numbers:** Prefix “NEGATIVE”.  
- **Dollar/s and Cent/s:** Logic to display correct words in the cases its not multiples.
- **Scales:** Thousand, million, billion, trillion supported. Above 999 trillion returns an error.

