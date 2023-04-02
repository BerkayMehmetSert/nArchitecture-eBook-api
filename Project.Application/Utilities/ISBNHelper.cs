using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Utilities
{
    public class ISBNHelper
    {
        public static string CalculateISBN()
        {
            var random = new Random();
            var isbn = new StringBuilder();
            for (int i = 0; i < 13; i++)
            {
                isbn.Append(random.Next(0, 9));
            }
            return isbn.ToString();
        }
    }
}
