# Burger Service

![Badge em Desenvolvimento](http://img.shields.io/static/v1?label=STATUS&message=IN%20DEVELOPMENT&color=GREEN&style=for-the-badge)

Demonstrating the event-driven architecture using a mediator topology and a burger.

## :hamburger: How to run it locally

- [You need to have Docker Engine and Docker Compose on your machine](https://docs.docker.com/compose/gettingstarted/) 
- Download the *docker-compose.yml* file from the root of the project. Feel free to change the ports accordingly to your usage.
- Run `docker network create -d bridge my-network` in your terminal to create a network for your docker environment, so then the containers can communicate to each other.
- Run `docker-compose up` in your *docker-compose.yml* file directory
- Navigate to *localhost:49160* or equivalent port that was set to check the UI page
- Navigate to *localhost:2000* or equivalent port that was set to check the API documentation on Swagger and do your first request

## :eyes: Next improvements
- Organizing pipelines using templates
- Update controller-based APIs to minimal APIs in ASP.NET Core (using .NET 7.0)
- Unit tests

## :triangular_ruler: Big Picture 
<img src="docs/big_picture/big_picture_mediator.png" alt="Alt text" title="Event Driven Architecture using Mediator Topology">
