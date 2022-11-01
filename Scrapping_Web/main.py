from distutils.file_util import move_file
import random
from urllib import response
import requests
from bs4 import BeautifulSoup

URL = "http://www.imdb.com/chart/top"


def main():
    response = requests.get(URL)
    soup = BeautifulSoup(response.text, "html.parser")

    movietags = soup.select("td.titleColumn")
    inner_movietags = soup.select("td.titleColumn a")
    ratingsTags = soup.select("td.posterColumn span[name=ir]")

    def get_year(movie_tag):
        moviesplit = movie_tag.text.split()
        year = moviesplit[-1]
        return year

    years = [get_year(tag) for tag in movietags]
    actor_list = [tag["title"] for tag in inner_movietags]
    titles = [tag.text for tag in inner_movietags]
    ratings = [float(tag["data-value"]) for tag in ratingsTags]

    n_movies = len(titles)

    while(True):
        idx = random.randrange(0,n_movies)
        print(f"{titles[idx]} {years[idx]}, Rating : {ratings[idx]:.2f} Actors : {actor_list[idx]}")
        break

if __name__ == "__main__":
    main()