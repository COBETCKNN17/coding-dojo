from flask import Flask, render_template
app = Flask(__name__)

@app.route('/')
def index():
    return render_template('index.html')

@app.route('/ninja')
def ninja():
    return render_template('all.html')

@app.route('/ninja/<color>')
def ninjaColorPicker(color):
    return render_template("ninjas.html", turtleColor=color)

app.run(debug=True)