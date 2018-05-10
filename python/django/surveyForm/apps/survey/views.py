# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.shortcuts import render, HttpResponse, redirect

def index(request):
    if 'submit' not in request.session:
        request.session['submit'] = 0
    return render(request, 'survey/index.html')

def process(request):
    if request.method == "POST":
        request.session['name'] = request.POST['name']
        request.session['location'] = request.POST['location']
        request.session['favLanguage'] = request.POST['favLanguage']
        request.session['comment'] = request.POST['comment']
        request.session['submit'] += 1
        return redirect('/result')
    else:
        return redirect('/')
        
def result(request):
    return render(request, 'survey/result.html')