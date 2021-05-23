using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem
{
    public class Book
    {
        private int id;
        private string name;
        private string author;
        private string category;

        public Book(int id, string name, string author, string category)
        {
            this.id = id;
            this.name= name;
            this.author = author;
            this.category = category;
        }

        public int ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Author { get => author; set => author = value; }
        public string Category{ get => category; set => category = value; }
    }
}