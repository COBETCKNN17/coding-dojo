from django.conf.urls import url
from . import views        
urlpatterns = [
    url(r'^$', views.index),
    url(r'^register$', views.register),
    url(r'^login$', views.login),
    url(r'^books$', views.books),
    url(r'^books/add$', views.addBook),
    url(r'^books/(?P<id>\d+)$', views.showBook),
    url(r'^books/addreview/(?P<id>\d+)$', views.addReview),
    url(r'^books/users/(?P<id>\d+)$', views.showUser),
    url(r'^books/createbook$', views.createBook),
    url(r'^books/addauthor$', views.addAuthor),
    url(r'^books/createauthor$', views.createAuthor),
    url(r'^logout$', views.logout),
]                