# -*- coding: utf-8 -*-
from __future__ import unicode_literals
from django.db import models
import re
from django.contrib import messages

emailREGEX = re.compile(r'^[a-zA-Z0-9\.\+_-]+@[a-zA-Z0-9\._-]+\.[a-zA-Z]*$')

class userManager(models.Manager):
    def register(self,data):

        if len(data.POST["name"]) < 1:
            messages.add_message( data, messages.error, "Name is required!")
        if len(data.POST["email"]) < 1: 
            messages.add_message( data, messages.error, "Email is required!")
        if not emailREGEX.match(data.POST["email"]):
            messages.add_message( data, messages.error, "Invalid email format!")
        if len(data.POST["password"]) < 8:
            messages.add_message( data, messages.error, "Password must be at least 8 characters!")
        if data.POST["password"] != data.POST["confirm_password"]:
            messages.add_message( data, messages.error, "Password and password confirmation must match!")

        user = User.objects.filter(email=data.POST["email"])

        if len(user) > 0:
            messages.add_message( data, messages.error, "Email is already in use!")

        if len(get_messages(request)) > 0:
            return False

        else:
            User.objects.create(
                name = data.POST["name"],
                email = data.POST["email"],
                password = data.POST["password"],
            )
            return True

    def login(self,data):
        pass

class User(models.Model):
    name = models.CharField(max_length=255)
    email = models.CharField(max_length=255)
    password = models.CharField(max_length=255)
    objects = userManager()
