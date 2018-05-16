from __future__ import unicode_literals
from django.shortcuts import render, HttpResponse, redirect
from .models import *

def index(request):
    return render (request, "belt/index.html")

def register(request):
    if request.method == "POST":
        User.objects.register(request.POST)
        return redirect("/")

def login(request):
    pass