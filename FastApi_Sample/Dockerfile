    FROM python:3.8.10

    #Create working directory 
    WORKDIR /code

    #Copy and install all the requirements from our VENV
    COPY ./requirements.txt /code/requirements.txt

    #Sin caché
    RUN pip install --no-cache-dir --upgrade -r /code/requirements.txt


    COPY ./app /code/app

    CMD [ "uvicorn","app.main:app" ]