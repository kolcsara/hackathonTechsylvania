from flask import Flask
from flask import request

app = Flask(__name__)




@app.route('/')
def index():
	return '<h1>Hello PinkyBanking!</h1>'

@app.route('/hello2')
def hello():
    return 'Hello, World'
	
@app.route('/user/<username>')
def show_user_profile(username):
    # show the user profile for that user
    return 'User %s' % username

@app.route('/post/<int:post_id>')
def show_post(post_id):
    # show the post with the given id, the id is an integer
    return 'Post %d' % post_id

@app.route('/path/<path:subpath>')
def show_subpath(subpath):
    # show the subpath after /path/
    return 'Subpath %s' % subpath


@app.route('/projects/')
def projects():
    return 'The project page'

@app.route('/about')
def about():
    return 'The about page'
	

@app.route('/login', methods=['GET', 'POST'])
def login():
    if request.method == 'POST':
        return 'The project page'
    else:
        variable = get_user_by_fingerprint("finger1")
        return variable

@app.route('/register/<username>/<fingerprint>', methods=['POST'])
def register_user(username, fingerprint):
	if get_user_by_fingerprint(fingerprint) == "0":
		add_user_and_fingerprint(username, fingerprint)
		return fingerprint
	return username

@app.route('/transaction/<username1>/<fingerprint>/<amount>', methods=['POST'])
def create_transaction(username1, fingerprint, amount):
	username2 = get_user_by_fingerprint(fingerprint)
	print(username2)
	if username2 == "0":
		return "0"
	f = open("transactions.csv", "a")
	f.write(username1 + "," + username2 + "," +  amount +"\n")
	f.close()
	return username2


@app.route('/transaction/<username2>', methods=['GET'])
def get_transaction(username2):
	filepath = 'transactions.csv'
	with open(filepath) as fp:
		for cnt, line in enumerate(fp):
			if len(line.split(",")) > 1 :
				user1,user2,amount = line.split(",")
				if int(user2) == int(username2) :
					return amount
	return "0"

def get_user_by_fingerprint(fingerprint):
	print(fingerprint)
	filepath = 'users.csv'
	with open(filepath) as fp:
		for cnt, line in enumerate(fp):
			if len(line.split(",")) > 1 :
				user,amprenta = line.split(",")
				if int(fingerprint) == int(amprenta) :
					return user
	return "0"

def add_user_and_fingerprint(userid, fingerprint):
	f = open("users.csv", "a")
	f.write(userid + "," + fingerprint + "\n")
	f.close()
	

	



 
	



	

	
