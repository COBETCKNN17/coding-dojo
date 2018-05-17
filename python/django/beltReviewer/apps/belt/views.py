from __future__ import unicode_literals
from django.shortcuts import render, HttpResponse, redirect, reverse
from .models import Author, User, Book, Review
import re
from django.contrib import messages
import bcrypt

def index(request):
    if 'name' not in request.session:
        return render (request, "belt/index.html")
    else:
        return render (request, "belt/books.html")

def register(request):
	if request.method == "POST":
		User.objects.register(request)
		return redirect("/")
	else:
		return redirect("/")

def login(request):
    try:
        user = User.objects.get ( email=request.POST["email"] )

        isValid = bcrypt.checkpw( request.POST["password"].encode() , user.password.encode() )
        
        if isValid:
            print ("Password match!")
            request.session['name'] = user.name
            request.session['email'] = user.email
            request.session['user_id'] = user.id
            return redirect ("/books")

        else:
            print ("Passwords do NOT match!")
            messages.add_message (request, messages.ERROR, "Invalid Credentials!")
            return redirect("/")
        
    except:
        messages.add_message (request, messages.ERROR, "No user with this email found!")
        return redirect("/")

def books(request):
    if 'name' not in request.session:
        return render (request, "belt/index.html")
    else:
       # authors = Author.objects.all()
       # books = Book.objects.all()
        reviews = Review.objects.all().order_by("-id")[:3]
        otherReviews = Review.objects.all().order_by("-id")[3:]
        return render (request, "belt/books.html", {
            "reviews": reviews,
            "otherReviews": otherReviews,
          #  "books": books,
          #  "authors": authors
        })

def addAuthor(request):
    if 'name' not in request.session:
        return render (request, "belt/index.html")
    else:
        return render (request, "belt/addauthor.html")

def createAuthor(request):
    if request.method == "POST":
        if Author.objects.filter(name=request.POST["name"]).count() > 0:
            messages.add_message( request, messages.ERROR, "An author with this name already exists!" )
            return redirect("/")
        else:
            author = Author.objects.create(
                name = request.POST["name"],
            )
            return redirect("/")
    else:
        return redirect("/")

def addBook(request):
    if 'name' not in request.session:
        return render (request, "belt/index.html")
    else:
        authors = Author.objects.all()
        return render (request, "belt/addbook.html", {
            "authors": authors
        })

def createBook(request):
    if request.method == "POST":
        if Book.objects.filter(title=request.POST["title"]).count() > 0:
            messages.add_message( request, messages.ERROR, "An book with this name already exists!" )
            return redirect("/")
        else:
            book = Book.objects.create(
                title = request.POST["title"],
                author_id = request.POST["author"]
            )

            review = Review.objects.create(
                review_text = request.POST["review"],
                rating = request.POST["rating"],
                user_id = request.session['user_id'],
                book_id = book.id
            )
            return redirect("/")
    else:
        return redirect("/books/add")

def showBook(request, id):
    book = Book.objects.get(id=id) 
    reviews = Review.objects.filter(book_id=id)
    context= {
        "book": book,
        "reviews": reviews,
    }
    return render (request, "belt/showbook.html", context)

def logout(request):
    request.session.clear()
    return redirect("/")