    using System.Numerics;
    
    public static string GetDataType(BigInteger x, string language)
    {
        /*
          A method to return the smallest type you can fit a given value in.  Useful for choosing your datatype
          in arrays or lists of large production data sets
        */
        bool isNegative = false;
        if (x.Sign == -1)
            isNegative = true;
        string output;

        // arrays of data type ceilings and data type keywords
        ulong[] maxValues = {(ulong)sbyte.MaxValue, byte.MaxValue, (ulong)short.MaxValue,
        ushort.MaxValue, int.MaxValue, uint.MaxValue, long.MaxValue, ulong.MaxValue };
        String[] cSharpTypes = { "sbyte", "byte", "short", "ushort", "int", "uint", "long", "ulong", "BigInteger" };
        String[] javaTypes = { "byte", "short", "short", "int", "int", "long", "long", "BigInteger", "BigInteger" };

        int pos = -1;
        int compare = 0;

        for (byte i = 0; i < maxValues.Length + 1; i++)
        {
            // prevent running off the end of the array, if too big, use BigInteger (pos 8)
            if (i == 8)
            {
                pos = 8;
                break;
            }
            else
                // see if BigInteger is smaller than the next size category ceiling
                compare = BigInteger.Compare(BigInteger.Abs(x), maxValues[i]);

            if (compare < 1 && !isNegative)
            {
                pos = i;
                break;
            }
            else if (compare < 1 && i % 2 == 0 && isNegative)
            {
                pos = i;
                break;
            }
            else if (compare < 1 && i % 2 == 1 && isNegative)
            {
                pos = i + 1;
                break;
            }

        }

        // check language, and output data type
        language = language.ToLower();
        if (language == "java")
            output = javaTypes[pos];
        else if (language == "c#" || language == "csharp")
            output = cSharpTypes[pos];
        else
            output = "The only currently supported languages are C# and Java";

        return output;
    }
