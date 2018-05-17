from __future__ import unicode_literals
from django.db import models
from django.contrib import messages
from django.contrib.messages import get_messages
import re
import bcrypt

#Email validation REGEX

emailREGEX = re.compile(r'^[a-zA-Z0-9\.\+_-]+@[a-zA-Z0-9\._-]+\.[a-zA-Z]*$')

#Class that validates user creation and creates a new user, if all validation passes. Also contains login validation, but we did that in the views file instead.

class userManager(models.Manager):
    def register(self,request):

        if len(request.POST["name"]) < 1:
			messages.add_message( request, messages.ERROR, "Name is required!" )
        if len(request.POST["email"]) < 1:
			messages.add_message( request, messages.ERROR, "Email is required!" )
        if not emailREGEX.match( request.POST["email"] ):
			messages.add_message( request, messages.ERROR, "Invalid email format! Ex: test@test.com" )
        if len(request.POST["password"]) < 8:
			messages.add_message( request, messages.ERROR, "Password must be between 8-32 characters!" )
        if request.POST["password"] != request.POST["confirm_password"]:
			messages.add_message( request, messages.ERROR, "Password and Password Confirmation must match!" )
        if User.objects.filter(email=request.POST["email"]).count() > 0:
			messages.add_message( request, messages.ERROR, "A user with this email already exists!" )
#If there are error messages at the end, return false.
        if len(get_messages(request)) > 0:
            return False
#Else, create the user and hash the password.
        else:

            User.objects.create(
                name = request.POST["name"],
                email = request.POST["email"],
                password = bcrypt.hashpw(request.POST["password"].encode(), bcrypt.gensalt())
            )
            return True

    def login(self,request):
        pass

#User Model

class User(models.Model):
    name = models.CharField(max_length=255)
    email = models.CharField(max_length=255)
    password = models.CharField(max_length=255)
    objects = userManager()

#Author Model

class Author(models.Model):
    name = models.CharField(max_length=255)

#Book Model

class Book(models.Model):
    title = models.CharField(max_length=255)
    author = models.ForeignKey(Author, related_name="book") #One author can have many books

#Review Model

class Review(models.Model):
    review_text = models.TextField(max_length=1000)
    rating = models.IntegerField()
    user = models.ForeignKey(User, related_name="user_reviews") #One user can have many reviews
    book = models.ForeignKey(Book, related_name="book_reviews") #One book can have many reviews
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)