FROM python:3.6-alpine
EXPOSE 80
WORKDIR /app

RUN pip install --no-cache-dir flask-restful

COPY . .
CMD ["python", "./app.py"]