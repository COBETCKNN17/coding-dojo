from flask import Flask, render_template, request, redirect, session, flash
import time
import re

from mysqlconnection import connectToMySQL
app = Flask(__name__)

app.secret_key = 'IsoscelesTriangle'

mysql = connectToMySQL('emails')

@app.route('/')
def index():
    return render_template('index.html')

@app.route('/process', methods=['POST'])
def create():
    email = request.form['email']
    query = "INSERT INTO email_list (email, created_at) VALUES (%(email)s, NOW());"
    data = {'email': email}
    check = "SELECT * FROM email_list"
    print mysql.query_db(query,check)
    status = True

    emailCheck = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')
    for i in (mysql.query_db(check)):
        if i['email'] == email:
            flash("This email is already in use.")
            status = False
            return redirect('/')
        if not emailCheck.match(email):
            flash("Not a valid email address.")
            status = False
            return redirect('/')
    if status == True:
        flash("The email address you entered is valid. Thank you!")
        mysql.query_db(query,data)
        return redirect('/success')
    return redirect('/')

@app.route('/success')
def success():
    query = "SELECT email, created_at FROM email_list"
    email = mysql.query_db(query)
    return render_template("success.html", email_list = email)

app.run(debug=True)