# Note: Avoid using class keywords like int, str, list, and dict as variable/parameter names.

# Update Values in Dictionaries and Lists
x = [ [5,2,3], [10,8,9] ] 

students = [
     {'first_name':  'Michael', 'last_name' : 'Jordan'},
     {'first_name' : 'John', 'last_name' : 'Rosales'}
]
sports_directory = {
    'basketball' : ['Kobe', 'Jordan', 'James', 'Curry'],
    'soccer' : ['Messi', 'Ronaldo', 'Rooney']
}
z = [ {'x': 10, 'y': 20} ]

# print(x[0][1])
# print(type(x[0]))

# 1. Change the value 10 in x to 15. Once you're done, x should now be [ [5,2,3], [15,8,9] ].
# x[1][0]=15
# print(x)

# 2. Change the last_name of the first student from 'Jordan' to 'Bryant'
# print(type(students[0]))
# print(students[0]['last_name'])
# students[0]['last_name']="Bryant"
# print(students)

# 3. In the sports_directory, change 'Messi' to 'Andres'
# print(type(sports_directory))
# print(sports_directory)
# sports_directory['soccer'][0] = 'Andres'
# print(sports_directory)

# 4. Change the value 20 in z to 30
# print(z[0]['y'])
# z[0]['y']=30
# print(z)

# Iterate Through a List of Dictionaries
# Create a function iterateDictionary(some_list) that, given a list of dictionaries, the function loops through each dictionary in the list and prints each key and the associated value. For example, given the following list:

students = [
         {'first_name':  'Michael', 'last_name' : 'Jordan'},
         {'first_name' : 'John', 'last_name' : 'Rosales'},
         {'first_name' : 'Mark', 'last_name' : 'Guillen'},
         {'first_name' : 'KB', 'last_name' : 'Tonel'}
    ]

def iterateDictionary(stud):
    # print(type(stud))
    #**************** option 1 *******************
    for s in stud:
        print(f"first_name - {s['first_name']}, last_name - {s['last_name']}")
        print(s["last_name"])
        print(type(s))
        print('-'*50)
    #**************** option 2 *******************
    # for i in range(len(stud)):
    #     # print(i)
    #     # print(stud[i])
    #     print('-'*40)
    #     result=''
    #     count=1
    #     for key, value in stud[i].items():
    #         result += f'{key} - {value}'
    #         if count == 1:
    #             result += ", "
    #         count-=1
    #     print(result)

# iterateDictionary(students)
# should output: (it's okay if each key-value pair ends up on 2 separate lines;
# bonus to get them to appear exactly as below!)
# first_name - Michael, last_name - Jordan
# first_name - John, last_name - Rosales
# first_name - Mark, last_name - Guillen
# first_name - KB, last_name - Tonel


# Get Values From a List of Dictionaries
# Create a function iterateDictionary2(key_name, some_list) that, given a list of dictionaries and a key name, the function prints the value stored in that key for each dictionary. For example, iterateDictionary2('first_name', students) should output:
# Michael
# John
# Mark
# KB

# And iterateDictionary2('last_name', students) should output:
# Jordan
# Rosales
# Guillen
# Tonel

def iterateDictionary2(key_name, some_list):
    # print(some_list)
    for item in some_list:
        print(item[key_name])

# iterateDictionary2('last_name', students)

# Iterate Through a Dictionary with List Values
# Create a function printInfo(some_dict) that given a dictionary whose values are all lists, prints the name of each key along with the size of its list, and then prints the associated values within each key's list. For example:

dojo = {
   'locations': ['San Jose', 'Seattle', 'Dallas', 'Chicago', 'Tulsa', 'DC', 'Burbank'],
   'instructors': ['Michael', 'Amy', 'Eduardo', 'Josh', 'Graham', 'Patrick', 'Minh', 'Devon']
}

def printInfo(dojo):
    for key, value in dojo.items():
        print(len(value), key.upper())
        for inner_val in value:
            print(inner_val)



printInfo(dojo)

# output:
# 7 LOCATIONS
# San Jose
# Seattle
# Dallas
# Chicago
# Tulsa
# DC
# Burbank
    
# 8 INSTRUCTORS
# Michael
# Amy
# Eduardo
# Josh
# Graham
# Patrick
# Minh
# Devon