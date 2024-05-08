namespace NibbleToHex;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Input binary string:");
        string? str = Console.ReadLine();
        Console.WriteLine($"Output hex string: {BinaryToHex(str!)}");
    }

    static char NibbleToHex(string nibble)
    {
        int d1 = nibble[0] - '0';
        int d2 = nibble[1] - '0';
        int d3 = nibble[2] - '0';
        int d4 = nibble[3] - '0';

        int nibbleValue = d1 * 8 + d2 * 4 + d3 * 2 + d4 * 1;

        char hexDigit;

        if (nibbleValue < 10)
        {
            hexDigit = (char)('0' + nibbleValue);
        }
        else
        {
            hexDigit = (char)('A' + nibbleValue - 10);
        }

        return hexDigit;
    }

    static string BinaryToHex(string binary)
    {
        List<string> nibbles = new();

        while (binary.Length % 4 != 0)
        {
            binary = '0' + binary;
        }

        while (binary.Length != 0)
        {
            string currentNibble = string.Empty;
            for (int i = 0; i < 4; ++i)
            {
                currentNibble += binary[i];
            }

            nibbles.Add(currentNibble);

            string newBinary = string.Empty;
            for (int i = 4; i < binary.Length; ++i)
            {
                newBinary += binary[i];
            }

            binary = newBinary;
        }

        string hex = string.Empty;

        foreach (string str in nibbles)
        {
            hex += NibbleToHex(str);
        }

        return hex;
    }
}

