import pika

connection = pika.BlockingConnection(pika.ConnectionParameters('localhost'))
channel = connection.channel()
message = 'Hello World From Python!'
channel.basic_publish(exchange='',
                      routing_key='hello',
                      body=message)
print(" [x] Sent '" + message + "'")

connection.close()