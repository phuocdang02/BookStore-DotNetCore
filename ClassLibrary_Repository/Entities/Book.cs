using System;
using System.Collections.Generic;

#nullable disable

namespace ClassLibrary_RepositoryDLL.Entities
{
    public partial class Book
    {
        private int _authorId;
        private int _publisherId;
        private int _categoryId;

        public Book()
        {
            CartItems = new HashSet<CartItem>();
            Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }
        public string Bookname { get; set; }
        public int? AuthorId { get; set; }
        public int? PublisherId { get; set; }
        //public int? AuthorId
        //{
        //    get { return _authorId; }
        //    set { _authorId = Author.Id; }
        //}
        //public int? PublisherId
        //{
        //    get { return _publisherId; }
        //    set { _publisherId = Publisher.Id; }
        //}
        public double? Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }

        public int? CategoryId { get; set; }
        //public int? CategoryId
        //{
        //    get { return _categoryId; }
        //    set { _categoryId = Category.Id; }
        //}
        public int? StorageQuantity { get; set; }

        public virtual Author Author { get; set; }
        public virtual Category Category { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}