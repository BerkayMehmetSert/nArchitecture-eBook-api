using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Request
{
    public class PageRequest
    {
        public int Page { get; set; }
        public int Size { get; set; }

        public PageRequest()
        {

        }

        public PageRequest(int page, int size)
        {
            Page = page;
            Size = size;
        }
    }
}