from __future__ import unicode_literals
from django.shortcuts import render, HttpResponse, redirect
from django.contrib import messages

Items=[
	{'id':'1','price':'9.99'},
	{'id':'2','price':'13.99'},
	{'id':'3','price':'62.99'},
	{'id':'4','price':'29.99'}
]

def index(request):
	request.session.modified = True
	return render(request,'amadon_app/index.html')

def process(request):
	for item in Items:
		if request.POST['item_id']==item['id']:
			total=int(request.POST['quantity'])*float(item['price'])

	request.session['sub_total'] = total
	request.session['total'] = total + request.session['total']
	request.session.modified = True
	return redirect('/purchase_confirmation')

def purchase_confirmation(request):
	return render(request,'amadon_app/purchase_confirmation.html')
