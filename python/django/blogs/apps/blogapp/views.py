from django.shortcuts import render, HttpResponse, redirect
  # the index function is called when root is visited

def index(request):
    context = {
        "email" : "blog@gmail.com",
        "name" : "mike"
    }
    return render(request, "blogapp/index.html", context)

'''  
def index(request):
    response = "Blog App Main Page"
    return HttpResponse(response)
'''

def new(request):
    response = "Create new blog."
    return HttpResponse(response)

def create(request):
    if request.method == "POST":
        print("*"*50)
        print(request.POST)
        print(request.POST['name'])
        print(request.POST['desc'])
        request.session['name'] = "test"  # more on session below
        print("*"*50)
        return redirect("/")
    else:
        return redirect("/")

def show(request, number):
    response = 'Display Blog Number {}'.format(number)
    return HttpResponse(response)

def edit(request, number):
    response = "Edit Blog Number {}".format(number)
    return HttpResponse(response)

def destroy(request, number):
    return redirect('/')