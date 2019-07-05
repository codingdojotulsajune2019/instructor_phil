from flask import Flask, render_template

app = Flask(__name__)

print(__name__)
# '__main__'
print('__main__')
# name of file

# root route
@app.route('/')
def index():
    print('in index method')
    return 'a message from the index method'

@app.route('/dogs')
def dog_picture():
    dog_one = "pit bull"
    return render_template('dogs.html', dog_info = dog_one)

if __name__ == '__main__':
    app.run(debug = True)
# default port localhost:5000