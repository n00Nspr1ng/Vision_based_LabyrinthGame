FROM python:3.9

RUN mkdir /app
WORKDIR /app/

COPY ./common/ /app/common/
COPY ./control/ /app/control/
COPY ./requirements.txt /app/
COPY ./main.py /app/

RUN pip3 install -r requirements.txt

CMD ["python3", "-u","/app/main.py"]