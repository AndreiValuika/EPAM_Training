using BookLib;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using BookLogic;

namespace BookLib
{
    /// <summary>
    /// Containsadditional methods for Book representation.
    /// </summary>
    public class BookFormat : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }
            return null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (!(arg is Book))
            {
                try
                {
                    return HandleOtherFormats(format, arg);
                }
                catch (FormatException ex)
                {
                    throw new FormatException(nameof(ex));
                }
            }
            Book book = arg as Book;

            if (String.IsNullOrEmpty(format))
            {
                return book.ToString();
            }


            switch (format)
            {
                case "IAT":
                    return $"ISBN:{book.ISBN}, {book.ToString("AT", null)}";

                case "ATC":
                    return $"{book.ToString("AT", null)}, Price: {book.Price.ToString(formatProvider)}";

                default:
                    try
                    {
                        HandleOtherFormats(format, arg);
                    }
                    catch (FormatException ex)
                    {
                        throw new FormatException(nameof(ex));
                    }
                    break;
            }

            return book.ToString();
        }

        private string HandleOtherFormats(string format, object arg)
        {
            if (arg is IFormattable)
            {
                return ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);
            }

            if (arg != null)
            {
                return arg.ToString();
            }

            return String.Empty;
        }
    }
}