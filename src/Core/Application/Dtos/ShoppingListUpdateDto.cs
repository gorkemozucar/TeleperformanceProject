using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class ShoppingListUpdateDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public string Note { get; set; }
        public bool IsCompleted { get; set; }

    }
}
