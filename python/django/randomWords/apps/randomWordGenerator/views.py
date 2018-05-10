# -*- coding: utf-8 -*-
from __future__ import unicode_literals
from django.utils.crypto import get_random_string

from django.shortcuts import render, redirect

def index(request):
    if 'attempt' not in request.session:
        request.session['attempt'] = 0
    dictionary = {
        'attempt' : request.session['attempt'],
        'randomWord': get_random_string(length=14)
    }
    return render(request, 'randomWordGenerator/index.html', dictionary)

def create(request):
    request.session['attempt'] +=1
    return redirect('/')

def reset(request):
    request.session['attempt'] = 1
    return redirect('/')