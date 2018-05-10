from django.shortcuts import render, HttpResponse, redirect
  # the index function is called when root is visited
def index(request):
    response = "Blog App Main Page"
    return HttpResponse(response)

def new(request):
    response = "Create new blog."
    return HttpResponse(response)

def create(request):
    return redirect('/')

def show(request, number):
    response = 'Display Blog Number {}'.format(number)
    return HttpResponse(response)

def edit(request, number):
    response = "Edit Blog Number {}".format(number)
    return HttpResponse(response)

def destroy(request, number):
    return redirect('/')