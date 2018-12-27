using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class ColumnPosition
    {
        public int Id { get; set; }

        public int Position { get; set; }

        public int ColumnId { get; set; }
        public Column Column { get; set; }

        public int BoardId { get; set; }
        public Board Board { get; set; }
    }
}
