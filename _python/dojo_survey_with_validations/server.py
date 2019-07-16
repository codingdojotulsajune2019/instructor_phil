from flask import Flask, render_template, redirect, session, flash, request
from mysqlconnection import connectToMySQL

app = Flask(__name__)
app.secret_key = 'My super secret key'

@app.route('/')
def index():
    return render_template('index.html')

@app.route('/process', methods=['post'])
def process():
    print(request.form)
    isValid = True

    name = request.form['name']
    if len(name) < 1:
        #no name was given
        flash('Name is required')
        isValid = False
    # below in neccessary because of the select option in html
    if 'location' in request.form:
        location = request.form['location']
    else:
        print('a location was not given')
        flash('Location is required')
        isValid = False

    if 'language' in request.form:
        language = request.form['language']
    else:
        print('a language was not given')
        flash('Language is required')
        isValid = False

    comment = request.form['comment']
    if len(comment) > 120:
        flash('Comment is too long')
        isValid = False

    print(type(name))

    if isValid:
        mysql = connectToMySQL('dojo_survey')
        query = 'INSERT INTO dojos (name, location, language, comment) VALUES (%(f_name)s, %(f_location)s, %(f_language)s, %(f_comment)s)'
        data = {
            'f_name':name,
            'f_location': location,
            'f_language': language,
            'f_comment': comment
        }
        id_last_created = mysql.query_db(query, data)
        session['dojo_id'] = id_last_created
        return redirect('/success')
    else:
        return redirect('/')

@app.route('/success')
def success():
    if 'dojo_id' in session:
        mysql = connectToMySQL('dojo_survey')
        query = 'SELECT * FROM dojos WHERE dojo_id = %(id_from_session)s;'
        data = {
            'id_from_session': session['dojo_id']
        }
        last_dojo_created = mysql.query_db(query, data)

        return render_template('success.html', dojo = last_dojo_created[0])
    else:
        flash('you missed a step')
        return redirect('/')

@app.route('/clear_session')
def clear_session():
    session.clear()
    return redirect('/')

# Create a new database with a table containing the fields indicated in the wireframe
# Add validations to ensure all fields have a value. Display appropriate validation errors on the survey form if invalid.
# If data is valid, save the information to the database and redirect to a page displaying the information that was just submitted
# NINJA BONUS: Allow the comment field to be optional, but if provided should not exceed 120 characters
# NINJA BONUS: Use a CSS framework to add styling

# SENSEI BONUS: Create separate database tables for location and language and set up the appropriate relationships between ninja, location, and language.
# SENSEI BONUS: Seed the location and language tables and have them populate the form fields. Save the form submission accordingly.




app.run(debug = True)