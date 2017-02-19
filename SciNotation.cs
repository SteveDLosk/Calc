
    public static string SciNotation(double x, int precision)
    {
    /* a method for converting a double to scientific notation.  Will also cut off unneccesary
    digits, by rounding to a precision level */
    
        String output = "";
        int places = 0;
        bool smallMagnitude;

        // TODO: round to precision
        
        // for numbers bigger in absolute value than 1 integer place
        if (x >= 1 || x <= -1)
        {
            // track shifts of decimal place
            while (x > 10 || x < -10)
            {
                x /= 10;
                places++;
            }
            smallMagnitude = false;
        }
        else
        {
            // for small magnitude numbers
            while (x < 1 && x > -1)
            {
                // track shifts of decimal place
                x *= 10;
                places++;
            }
            smallMagnitude = true;
        }

        // output string.  Small magnitude values are raised to a negative exponent
        if (!smallMagnitude)
            output = x.ToString() + " x 10 ^ " + places;
        else
            output = x.ToString() + " x 10 ^ -" + places;

        return output;
    }
