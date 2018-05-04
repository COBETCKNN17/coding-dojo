from flask import Flask, render_template, request, redirect

app = Flask(__name__)

@app.route('/')
def root():
    return render_template("index.html")

@app.route('/result', methods=['GET', 'POST'])
def process():
    name = request.form['name']
    location = request.form['location']
    favLanguage = request.form['favLanguage']
    comment = request.form['comment']
    redirect("/")
    return render_template("result.html", name = name, location = location, favLanguage = favLanguage, comment = comment)



app.run(debug = True)