﻿using System;
using System.Collections.Generic;
using BooksApi.Model;

namespace BooksApi.DB
{
    public class Database
    {
        private List<User> userList;
        private List<Author> authorList;
        private List<Book> bookList;
        private List<Cart> carts;

        private static Database database = null;

        private Database()
        {
            userList = new List<User>();
            authorList = new List<Author>();
            bookList = new List<Book>();
            carts = new List<Cart>();
            createUsers();
            createAuthors();
            createBooks();
        }

        public static Database getInstance()
        {
            if (database == null)
            {
                database = new Database();
            }
            return database;
        }

        public User getUser(String email, String password)
        {
            foreach(User user in userList)
            {
                if (user.email.Equals(email) && user.password.Equals(password))
                {
                    return user;
                }
            }
            return null;
        }

        public bool isUser(String email, String password)
        {
            foreach (User user in userList)
            {
                if (user.email.Equals(email) && user.password.Equals(password))
                {
                    return true;
                }
            }
            return false;
        }

        public List<Author> getAuthors()
        {
            return authorList;
        }

        public List<User> getUsers()
        {
            return userList;
        }

        public List<Book> getBooks()
        {
            return bookList;
        }

        public List<Book> searchBookByAuthor(String searchText)
        {

            List<Book> resultList = new List<Book>();
            foreach (var book in bookList)
            {
                if (book.author.fullName.ToLower().Contains(searchText))
                {
                    resultList.Add(book);
                }
            }
             return resultList;
        }

        public List<Book> searchBookbyName(String searchText)
        {
            List<Book> resultList = new List<Book>();
            foreach(Book book in bookList)
            {
                if (book.name.ToLower().Contains(searchText))
                {
                    resultList.Add(book);
                }
            }
            return resultList;
        }

        public Book getBookById(String id)
        {
            foreach (var book in bookList)
            {
                if (book.ID.Equals(id))
                {
                    return book;
                }
            }
            return null;
        }
        public bool addCartItem(String userId, String bookId)
        {
            foreach (var cart in carts)
            {
                if (cart.user.ID.Equals(userId))
                {
                    foreach (var book in bookList)
                    {
                        if (book.ID.Equals(bookId))
                        {
                            cart.books.Add(book);
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public List<Book> getUserBooks(string userId)
        {
            foreach (var item in carts)
            {
                if (item.user.ID.Equals(userId))
                {
                    return item.books;
                }
            }
            return new List<Book>();
        }

        public bool newUser(string firstname, string lastname, string email, string password)
        {
            foreach (User user in userList)
            {
                if (user.email.Equals(email)) return false;
            }
            User user1 = new User(Guid.NewGuid().ToString(), firstname, lastname, email, password);
            userList.Add(user1);
            carts.Add(new Cart(user1, new List<Book>()));
            return true;
        }

        private void createAuthors()
        {
            authorList.Add(new Author(Guid.NewGuid().ToString(), "Jane Austen", new DateTime(1775, 12, 16)));
            authorList.Add(new Author(Guid.NewGuid().ToString(), "Charlotte Brontë", new DateTime(1816, 6, 21)));
            authorList.Add(new Author(Guid.NewGuid().ToString(), "Charles Dickens", new DateTime(1812, 2, 7)));
            authorList.Add(new Author(Guid.NewGuid().ToString(), "Thomas Hardy", new DateTime(1840, 6, 2)));
            authorList.Add(new Author(Guid.NewGuid().ToString(), "Oscar Wilde", new DateTime(1854, 10, 16)));
            authorList.Add(new Author(Guid.NewGuid().ToString(), "Mark Twain", new DateTime(1835, 11, 30)));
            authorList.Add(new Author(Guid.NewGuid().ToString(), "Leo Tolstoy", new DateTime(1828, 9, 9)));
        }

        private void createUsers()
        {
            User user1 = new User(Guid.NewGuid().ToString(), "saba", "pochkhua", "sabuna@mail.com", "123");
            userList.Add(user1);
            carts.Add(new Cart(user1, new List<Book>()));

            User user2 = new User(Guid.NewGuid().ToString(), "bob", "marley", "bob@mail.com", "123");
            userList.Add(user2);
            carts.Add(new Cart(user2, new List<Book>()));
        }

        private void createBooks()
        {
            // Jane Austen Books
            Author janeAusten = null;
            Author oscarWild = null;
            Author leoTolstoy = null;
            foreach (Author author in authorList)
            {
                if (author.fullName.Equals("Jane Austen"))
                {
                    janeAusten = author;
                } else if (author.fullName.Equals("Oscar Wilde"))
                {
                    oscarWild = author;
                } else if (author.fullName.Equals("Leo Tolstoy"))
                {
                    leoTolstoy = author;
                }

            }
            bookList.Add(new Book(Guid.NewGuid().ToString(), "Pride and Prejudice", janeAusten,
                "Drama", "Pride and Prejudice, romantic novel by Jane Austen, published anonymously in three volumes in 1813. " +
                "A classic of English literature, written with incisive wit and superb character delineation, it centres on the " +
                "turbulent relationship between Elizabeth Bennet, the daughter of a country gentleman, and Fitzwilliam Darcy, " +
                "a rich aristocratic landowner.",  20.99, new DateTime(1813, 1, 28), 0, "PrideAndPrejudice.jpg"));

            bookList.Add(new Book(Guid.NewGuid().ToString(), "Emma", janeAusten, "Novel",
                "Emma is a comedy of errors full of misunderstandings, misguided plans and a heroine who Austen merrily pokes fun at. " +
                "It has a fair amount in common with Pride and Prejudice, but Emma is a less obviously likeable heroine than Lizzy, who " +
                "is somewhat deluded in her matchmaking schemes. But this makes for the novel’s real joy; enjoying the incredibly clever way " +
                "Austen contrasts what we know to be true about Emma with how she herself perceives her own story.",
                22.99, new DateTime(1996, 7, 7), 0, "Emma.jpg"));

            bookList.Add(new Book(Guid.NewGuid().ToString(), "Sense and Sensibility", janeAusten, "Novel",
                "Marianne Dashwood wears her heart on her sleeve, and when she falls in love with the dashing but unsuitable John Willoughby she " +
                "ignores her sister Elinor's warning that her impulsive behaviour leaves her open to gossip and innuendo. Meanwhile Elinor, always " +
                "sensitive to social convention, is struggling to conceal her own romantic disappointment, even from those closest to her. Through their " +
                "parallel experience of love - and its threatened loss - the sisters learn that sense must mix with sensibility if they are to find personal " +
                "happiness in a society where status and money govern the rules of love.", 19.55, new DateTime(1811, 10, 30), 0, "SenseAndSensibility.jpeg"));

            bookList.Add(new Book(Guid.NewGuid().ToString(), "The Picture of Dorian Gray", oscarWild, "Fiction",
                "The Picture of Dorian Gray is a Gothic and philosophical novel by Oscar Wilde, first published complete in the July 1890 issue of Lippincott's " +
                "Monthly Magazine. Fearing the story was indecent, prior to publication the magazine's editor deleted roughly five hundred words without Wilde's " +
                "knowledge.", 19.99, new DateTime(1890, 1, 1), 0, "ThePictureOfDorianGray.jpg"));

            bookList.Add(new Book(Guid.NewGuid().ToString(), "The Canterville Ghost", oscarWild, "Dark Comedy",
                "The Canterville Ghostis a humorous short story by Oscar Wilde. It was the first of Wilde's stories to be published, appearing in two parts in The " +
                "Court and Society Review, 23 February and 2 March 1887.", 15.60, new DateTime(1944, 7, 28), 0, "TheCantervilleGhost.jpg"));

            bookList.Add(new Book(Guid.NewGuid().ToString(), "War and Peace", leoTolstoy, "Novel",
                "War and Peace is a novel by the Russian author Leo Tolstoy, first published serially, then published in its entirety in 1869.It is regarded as one of " +
                "Tolstoy's finest literary achievements and remains a classic of world literature.", 39.99, new DateTime(1867, 1, 1), 0, "WarAndPeace.jpg"));

            bookList.Add(new Book(Guid.NewGuid().ToString(), "Anna Karenina", leoTolstoy, "Fiction", "" +
                "Acclaimed by many as the world's greatest novel, Anna Karenina provides a vast panorama of contemporary life in Russia and of humanity in general. In it " +
                "Tolstoy uses his intense imaginative insight to create some of the most memorable characters in all of literature. Anna is a sophisticated woman who abandons " +
                "her empty existence as the wife of Karenin and turns to Count Vronsky to fulfil her passionate nature - with tragic consequences. Levin is a reflection of Tolstoy " +
                "himself, often expressing the author's own views and convictions.", 27.55, new DateTime(1877, 1, 1), 0, "AnnaKarenina.jpg"));
        }
    }
}
