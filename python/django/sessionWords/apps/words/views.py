# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.shortcuts import render, HttpResponse, redirect
from time import strftime, localtime

def index(request):
	if "wordSubmission" not in request.session:
		request.session["wordSubmission"] = []
	return render(request, "words/index.html")

def add(request):
	if len(request.POST["word"]) < 1:
		return redirect("/")
	if "big" in request.POST:
		size = "2em"
	else:
		size = "1em"

	if "color" in request.POST:
		color = request.POST["color"]
	else:
		color = "black"

	wordSubmission = request.session["wordSubmission"]
	wordSubmission.append({
		"word": request.POST["word"],
		"color": color,
		"size": size,
		"time": strftime("%I:%M:%S %p, %B %d, %Y", localtime()),
		})
	request.session["wordSubmission"] = wordSubmission
	return redirect("/")

def clear(request):
	request.session.clear()
	return redirect("/")