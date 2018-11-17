from flask import Flask, request
from flask_restful import Resource, Api
from json import dumps

app = Flask(__name__)
api = Api(app)

class Accounts(Resource):
    def get(self, id):
        return {'id': id, 'name': 'John Doe #' + id, 'buyLimit': 1000 }

api.add_resource(Accounts, '/api/accounts/<id>')

if __name__ == '__main__':
     app.run(host='0.0.0.0', port='80')