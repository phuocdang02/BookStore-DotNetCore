﻿using ClassLibrary_RepositoryDLL.Entities;
using ClassLibrary_RepositoryDLL.Repository;
using ClassLibrary_RepositoryDLL.Services.Admin.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_RepositoryDLL.Services.Admin
{
    public class BookManagementService : IBookManagementService
    {
        readonly BookRepository _bookRepo;
        readonly AuthorRepository _authorRepo;
        readonly CategoryRepository _cateRepo;
        readonly PublisherRepository _publishRepo;
        public BookManagementService(BookRepository bookRepo, AuthorRepository authorRepo, CategoryRepository cateRepo, PublisherRepository publishRepo)
        {
            _bookRepo = bookRepo;
            _authorRepo = authorRepo;
            _cateRepo = cateRepo;
            _publishRepo = publishRepo;
        }

        public List<Book> viewAllBook()
        {
            List<Book> list = _bookRepo.getAllBook();
            return list;
        }

        public void addBook(Book newbook)
        {
            _bookRepo.addBook(newbook);
        }

        public bool updateBook(Book newbook)
        {
            bool result = _bookRepo.updateBook(newbook);
            return result;
        }

        public bool delBook(int bookId)
        {
            bool result = _bookRepo.deleteBook(bookId);
            return result;
        }
        public bool UpdateImage(Book newbook)
        {
            bool result = _bookRepo.updateImage(newbook);
            return result;
        }

        public List<Book> SelectByKeyword(string keyword)
        {
            List<Book> books = _bookRepo.searchBook(keyword);
            return books;
        }

        public List<Book> GetDetailsByAuthorId(int authorId)
        {
            List<Book> books = _bookRepo.selectByAuthorId(authorId);
            return books;
        }

        public List<Book> GetDetailsByCateId(int cateId)
        {
            List<Book> books = _bookRepo.selectByCateId(cateId);
            return books;
        }

        public List<Book> GetDetailsByPubId(int pubId)
        {
            List<Book> books = _bookRepo.selectByPubId(pubId);
            return books;
        }

        public Book viewDetailBook(int bookId)
        {
            Book book = _bookRepo.getDetailBook(bookId);
            return book;
        }

        public Author viewAuthor(int authorId)
        {
            Author author = _authorRepo.getAuthor(authorId);
            return author;
        }

        public void addAuthor(Author newauthor)
        {
            _authorRepo.addAuthor(newauthor);
        }

        public bool updateAuthor(Author newauthor)
        {
            bool result = _authorRepo.updateAuthor(newauthor);
            return result;
        }

        public bool delAuthor(int authorId)
        {
            bool result = _authorRepo.deleteAuthor(authorId);
            return result;
        }

        public bool updatePub(Publisher newPub)
        {
            throw new NotImplementedException();
        }

        public Category viewCategory(int cateId)
        {
            Category category = _cateRepo.getCategory(cateId);
            return category;
        }

        public Publisher viewPublisher(int pubId)
        {
            Publisher publisher = _publishRepo.getDetailPublisher(pubId);
            return publisher;
        }

        public List<Publisher> SearchPub(string keyword)
        {
            throw new NotImplementedException();
        }

        public List<Category> SearchCate(string keyword)
        {
            throw new NotImplementedException();
        }

        public void addCate(Category newcate)
        {
            _cateRepo.addCategory(newcate);
        }

        public bool updateCate(Category newcate)
        {
            bool result = _cateRepo.updateCategory(newcate);
            return result;
        }

        public bool delCate(int categoryId)
        {
            bool result = _cateRepo.deleteCategory(categoryId);
            return result;
        }

        public List<Author> viewAllAuthor()
        {
            List<Author> list = _authorRepo.getAllAuthor();
            return list;
        }

        public List<Publisher> viewAllPub()
        {
            List<Publisher> list = _publishRepo.getAllPublisher();
            return list;
        }

        public void addPublisher(Publisher newpub)
        {
            _publishRepo.addPublisher(newpub);
        }

        public bool delPublisher(int pubId)
        {
            bool result = _publishRepo.deletePublisher(pubId);
            return result;
        }


        public List<Category> viewAllCategory()
        {
            List<Category> list = _cateRepo.getAllCategory();
            return list;
        }

        public List<Author> searchAuthor(string keyword)
        {
            List<Author> list = _authorRepo.searchAuthor(keyword);
            return list;
        }
    }
}